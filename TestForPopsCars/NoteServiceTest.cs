using FluentAssertions;
using Moq;
using PopsCars;
using PopsCarsSite.Common.Models;

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
			Note note = new Note { Comments = "unitTest1" };
			mockRepo.Setup(repo => repo.Add(It.IsAny<Note>())).ReturnsAsync(new CommonResponse<Note> { Value = note });

			var result = await service.AddNote(note);

			Assert.AreEqual(note, result.Value);
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
			mockRepo.Setup(repo => repo.Delete(It.IsAny<Note>())).ReturnsAsync(new CommonResponse<bool>());
			Note note = new Note { Comments = "unitTest1" };

			var result = await service.DeleteNote(note);

			Assert.IsFalse(result.Value);
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
			Note note = new Note { Comments = "unitTest1" };
			mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<Note>())).ReturnsAsync(new CommonResponse<Note> { Value = note });
			note.Comments = "changed Note";

			var result = await service.UpdateNote(note);

			Assert.AreEqual(note.Comments, result.Value.Comments);
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
			List<Note> noteList = new List<Note>() { new Note { Comments = "Test Comment"}};
			mockRepo.Setup(repo => repo.GetAll()).ReturnsAsync(new CommonResponse<IEnumerable<Note>> {Value = noteList});

			var actual = await service.GetNotes();

			actual.Value.Count.Should().Be(1);
			//actual.Value.Should().Equal(noteList);
			
			// above replaced:    CollectionAssert.AreEqual(noteList, actual.Value);
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
