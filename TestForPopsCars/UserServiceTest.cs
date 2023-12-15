using Moq;
using PopsCars;

namespace TestForPopsCars
{
    [TestClass]
    public class UserServiceTest
    {
        private UserService service;
        private Mock<IUserRepository> mockRepo;
        

        [TestInitialize]

        public void Setup()
        {
            mockRepo = new Mock<IUserRepository>();
            service = new UserService(mockRepo.Object);
            
        }

        [TestMethod]
        public async Task GetAllUsers_Returns_List_Of_Users()
        {
            mockRepo.Setup(repo => repo.GetAll()).Returns(new List<User> { new User { UserName = "Unit Test" } });
            var result = await service.GetAllUsers();            
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]

        public async Task Does_AddUser_Return_Success()
        {
            mockRepo.Setup(repo => repo.Add(It.IsAny<User>())).ReturnsAsync(true);
            User user = new User { UserName = "Unit Test" };
            var newUser = await service.AddUser(user);
            Assert.IsTrue(newUser);
        }

        [TestMethod]

        public async Task Does_DeleteUser_Return_Success()
        {
            //hellp me with below unit tsst

            mockRepo.Setup(repo => repo.Delete(It.IsAny<User>())).ReturnsAsync(true);
            User user = new User { UserName = "Unit Test" };
            var result =  await service.DeleteUser(user);
            Assert.IsTrue(result);
        }

        [TestMethod]

        public async Task Does_UpdateUser_Return_Success()
        {
            mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<User>())).ReturnsAsync(true);
            User user = new User { UserName = "Unit Test" };
            var result = await service.UpdateUser(user);
            Assert.IsNotNull(result);
        }
    }
}
