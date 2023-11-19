using EFTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest
{
    public class NoteRepository : INoteRepository
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

        public async Task<List<Note>> GetComments(string comments)
        {
            return await _popsCarsContext.Note.Where(c => c.Comments == comments).ToListAsync();
        }

        public Note UpdateComments(Note comments)
        {

            Note? currentComments = _popsCarsContext.Note.Find(comments.NoteId);

            if (currentComments != null)
            {
                _popsCarsContext.Entry(currentComments).CurrentValues.SetValues(comments);
                _popsCarsContext.SaveChanges();
            }

            return comments;
        }

        public void DeleteNote(Note note)
        {
            _popsCarsContext.Note.Remove(note);
            _popsCarsContext.SaveChanges();
        }
    }
}
