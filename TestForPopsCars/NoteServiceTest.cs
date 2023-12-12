using Moq;
using PopsCars;

namespace TestForPopsCars
{
    [TestClass]
    public class NoteServiceTest

    {
        //create unit tests for my NoteService.cs class
        [TestMethod]
        public void GetAllNotes_Returns_List_Of_Notes()
        {
            //Arrange
            var mockRepo = new Mock<INoteRepository>();
            mockRepo.Setup(repo => repo.GetAll()).Returns(new List<Note> { new Note { Comments = "unitTest1" }, new Note { Comments = "unitTest2" } });
            var service = new NoteService(mockRepo.Object);

            //Act
            var result = service.GetNotes();

            //Assert
            Assert.AreEqual(2, result.Count);
        }
    }
}
