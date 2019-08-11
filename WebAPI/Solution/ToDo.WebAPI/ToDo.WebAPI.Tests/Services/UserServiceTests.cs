using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using ToDo.DomainLayer.Services;
using ToDo.WebAPI.EF.Data.Model;
using ToDo.WebAPI.Repository.UnitOfWork;

namespace ToDo.WebAPI.Tests.Services
{
    [TestClass]
    public class UserServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IUnitOfWork> mockUnitOfWork;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Default);

            this.mockUnitOfWork = this.mockRepository.Create<IUnitOfWork>();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.mockRepository.VerifyAll();
        }

        private UserService CreateService()
        {
            return new UserService(
                this.mockUnitOfWork.Object);
        }

        [TestMethod]
        public async Task Authenticate_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            string username = "tanju";
            string password = "Tushar@123";

            // Act
            var result = await service.Authenticate(
                username,
                password);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public async Task Register_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            User userDTO = null;

            // Act
            var result = await service.Register(
                userDTO);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void ForgotPassword_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            User userDTO = null;

            // Act
            var result = service.ForgotPassword(
                userDTO);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public async Task GetAll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();

            // Act
            var result = await service.GetAll();

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public async Task GetUserID_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            string userName = null;

            // Act
            var result = await service.GetUserID(
                userName);

            // Assert
            Assert.Fail();
        }
    }
}
