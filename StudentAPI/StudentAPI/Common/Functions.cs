using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentAPI.Common
{
    public class Functions
    {
        public static void CreateXML(string Uri)
        {
            try
            {
                XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement(StudentXML.RootElement, string.Empty));
                doc.Save(Uri);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string ContentRootPath
        {
            get
            {
                string rootDirectory = AppContext.BaseDirectory;
                if (rootDirectory.Contains("bin"))
                {
                    rootDirectory = rootDirectory.Substring(0, rootDirectory.IndexOf("bin"));
                }
                return rootDirectory;
            }
        }
    }
}
