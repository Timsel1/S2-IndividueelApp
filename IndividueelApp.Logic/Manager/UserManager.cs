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

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            List<UserDto> userDTOs = userDao.GetAllUsers();
            foreach (var user1 in userDTOs)
            {
                User user = new User()
                {
                    Name = user1.Name,
                    UserName = user1.UserName,
                    Password = user1.Password,
                    Description = user1.Description,
                    Email = user1.Email,
                    PlatfromID = user1.PlatformID
                };
                users.Add(user);
            }
            return users;
        }
    }
}
