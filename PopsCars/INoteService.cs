using EFTest.Models;

namespace PopsCars;


public interface INoteService
{
	Note CreateNote(Note note);
	List<Note> GetNotes();
	Task DeleteNote(Note note);
	Note UpdateNotes(Note comments);
	Task<List<Note>> GetCommentsAsync(string comments);

}
