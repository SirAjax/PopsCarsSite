using Moq;
using PopsCars;

namespace TestForPopsCars
{
    [TestClass]
    public class NoteServiceTest

    {
        private NoteService service;
        private Mock<INoteRepository> mockRepo;
        private Note note = new Note { Comments = "unitTest1" };

        [TestInitialize]
        public void Setup()
        {
            var mockRepo = new Mock<INoteRepository>();
            var service = new NoteService(mockRepo.Object);
            mockRepo.Setup(repo => repo.GetAll()).Returns(new List<Note> { new Note { Comments = "unitTest1" }, new Note { Comments = "unitTest2" } });
        }

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

        [TestMethod]

        public void Does_AddNote_Return_Success()
        { 
            var result = service.AddNote(note);
            Assert.IsNotNull(result);
        }

        [TestMethod]

        public void Does_DeleteNote_Return_Success()
        {
            var result = service.DeleteNote(note);
            Assert.IsNotNull(result);
        }

        [TestMethod]

        public void Does_UpdateNote_Return_Success()
        {
            var result = service.UpdateNote(note);
            Assert.IsNotNull(result);
        }

        [TestMethod]

        public void Does_GetAllNotes_Return_Success()
        {
            var result = service.GetNotes();
            Assert.IsNotNull(result);
        }
    }
}
