using System;
using System.Collections.Generic;
using System.Text;
using IndividueelApp.Logic.Models;
using IndividueelApp.Interface.Interfaces;
using IndividueelApp.Interface.DTOs;

namespace IndividueelApp.Logic.Manager
{
    public class UserManager
    {
        private IUserDao userDao { get; set; }

        public UserManager(IUserDao _userDao)
        {
            this.userDao = _userDao;
        }

        public void AddUser(User user)
        {
            UserDto userDto = new UserDto()
            {
                Name = user.Name,
                Email = user.Email,
                UserName = user.UserName,
                Password = user.Password,
                Description = user.Description,
                PlatformID = user.PlatfromID
            };
            userDao.AddUser(userDto);
        }
    }
}
