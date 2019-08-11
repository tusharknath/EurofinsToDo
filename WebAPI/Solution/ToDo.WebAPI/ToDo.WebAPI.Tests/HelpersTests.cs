using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ToDo.WebAPI.Tests
{
    [TestClass]
    public class HelpersTests
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

        private Helpers CreateHelpers()
        {
            return new Helpers();
        }

        [TestMethod]
        public void GetHash_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var helpers = this.CreateHelpers();
            string input = null;

            // Act
            var result = helpers.GetHash(
                input);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void Encrypt_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var helpers = this.CreateHelpers();
            string clearText = null;

            // Act
            var result = helpers.Encrypt(
                clearText);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void Decrypt_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var helpers = this.CreateHelpers();
            string cipherText = null;

            // Act
            var result = helpers.Decrypt(
                cipherText);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void GetIpAddress_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var helpers = this.CreateHelpers();

            // Act
            var result = helpers.GetIpAddress();

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void JsonSerializer_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var helpers = this.CreateHelpers();
            T t = default(T);

            // Act
            var result = helpers.JsonSerializer(
                t);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void JsonDeserialize_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var helpers = this.CreateHelpers();
            string jsonString = null;

            // Act
            var result = helpers.JsonDeserialize(
                jsonString);

            // Assert
            Assert.Fail();
        }
    }
}
