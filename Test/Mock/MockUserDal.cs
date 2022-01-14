using System;
using System.Collections.Generic;
using System.Text;
using IndividueelApp.Interface.DTOs;
using IndividueelApp.Interface.Interfaces;

namespace Test.Mock
{
    public class MockUserDal : IUserDao
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public int PlatfromID { get; private set; }
        public string UserName { get; private set; }

        public void AddUser(UserDto userDto)
        {
            this.Name = userDto.Name;
            this.Description = userDto.Description;
            this.Email = userDto.Email;
            this.Password = userDto.Password;
            this.PlatfromID = userDto.PlatformID;
            this.UserName = userDto.UserName;
        }
    }
}
