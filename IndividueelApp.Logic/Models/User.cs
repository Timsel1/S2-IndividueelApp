using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace IndividueelApp.Logic.Models
{
    public class User
    {
        [Key]
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int PlatfromID { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}
