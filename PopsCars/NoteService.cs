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

		public async Task AddNote(Note note)
		{
			await _noteRepository.Add(note);
		}

		public async Task<List<Note>> GetNotes()
		{
			return _noteRepository.GetAll().ToList();
		}

		public async Task DeleteNote(Note note)
		{
			await _noteRepository.Delete(note);
		}

		public async Task UpdateNote(Note comments)
		{
			await _noteRepository.UpdateAsync(comments);
		}

		
	}
}
