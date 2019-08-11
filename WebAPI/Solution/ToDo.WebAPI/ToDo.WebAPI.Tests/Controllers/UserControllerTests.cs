using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDo.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DomainLayer.Services.Interface;
using AutoMapper;

namespace ToDo.WebAPI.Controllers.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        private UserController _userController;
        private IUserService _userService;
        private IMapper _mapper;
        private string _userId;


        [TestMethod()]
        public void UserControllerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AuthenticateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RegisterTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ForgotPasswordTest()
        {
            Assert.Fail();
        }
    }
}