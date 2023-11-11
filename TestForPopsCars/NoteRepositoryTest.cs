using Microsoft.EntityFrameworkCore;
using EFTest;
using EFTest.Models;
using Microsoft.Data.Sqlite;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;
using NuGet.Frameworks;
using System.Net.Mime;

namespace TestForPopsCars;

[TestClass]
public class NoteRepositoryTest
{
    [TestMethod]
    public async Task Does_Create_Note_Return_Succes()
    {
        var builder = new DbContextOptionsBuilder<PopsCarsContext>().UseInMemoryDatabase("test");

        using (var context = new PopsCarsContext(builder.Options)) 
        { 
            var note = new Note { Comments = "This is a test 1", NoteId = 1};
            var noteRepository = new NoteRepository(context);
            var newNote = noteRepository.CreateNote(note);
            Assert.IsNotNull(newNote);
        }
    }

    [TestMethod]

    public async Task Does_Get_All_Notes_Return_Success()
    {
        var builder = new DbContextOptionsBuilder<PopsCarsContext>().UseInMemoryDatabase("test");

        using (var context = new PopsCarsContext(builder.Options))
        {
            var noteRepository = new NoteRepository(context);
            noteRepository.GetAllNotes();
            Assert.IsNotNull(noteRepository);
        }
    }

    [TestMethod]
    public async Task Does_GetComments_Return_Success()
    {
        var builder = new DbContextOptionsBuilder<PopsCarsContext>().UseInMemoryDatabase("test");

        using (var context = new PopsCarsContext(builder.Options))
        {
            var comment = new Note { Comments = "test comment" };
            var noteRepository = new NoteRepository(context);
            context.Add(comment);
            context.SaveChanges();
            var searchedComments = await noteRepository.GetComments("test comment");
            Assert.AreEqual(comment, searchedComments.FirstOrDefault());
        }
    }

    [TestMethod]
    public async Task Does_UpdateComments_Return_Success()
    {
        var builder = new DbContextOptionsBuilder<PopsCarsContext>().UseInMemoryDatabase("test");

        using (var context = new PopsCarsContext(builder.Options))
        {
            string originalComment = "originalTestComment", updatedComment = "updatedTestComment";
            var note = new Note { Comments = originalComment, NoteId = 1 };
            var noteRepository = new NoteRepository(context);
            context.Add(note);
            context.SaveChanges();
            var newNote = new Note { Comments = updatedComment, NoteId = 1 };
            Note actual = noteRepository.UpdateComments(newNote);
            Assert.AreEqual(updatedComment, actual.Comments);
            Assert.AreNotEqual(originalComment, note.Comments);
        }
    }

    [TestMethod]
    public async Task Does_DeleteNote_Return_Success()
    {
        var builder = new DbContextOptionsBuilder<PopsCarsContext>().UseInMemoryDatabase("test");

        using (var context = new PopsCarsContext(builder.Options))
        {
            var noteRepository = new NoteRepository(context);
            var note = new Note { Comments = "test comments", NoteId = 1 };
            context.Add(note);
            context.SaveChanges();
            noteRepository.DeleteNote(note);
            var deletedNote = context.Note.FirstOrDefault(n => n.NoteId == 1);
            Assert.IsNull(deletedNote);
        }
    }
}
