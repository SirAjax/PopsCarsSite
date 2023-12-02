using EFTest;
using EFTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopsCars;


public interface INoteService 
{
	Task<bool> CreateNote(Note note);
	List<Note> GetNotes();
	Task DeleteNote(Note note);
	bool UpdateNotes(Note comments);
	IEnumerable<Note> GetCommentsAsync(string comments);

}
