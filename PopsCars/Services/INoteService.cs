using EFTest.Models;
using PopsCarsSite.Common.Models;
namespace PopsCars;


public interface INoteService 
{
	Task<CommonResponse<bool>> AddNote(Note note);
	Task <CommonResponse<List<Note>>> GetNotes();
	
	Task<List<Note>> GetNoteById(int id);	
	Task<bool> DeleteNote(Note note);
	Task<bool> UpdateNote(Note comments);

	Task<List<Note>> MainSearch(string search);
}
