using Moq;
using PopsCars;

namespace TestForPopsCars
{
    [TestClass]
    public class UserServiceTest
    {
        //create unit tests for my UserService.cs class

        [TestMethod]
        public async Task GetAllUsers_Returns_List_Of_Users()
        {
            //Arrange
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.GetAll()).Returns(new List<User>());
            var service = new UserService(mockRepo.Object);

            //Act
            var result = await service.GetAllUsers();

            //Assert
            Assert.AreEqual(0, result.Count);
        }
    }
}
