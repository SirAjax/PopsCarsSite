namespace TestForPopsCars
{
    public class UserServiceTest
    {
        //create unit tests for my UserService.cs class

        [TestMethod]
        public void GetAllUsers_Returns_List_Of_Users()
        {
            //Arrange
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.GetAll()).Returns(GetTestUsers());
            var service = new UserService(mockRepo.Object);

            //Act
            var result = service.GetAllUsers();

            //Assert
            Assert.AreEqual(3, result.Count);
        }
    }
}
