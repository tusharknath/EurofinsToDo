using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDo.DomainLayer.Services;
using ToDo.DomainLayer.Services.Interface;
using ToDo.WebAPI.EF.Data.Model;
using ToDo.WebAPI.Repository;
using ToDo.WebAPI.Repository.UnitOfWork;

namespace ToDo.WebAPI.Tests.Services
{
    [TestClass]
    public class UserServiceTests
    {
        private Mock<IRepository<User>> _userRepository;
        private Mock<IUnitOfWork> _unitOfWork;
        private UserService _service;

        [TestInitialize]
        public void TestInitialize()
        {

        }


        [TestMethod]
        public async Task Authenticate_User_WithUserNameAndPassword()
        {
            var username = "tanju";
            var password = "Tushar@123";
            var product = new User() { UserName = username, Password = password };


            var productRepositoryMock = new Mock<IRepository<User>>();
            productRepositoryMock.Setup(m => m.GetFirstOrDefault(x => x.UserName == product.UserName)).Returns(product).Verifiable();

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            //unitOfWorkMock.Setup(m => m.productRepository).Returns(productRepositoryMock.Object);
            unitOfWorkMock.Setup(u => u.Repository<User>()).Returns(productRepositoryMock.Object);

            IUserService sut = new UserService(unitOfWorkMock.Object);
            //Act
            var actual = await sut.Authenticate(username, password);

            //Assert
            productRepositoryMock.Verify();//verify that GetByID was called based on setup.
            Assert.IsNotNull(actual);//assert that a result was returned
            //Assert.AreEqual(expected, actual);//assert that actual result was as expected

        }

        [TestMethod]
        public async Task Register_User()
        {
            var testObject = new User();
            testObject.UserName = "Tushar123";
            testObject.LastName = "1111";
            testObject.Password = "Tushar@123";
            testObject.FirstName = "tyyy";

            var context = new Mock<ToDoDBContext>();
            var dbSetMock = new Mock<DbSet<User>>();
            context.Setup(x => x.Set<User>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Remove(It.IsAny<User>())).Returns(testObject);

            // Act
            // Arrange
            var _userRepository = new Mock<Repository<User>>(context.Object);
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(u => u.Repository<User>()).Returns(_userRepository.Object);
            //_unitOfWork.Setup(u => u.Repository<User>()).Returns(user);

            _service = new UserService(_unitOfWork.Object);

            //Act
            var result = await _service.Register(
               testObject);

            var expResult = result.UserName;
            Assert.AreEqual(expResult.ToLower(), "Tushar123".ToLower());

        }


    }
}
