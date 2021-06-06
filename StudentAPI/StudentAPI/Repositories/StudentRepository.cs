using StudentAPI.Common;
using StudentAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace StudentAPI.Repositories
{
    public class Studentrepository : IStudentRepository
    {
        private string _xmlConnection { get; set; } = Functions.ContentRootPath + "\\" + (StudentXML.FileName);

        public APIResponse GetStudent()
        {
            APIResponse api = new APIResponse();
            List<Student> lstStudent = new List<Student>();
            try
            {
                XDocument XmlDocObj = XDocument.Load(_xmlConnection);

                lstStudent = XmlDocObj.Root
                    .Descendants(StudentXML.Element)
                    .Select(node => new Student
                    {
                        Id = int.Parse(node.Attribute(StudentXML.Attributes.Id).Value),
                        FirstName = node.Element(StudentXML.Attributes.FirstName).Value,
                        LastName = node.Element(StudentXML.Attributes.LastName).Value,
                        Grade = node.Element(StudentXML.Attributes.Grade).Value
                    })
                    .ToList();

                api.result = lstStudent;
                api.message = "";
                api.success = true;
            }
            catch (Exception ex)
            {
                api.message = ex.Message;
                api.success = false;
            }

            return api;
        }
        public APIResponse GetStudent(int Id)
        {
            APIResponse api = new APIResponse(); 
            try
            {
                Student objStudent = new Student();
                XDocument XmlDocObj = XDocument.Load(_xmlConnection);
                objStudent = XmlDocObj.Root
                    .Descendants(StudentXML.Element)
                    .Where(x => (int)x.Attribute(StudentXML.Attributes.Id) == Id)
                    .Select(node => new Student
                    {
                        Id = int.Parse(node.Attribute(StudentXML.Attributes.Id).Value),
                        FirstName = node.Element(StudentXML.Attributes.FirstName).Value,
                        LastName = node.Element(StudentXML.Attributes.LastName).Value,
                        Grade = node.Element(StudentXML.Attributes.Grade).Value
                    })
                    .FirstOrDefault();

                api.result = objStudent;
                api.message = "";
                api.success = true;
            }
            catch (Exception ex)
            {
                api.message = ex.Message;
                api.success = false;
            }
            return api;
        }
        public APIResponse SaveStudent(Student obj)
        {
            APIResponse api = new APIResponse();
            try
            {
                if (!System.IO.File.Exists(_xmlConnection))
                {
                    Functions.CreateXML(_xmlConnection);
                }

                XDocument XmlDocObj = XDocument.Load(_xmlConnection);

                if (obj.Id > 0)
                {
                    var elementsToUpdate = XmlDocObj.Root.Descendants(StudentXML.Element).Where(x => (int)x.Attribute(StudentXML.Attributes.Id) == obj.Id).FirstOrDefault();
                    if (elementsToUpdate != null)
                    {
                        elementsToUpdate.Element(StudentXML.Attributes.FirstName).Value = obj.FirstName;
                        elementsToUpdate.Element(StudentXML.Attributes.LastName).Value = obj.LastName;
                        elementsToUpdate.Element(StudentXML.Attributes.Grade).Value = obj.Grade;
                        api.message = "Record Updated";
                        api.success = true;
                    }
                    else
                    {
                        api.message = "Record Not Found to Update";
                        api.success = false;
                    }
                }
                else
                {
                    var maxId = XmlDocObj.Root.Elements().Count() > 0 ? XmlDocObj.Root.Elements().Max(x => (int)x.Attribute(StudentXML.Attributes.Id)) : 0;
                    XElement user = new XElement(StudentXML.Element);
                    user.Add(new XAttribute(StudentXML.Attributes.Id, (maxId + 1).ToString()));
                    user.Add(new XElement(StudentXML.Attributes.FirstName, obj.FirstName));
                    user.Add(new XElement(StudentXML.Attributes.LastName, obj.LastName));
                    user.Add(new XElement(StudentXML.Attributes.Grade, obj.Grade));
                    XmlDocObj.Element(StudentXML.RootElement).Add(user);
                    api.message = "Record Added";
                    api.success = true;
                }

                XmlDocObj.Save(_xmlConnection);
            }
            catch (Exception ex)
            {
                api.message = ex.Message;
                api.success = false;
            }
            return api;
        }
        public APIResponse DeleteStudent(int Id)
        {
            APIResponse api = new APIResponse();
            try
            {
                if (Id > 0)
                {
                    XDocument doc = XDocument.Load(_xmlConnection);
                    doc.Descendants(StudentXML.RootElement)
                       .Descendants(StudentXML.Element)
                       .Where(x => (int)x.Attribute(StudentXML.Attributes.Id) == Id)
                       .Remove();
                    doc.Save(_xmlConnection);

                    api.message = "Record Deleted";
                    api.success = true;
                }
            }
            catch (Exception ex)
            {
                api.message = ex.Message;
                api.success = false;
            }
            return api;
        }
    }
}
