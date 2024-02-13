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
    public async Task Does_Create_Note_Return_Succes()
    {


        var note = new Note { Comments = "This is a test 1", Id = 1 };
        var noteRepository = new NoteRepository(context);
        var newNote = noteRepository.Add(note);
        Assert.IsNotNull(newNote);

    }

    [TestMethod]

    public async Task Does_Get_All_Notes_Return_Success()
    {


        var noteRepository = new NoteRepository(context);
        noteRepository.GetAll();
        Assert.IsNotNull(noteRepository);

    }

   

    [TestMethod]
    public async Task Does_UpdateComments_Return_Success()
    {
        // arrange
        string originalComment = "originalTestComment", updatedComment = "updatedTestComment";
        var note = new Note { Comments = originalComment, Id = 1 };
        var noteRepository = new NoteRepository(context);
        context.Add(note);
        context.SaveChanges();
        note.Comments = updatedComment;

        // act 
        bool isUpdateCommentsSuccessful = await noteRepository.UpdateAsync(note);

        //assert
        Assert.IsTrue(isUpdateCommentsSuccessful);
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
}
