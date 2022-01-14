using System;
using System.Collections.Generic;
using System.Text;
using IndividueelApp.Interface.DTOs;

namespace IndividueelApp.Interface.Interfaces
{
    public interface IUserDao
    {
        public void AddUser(UserDto userDto);

    }
}
