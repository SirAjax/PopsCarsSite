using EFTest.Models;

namespace EFTest;

    public interface INoteRepository
    {
        Note CreateNote(Note note);
        List<Note> GetAllNotes();
        Task<List<Note>> GetComments(string comments);
        Note UpdateComments(Note comments);
        void DeleteNote(Note note); 
    }

