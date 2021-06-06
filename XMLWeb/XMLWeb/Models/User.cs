using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XMLWeb.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Surname is required.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Cell Phone Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Cell Phone Number.")]
        public string CellPhone { get; set; }

        public List<User> UserList { get; set; }

    }
}