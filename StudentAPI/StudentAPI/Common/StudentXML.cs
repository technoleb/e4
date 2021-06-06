using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Common
{
    public class StudentXML
    {
        public static string FileName = "XMLStudent.xml";
        public static string RootElement = "Students";
        public static string Element = "Student";

        public class Attributes
        {
            public static string Id = "Id";
            public static string FirstName = "FirstName";
            public static string LastName = "LastName";
            public static string Grade = "Grade";
        }
    }
}
