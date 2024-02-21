using Moq;
using PopsCars;
using PopsCarsSite.Common.Models;

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
            List<User> userList = new List<User>() { new User { UserName = "Unit Test" } };
            mockRepo.Setup(repo => repo.GetAll()).ReturnsAsync(new CommonResponse<IEnumerable<User>>() {Value = userList });
            
            var result = await service.GetAllUsers();
            
            Assert.AreEqual(1, result.Value.Count);
        }

        [TestMethod]

        public async Task Does_AddUser_Return_Success()
        {
            User user = new User { UserName = "Unit Test" };
			mockRepo.Setup(repo => repo.Add(It.IsAny<User>())).ReturnsAsync(new CommonResponse<User>() { Value = user});
            
            var actual = await service.AddUser(user);
            
            Assert.AreEqual(user, actual.Value);
        }

        [TestMethod]

        public async Task Does_AddUser_Return_Error()
        {
            mockRepo.Setup(repo => repo.Add(It.IsAny<User>())).ThrowsAsync(new Exception());
			User user = new User { UserName = "Unit Test" };
			
            var newUser = await service.AddUser(user);

            Assert.IsTrue(newUser.Error);
		}
       
        [TestMethod]

        public async Task Does_DeleteUser_Return_Success()
        {
            mockRepo.Setup(repo => repo.Delete(It.IsAny<User>())).ReturnsAsync(new CommonResponse<bool>());
            User user = new User { UserName = "Unit Test" };

            var result =  await service.DeleteUser(user);

            Assert.IsFalse(result.Value);
        }

        [TestMethod]

		public async Task Does_DeleteUser_Return_Error()
        {
            mockRepo.Setup(repo => repo.Delete(It.IsAny<User>())).ThrowsAsync(new Exception());
			User user = new User { UserName = "Unit Test" };

            var result = await service.DeleteUser(user);

            Assert.IsTrue(result.Error);
		}


		[TestMethod]

        public async Task Does_UpdateUser_Return_Success()
        {
            User user = new User { UserName = "Unit Test" };
			mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<User>())).ReturnsAsync(new CommonResponse<User>() { Value = user});
            
            var result = await service.UpdateUser(user);
            
            Assert.AreEqual(user, result.Value);
        }

        [TestMethod]
		public async Task Does_UpdateUser_Return_Error()
        {
            mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<User>())).ThrowsAsync(new Exception());
			User user = new User { UserName = "Unit Test" };
			
            var result = await service.UpdateUser(user);

            Assert.IsTrue(result.Error);
		}
	}
}
