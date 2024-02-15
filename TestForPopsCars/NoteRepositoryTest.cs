using Moq;
namespace TestForPopsCars;

[TestClass]
public class NoteRepositoryTest
{
    private DbContextOptions<PopsCarsContext> dbContextOptions;
    private PopsCarsContext context;
    private Mock<PopsCarsContext> contextMoq;

    [TestInitialize]
    public void Setup()
    {
        dbContextOptions = new DbContextOptionsBuilder<PopsCarsContext>().UseInMemoryDatabase("test").Options;
        context = new(dbContextOptions);
        contextMoq = new(dbContextOptions);
    }
    [TestCleanup]
    public void Cleanup()
    {
        context.Database.EnsureDeleted();
    }

    [TestMethod]
    public async Task Does_CreateNote_Return_Succes()
    {
        var note = new Note { Comments = "This is a test 1", Id = 1 };
        var noteRepository = new NoteRepository(context);

        var newNote = noteRepository.Add(note);

        Assert.IsNotNull(newNote);
    }

    [TestMethod]
    public async Task Does_CreateNote_Return_Error()
    {
        contextMoq.Setup(x => x.Add(It.IsAny<Note>())).Throws(new Exception());
        var note = new Note { Comments = "This is a test 1", Id = 1 };
		var noteRepository = new NoteRepository(context);

		var result = await noteRepository.Add(note);

        Assert.IsFalse(result);
	}

    [TestMethod]
    public async Task Does_GetAllNotes_Return_Success()
    {
        var noteRepository = new NoteRepository(context);

        noteRepository.GetAll();

        Assert.IsNotNull(noteRepository);
    }

    [TestMethod]
    public async Task Does_GetAllNotes_Return_Error()
    {
        contextMoq.Setup(x => x.Note).Throws(new Exception());
		var noteRepository = new NoteRepository(context);

		var result = noteRepository.GetAll();

        Assert.IsNull(result);
	}

    [TestMethod]
    public async Task Does_UpdateComments_Return_Success()
    {
        string originalComment = "originalTestComment", updatedComment = "updatedTestComment";
        var note = new Note { Comments = originalComment, Id = 1 };
        var noteRepository = new NoteRepository(context);
        context.Add(note);
        context.SaveChanges();
        note.Comments = updatedComment;

        bool isUpdateCommentsSuccessful = await noteRepository.UpdateAsync(note);

        Assert.IsTrue(isUpdateCommentsSuccessful);
    }
    [TestMethod]
    public async Task Does_UpdateComments_Return_Error()
    {
        contextMoq.Setup(x => x.Update(It.IsAny<Note>())).Throws(new Exception());
		string originalComment = "originalTestComment", updatedComment = "updatedTestComment";
		var note = new Note { Comments = originalComment, Id = 1 };
		var noteRepository = new NoteRepository(context);
		context.Add(note);
		context.SaveChanges();
		note.Comments = updatedComment;

		var result = await noteRepository.UpdateAsync(note);

        Assert.IsFalse(result);
	}

    [TestMethod]
    public async Task Does_DeleteNote_Return_Success()
    {
        var noteRepository = new NoteRepository(context);
        var note = new Note { Comments = "test comments", Id = 1 };
        context.Add(note);
        context.SaveChanges();

        noteRepository.Delete(note);
        var deletedNote = context.Note.FirstOrDefault(n => n.Id == 1);

        Assert.IsNull(deletedNote);
    }

    [TestMethod]
    public async Task Does_DeleteNote_Return_Error()
    {
        contextMoq.Setup(x => x.Remove(It.IsAny<Note>())).Throws(new Exception());
		var noteRepository = new NoteRepository(context);
		var note = new Note { Comments = "test comments", Id = 1 };
		context.Add(note);
		context.SaveChanges();

		var result = await noteRepository.Delete(note);

        Assert.IsFalse(result);
	}
}   
