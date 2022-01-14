using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using IndividueelApp.Logic.Manager;
using IndividueelApp.Logic.Models;
using IndividueelApp.Interface.Interfaces;


namespace Test
{
    [TestClass]
    public class MyTestClass
    {
        
        [TestMethod]
        public void AddUserTest()
        {
            //Arrange
            Mock.MockUserDal mockDal = new Mock.MockUserDal();
            UserManager userManager = new UserManager(mockDal); 
            User user = new User() { Name = "Jan", Description = "WOW", Email = "Ik@Email.og", Password = "Password123", PlatfromID = 1234, UserName = "JanDeMan" };

            //Act
            userManager.AddUser(user);

            //Assert
            Assert.AreEqual(user.Name, mockDal.Name);
            Assert.AreEqual(user.Description, mockDal.Description);
            Assert.AreEqual(user.Email, mockDal.Email);
            Assert.AreEqual(user.Password, mockDal.Password);
            Assert.AreEqual(user.PlatfromID, mockDal.PlatfromID);
            Assert.AreEqual(user.UserName, mockDal.UserName);

        }
    }
}
