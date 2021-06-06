using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Common
{
    public class APIResponse
    {
        public string message { get; set; }
        public bool success { get; set; }
        public object result { get; set; }
    }
}
