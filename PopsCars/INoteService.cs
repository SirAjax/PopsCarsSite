using EFTest.Models;

namespace PopsCars;


public interface INoteService 
{
	Task<bool> AddNote(Note note);
	List<Note> GetNotes();
	Task<bool> DeleteNote(Note note);
	Task<bool> UpdateNote(Note comments);
	

}
