using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XMLWeb.Common
{
    public class UserXML
    {
        public static string FileName = "UserList.xml";
        public static string RootElement = "Users";
        public static string Element = "User";
        
        public class Attributes
        {
            public static string Id = "Id";
            public static string FirstName = "FirstName";
            public static string SurName = "SurName";
            public static string CellPhoneNumber = "CellPhone";
        }


    }
}