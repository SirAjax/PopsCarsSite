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
	Note CreateNote(Note note);
	List<Note> GetNotes();
	Task DeleteNote(Note note);
	Note UpdateNotes(Note comments);

}
