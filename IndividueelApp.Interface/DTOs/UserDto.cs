using System;
using System.Collections.Generic;
using System.Text;

namespace IndividueelApp.Interface.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int PlatformID { get; set; }
        public string Description { get; set; }
    }
}
