using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using ToDo.DomainLayer.Services;
using ToDo.WebAPI.Repository.UnitOfWork;

namespace ToDo.WebAPI.Tests.Services
{
    [TestClass]
    public class LoggerServiceTests
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

        private LoggerService CreateService()
        {
            return new LoggerService(
                this.mockUnitOfWork.Object);
        }

        [TestMethod]
        public void Insert_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Log log = null;

            // Act
            service.Insert(
                log);

            // Assert
            Assert.Fail();
        }
    }
}
