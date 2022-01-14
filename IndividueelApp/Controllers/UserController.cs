using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndividueelApp.Models;
using IndividueelApp.Logic.Manager;
using IndividueelApp.Logic.Models;
using IndividueelApp.Interface.Interfaces;

namespace IndividueelApp.Controllers
{
    public class UserController : Controller
    {
        UserManager userManager;
        public UserController(UserManager _userManager)
        {
            this.userManager = _userManager;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] UserViewModel viewModel)
        {
            try
            {
                userManager.AddUser(new User() { Name = viewModel.Name, Description = viewModel.Description, Email = viewModel.Email, Password = viewModel.Password, PlatfromID = viewModel.PlatfromID, UserName = viewModel.UserName });
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}
