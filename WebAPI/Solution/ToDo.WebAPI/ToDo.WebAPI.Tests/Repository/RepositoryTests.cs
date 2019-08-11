using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using ToDo.WebAPI.EF.Data.Model;
using ToDo.WebAPI.Repository;

namespace ToDo.WebAPI.Tests.Repository
{
    [TestClass]
    public class RepositoryTests
    {
        private MockRepository mockRepository;

        private Mock<ToDoDBContext> mockToDoDBContext;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockToDoDBContext = this.mockRepository.Create<ToDoDBContext>();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.mockRepository.VerifyAll();
        }

        private Repository CreateRepository()
        {
            return new Repository(
                this.mockToDoDBContext.Object);
        }

        [TestMethod]
        public void Get_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var repository = this.CreateRepository();
            Expression filter = null;
            Func orderBy = null;
            Expression<Func<T, object>>[] includes = null;

            // Act
            var result = repository.Get(
                filter,
                orderBy,
                includes);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void Query_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var repository = this.CreateRepository();
            Expression filter = null;
            Func orderBy = null;

            // Act
            var result = repository.Query(
                filter,
                orderBy);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public async Task GetById_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var repository = this.CreateRepository();
            object id = null;

            // Act
            var result = await repository.GetById(
                id);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void GetFirstOrDefault_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var repository = this.CreateRepository();
            Expression filter = null;
            Expression<Func<T, object>>[] includes = null;

            // Act
            var result = repository.GetFirstOrDefault(
                filter,
                includes);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public async Task Insert_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var repository = this.CreateRepository();
            T entity = null;

            // Act
            var result = await repository.Insert(
                entity);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public async Task Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var repository = this.CreateRepository();
            T entity = null;

            // Act
            var result = await repository.Update(
                entity);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public async Task Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var repository = this.CreateRepository();
            int id = 0;

            // Act
            await repository.Delete(
                id);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void Dispose_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var repository = this.CreateRepository();

            // Act
            repository.Dispose();

            // Assert
            Assert.Fail();
        }
    }
}
