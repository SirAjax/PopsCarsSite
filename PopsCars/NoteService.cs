using EFTest;
using EFTest.Models;

namespace PopsCars
{
	public class NoteService : INoteService

	{
		private readonly INoteRepository _noteRepository;


		public NoteService(INoteRepository noteRepository)
		{
			_noteRepository = noteRepository;
		}

		public Note CreateNote(Note note)
		{
			return _noteRepository.CreateNote(note);
		}

		public List<Note> GetNotes()
		{
			return _noteRepository.GetAllNotes();
		}

		public async Task<List<Note>> GetCommentsAsync(string comments)
		{
			return await _noteRepository.GetComments(comments);
		}

		public async Task DeleteNote(Note note)
		{
			_noteRepository.DeleteNote(note);
		}

		public Note UpdateNotes(Note comments)
		{
			return _noteRepository.UpdateComments(comments);
		}
	}
}
