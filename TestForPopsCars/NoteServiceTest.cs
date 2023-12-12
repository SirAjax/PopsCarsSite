namespace TestForPopsCars
{
    public class NoteServiceTest

    {
        //create unit tests for my NoteService.cs class
        [TestMethod]
        public void GetAllNotes_Returns_List_Of_Notes()
        {
            //Arrange
            var mockRepo = new Mock<INoteRepository>();
            mockRepo.Setup(repo => repo.GetAll()).Returns(GetTestNotes());
            var service = new NoteService(mockRepo.Object);

            //Act
            var result = service.GetAllNotes();

            //Assert
            Assert.AreEqual(3, result.Count);
        }
    }
}
