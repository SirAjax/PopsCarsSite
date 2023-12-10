using EFTest.Models;

namespace PopsCars;


public interface INoteService 
{
	Task<bool> CreateNote(Note note);
	List<Note> GetNotes();
	Task<bool> DeleteNote(Note note);
	Task<bool> UpdateNotes(Note comments);
	

}
