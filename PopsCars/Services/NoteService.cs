using EFTest;
using EFTest.Models;
using PopsCarsSite.Common.Models;

namespace PopsCars
{
	public class NoteService : INoteService

	{
		private readonly INoteRepository _noteRepository;


		public NoteService(INoteRepository noteRepository)
		{
			_noteRepository = noteRepository;
		}

		public async Task<CommonResponse<bool>> AddNote(Note note)
		{
			var retVal = new CommonResponse<bool>();

			try
			{
				retVal.Value = await _noteRepository.Add(note);
			}

			catch (Exception ex) 
			{ 
				retVal.SetExceptionAsync(ex);
			}
			return retVal;
		}

		public async Task<List<Note>> MainSearch(string search)
		{
            List<Note> noteList = _noteRepository.GetAll().ToList();
            string[] searchOptions = search.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var searchResults = noteList.Where(c =>
                searchOptions.All(term => c.Comments.ToString().Contains(term, StringComparison.InvariantCultureIgnoreCase))
            ).ToList();

            return searchResults;
            
        }

		public async Task<CommonResponse<List<Note>>> GetNotes()
		{
			var noteList = new CommonResponse<List<Note>>();

			try 
			{ 
			
			}
			return _noteRepository.GetAll().ToList();
		}

		public async Task<List<Note>> GetNoteById(int userId)
		{
			List<Note> noteList = _noteRepository.GetAll().ToList();
			var usersNotes = noteList.Where(c => c.UserId == userId).ToList();
			return usersNotes;
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
