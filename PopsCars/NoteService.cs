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

		public async Task<bool> CreateNote(Note note)
		{
			return _noteRepository.Add(note);
		}

		public List<Note> GetNotes()
		{
			return _noteRepository.GetAll().ToList();
		}

		public async Task DeleteNote(Note note)
		{
			_noteRepository.Delete(note);
		}

		public Task<bool> UpdateNotes(Note comments)
		{
			return _noteRepository.UpdateAsync(comments);
		}

		
	}
}
