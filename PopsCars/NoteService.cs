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
			return _noteRepository.Add(note);
		}

		public List<Note> GetNotes()
		{
			return _noteRepository.GetAll().ToList();
		}

		public async Task<bool> DeleteNote(Note note)
		{
			return _noteRepository.Delete(note);
		}

		public Task<bool> UpdateNote(Note comments)
		{
			return _noteRepository.UpdateAsync(comments);
		}

		
	}
}
