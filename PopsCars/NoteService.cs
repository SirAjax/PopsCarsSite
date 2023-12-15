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

		public async Task<bool> AddNote(Note note)
		{
			return await _noteRepository.Add(note);
		}

		public async Task<List<Note>> GetNotes()
		{
			return _noteRepository.GetAll().ToList();
		}

		public async Task<bool> DeleteNote(Note note)
		{
			return await _noteRepository.Delete(note);
		}

		public async Task<bool> UpdateNote(Note comments)
		{
			return await _noteRepository.UpdateAsync(comments);
		}

		
	}
}
