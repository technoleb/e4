using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace XMLWeb.Common
{
    public class Functions
    {
        public static void CreateXML(string Uri)
        {
            try
            {
                XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement(UserXML.RootElement, string.Empty));
                doc.Save(Uri);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}