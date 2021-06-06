using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using XMLWeb.Common;
using XMLWeb.Models;
using System.IO;

namespace XMLWeb.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private string _xmlConnection { get; set; } = HttpContext.Current.Server.MapPath("~") + "\\" + (UserXML.FileName);
        public List<User> GetUsers()
        {
            List<User> lstUser = new List<User>();
            try
            {
                XDocument XmlDocObj = XDocument.Load(_xmlConnection);

                lstUser = XmlDocObj.Root
                    .Descendants(UserXML.Element)
                    .Select(node => new User
                    {
                        Id = int.Parse(node.Attribute(UserXML.Attributes.Id).Value),
                        FirstName = node.Element(UserXML.Attributes.FirstName).Value,
                        Surname = node.Element(UserXML.Attributes.SurName).Value,
                        CellPhone = node.Element(UserXML.Attributes.CellPhoneNumber).Value
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return lstUser;
        }
        public User GetUser(int Id)
        {
            User objUser = new User();
            try
            {
                XDocument XmlDocObj = XDocument.Load(_xmlConnection);
                objUser = XmlDocObj.Root
                    .Descendants(UserXML.Element)
                    .Where(x => (int)x.Attribute(UserXML.Attributes.Id) == Id)
                    .Select(node => new User
                    {
                        Id = int.Parse(node.Attribute(UserXML.Attributes.Id).Value),
                        FirstName = node.Element(UserXML.Attributes.FirstName).Value,
                        Surname = node.Element(UserXML.Attributes.SurName).Value,
                        CellPhone = node.Element(UserXML.Attributes.CellPhoneNumber).Value
                    })
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUser;
        }
        public void SaveUser(User obj)
        {
            try
            {
                if (!System.IO.File.Exists(_xmlConnection))
                {
                    Functions.CreateXML(_xmlConnection);
                }

                XDocument XmlDocObj = XDocument.Load(_xmlConnection);

                if (obj.Id > 0)
                {
                    var elementsToUpdate = XmlDocObj.Root.Descendants(UserXML.Element).Where(x => (int)x.Attribute(UserXML.Attributes.Id) == obj.Id).FirstOrDefault();
                    elementsToUpdate.Element(UserXML.Attributes.FirstName).Value = obj.FirstName;
                    elementsToUpdate.Element(UserXML.Attributes.SurName).Value = obj.Surname;
                    elementsToUpdate.Element(UserXML.Attributes.CellPhoneNumber).Value = obj.CellPhone;
                }
                else
                {
                    var maxId = XmlDocObj.Root.Elements().Count() > 0 ? XmlDocObj.Root.Elements().Max(x => (int)x.Attribute(UserXML.Attributes.Id)) : 0;
                    XElement user = new XElement(UserXML.Element);
                    user.Add(new XAttribute(UserXML.Attributes.Id, (maxId + 1).ToString()));
                    user.Add(new XElement(UserXML.Attributes.FirstName, obj.FirstName));
                    user.Add(new XElement(UserXML.Attributes.SurName, obj.Surname));
                    user.Add(new XElement(UserXML.Attributes.CellPhoneNumber, obj.CellPhone));
                    XmlDocObj.Element(UserXML.RootElement).Add(user);
                }
                XmlDocObj.Save(_xmlConnection);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void DeleteUser(int Id)
        {
            try
            {
                if (Id > 0)
                {
                    XDocument doc = XDocument.Load(_xmlConnection);
                    doc.Descendants(UserXML.RootElement)
                       .Descendants(UserXML.Element)
                       .Where(x => (int)x.Attribute(UserXML.Attributes.Id) == Id)
                       .Remove();
                    doc.Save(_xmlConnection);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}