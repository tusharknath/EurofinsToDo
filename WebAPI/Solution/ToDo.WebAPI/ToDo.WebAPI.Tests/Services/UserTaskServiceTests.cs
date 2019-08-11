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
    public class UserTaskServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IUnitOfWork> mockUnitOfWork;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockUnitOfWork = this.mockRepository.Create<IUnitOfWork>();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.mockRepository.VerifyAll();
        }

        private UserTaskService CreateService()
        {
            return new UserTaskService(
                this.mockUnitOfWork.Object);
        }

        [TestMethod]
        public async Task CreateUserTask_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            UserTask userTask = null;

            // Act
            var result = await service.CreateUserTask(
                userTask);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public async Task UpdateUserTask_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            UserTask userTask = null;

            // Act
            var result = await service.UpdateUserTask(
                userTask);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public async Task GetAll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            int userID = 0;

            // Act
            var result = await service.GetAll(
                userID);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public async Task DeleteUserTask_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            int id = 0;

            // Act
            await service.DeleteUserTask(
                id);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public async Task GetUserTaskByID_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            int id = 0;

            // Act
            var result = await service.GetUserTaskByID(
                id);

            // Assert
            Assert.Fail();
        }
    }
}
