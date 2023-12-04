using EFTest.Models;

namespace PopsCars;


public interface INoteService 
{
	Task<bool> CreateNote(Note note);
	List<Note> GetNotes();
	Task DeleteNote(Note note);
	bool UpdateNotes(Note comments);
	

}
