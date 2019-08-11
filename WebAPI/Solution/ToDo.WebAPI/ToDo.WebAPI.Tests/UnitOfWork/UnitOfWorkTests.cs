using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToDo.WebAPI.Repository.UnitOfWork;

namespace ToDo.WebAPI.Tests.UnitOfWork
{
    [TestClass]
    public class UnitOfWorkTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.mockRepository.VerifyAll();
        }

        private UnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork();
        }

        [TestMethod]
        public void Repository_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitOfWork = this.CreateUnitOfWork();

            // Act
            var result = unitOfWork.Repository();

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void BeginTransaction_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitOfWork = this.CreateUnitOfWork();

            // Act
            var result = unitOfWork.BeginTransaction();

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void SaveChanges_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitOfWork = this.CreateUnitOfWork();

            // Act
            var result = unitOfWork.SaveChanges();

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void Dispose_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitOfWork = this.CreateUnitOfWork();

            // Act
            unitOfWork.Dispose();

            // Assert
            Assert.Fail();
        }
    }
}
