using Moq;
using PopsCars;

namespace TestForPopsCars
{
    [TestClass]
    public class UserServiceTest
    {
        private UserService service;
        private Mock<IUserRepository> mockRepo;
        private User user = new User { UserName = "unit test" };

        [TestInitialize]

        public void Setup()
        {
            var mockRepo = new Mock<IUserRepository>();
            var service = new UserService(mockRepo.Object);
            mockRepo.Setup(repo => repo.GetAll()).Returns(new List<User> { new User { UserName = "unit test" } });
        }

        [TestMethod]
        public async Task GetAllUsers_Returns_List_Of_Users()
        { 
            var result = await service.GetAllUsers();            
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]

        public async Task Does_AddUser_Return_Success()
        {
            var newUser = await service.AddUser(user);
            Assert.IsNotNull(newUser);
        }

        [TestMethod]

        public async Task Does_DeleteUser_Return_Success()
        {
            var result = await service.DeleteUser(user);
            Assert.IsNotNull(result);
        }

        [TestMethod]

        public async Task Does_UpdateUser_Return_Success()
        {
            var result = await service.UpdateUser(user);
            Assert.IsNotNull(result);
        }
    }
}
