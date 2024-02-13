﻿using Moq;
using PopsCars;

namespace TestForPopsCars
{
    [TestClass]
    public class NoteServiceTest

    {
        private NoteService service;
        private Mock<INoteRepository> mockRepo;
        
        
        [TestInitialize]

        public void Setup()
        {
            mockRepo = new Mock<INoteRepository>();
            service = new NoteService(mockRepo.Object);
        }

        [TestMethod]

        public async Task Does_AddNote_Return_Success()
        { 
            mockRepo.Setup(repo => repo.Add(It.IsAny<Note>())).ReturnsAsync(true);
            Note note = new Note { Comments = "unitTest1" };
          
            var result = await service.AddNote(note);
            
            Assert.IsTrue(result.Value);
        }

        [TestMethod]
        public async Task Does_AddNote_Return_Error()
        {
            mockRepo.Setup(repo => repo.Add(It.IsAny<Note>())).ThrowsAsync(new Exception());
            Note note = new Note { Comments = "unitTest1" };

            var result = await service.AddNote(note);

            Assert.IsTrue(result.Error);

        }

        [TestMethod]
        public async Task Does_DeleteNote_Return_Success()
        {
            mockRepo.Setup(repo => repo.Delete(It.IsAny<Note>())).ReturnsAsync(true);
            Note note = new Note { Comments = "unitTest1" };
            
            var result = await service.DeleteNote(note);
          
            Assert.IsTrue(result.Value);
        }

        [TestMethod]

        public async Task Does_DeleteNote_Return_Error()
        {
            mockRepo.Setup(repo => repo.Delete(It.IsAny<Note>())).ThrowsAsync(new Exception());
			Note note = new Note { Comments = "unitTest1" };

            var result = await service.DeleteNote(note);

            Assert.IsTrue(result.Error);
		}
        [TestMethod]

        public async Task Does_UpdateNote_Return_Success()
        {
            mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<Note>())).ReturnsAsync(true);
            Note note = new Note { Comments = "unitTest1" };
            var result = await service.UpdateNote(note);
            Assert.IsTrue(result.Value);
        }

        [TestMethod]
        public async Task Does_UpdateNote_Return_Error()
        {
            mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<Note>())).ThrowsAsync(new Exception());
			Note note = new Note { Comments = "unitTest1" };

            var result = await service.UpdateNote(note);

            Assert.IsTrue(result.Error);
        }

        [TestMethod]

        public async Task Does_GetNotes_Return_Success()
        {
            mockRepo.Setup(repo => repo.GetAll()).Returns(new List<Note> { new Note { Comments = "Test Comment" } });
            
            var result = await service.GetNotes();
            
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Does_GetNotes_Return_Error()
        {
            mockRepo.Setup(repo => repo.GetAll()).Throws(new Exception());

            var result = await service.GetNotes();

            Assert.IsTrue(result.Error);
        }

    }
}
