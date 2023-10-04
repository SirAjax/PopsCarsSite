using EFTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest
{
	internal class NoteRepository
	{
		private readonly PopsCarsContext _popsCarsContext;

		public NoteRepository(PopsCarsContext popsCarsContext)
		{
			_popsCarsContext = popsCarsContext;
		}

		public Note CreateNote(Note note) 
		
		{ 
			_popsCarsContext.Note.Add(note);
			_popsCarsContext.SaveChanges();
			return note;
		}

		public List<Note> GetAllNotes() 
		{ 
			return _popsCarsContext.Note.ToList();	
		}

		public List<Note> GetComments(string comments) 
		{
			return _popsCarsContext.Note.Where(c => c.Comments == comments).ToList();
		}

		public Note UpdateComments(Note comments) 
		{
			Note? currentComments = _popsCarsContext.Note.Find(comments);
			_popsCarsContext.Entry(currentComments).CurrentValues.SetValues(comments);
			_popsCarsContext.SaveChanges();
			return comments;

		} 
		public void DeleteNote(Note note) 
		{
			_popsCarsContext.Note.Remove(note);
			_popsCarsContext.SaveChanges();
		}
	}
}
