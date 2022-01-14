using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using IndividueelApp.Logic;

namespace IndividueelApp.Models
{
    public class UserViewModel
    {
        [Key]
        //public int ID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        //public int UserID { get; set; }
        public int PlatfromID { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

    }
}
