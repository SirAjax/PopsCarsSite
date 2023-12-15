using EFTest.Models;

namespace PopsCars;


public interface INoteService 
{
	Task AddNote(Note note);
	Task <List<Note>> GetNotes();
	Task DeleteNote(Note note);
	Task UpdateNote(Note comments);
	

}
