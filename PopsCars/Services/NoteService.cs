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

		public async Task<CommonResponse<Note>> AddNote(Note note)
		{
			var retVal = new CommonResponse<Note>();

			try
			{
				retVal= await _noteRepository.Add(note);
			}

			catch (Exception ex) 
			{ 
				await retVal.SetExceptionAsync(ex);
			}
			return retVal;
		}

		public async Task<CommonResponse<List<Note>>> MainSearch(string search)
		{
			var searchResults = new CommonResponse<List<Note>>();

			try
			{
				List<Note> noteList = _noteRepository.GetAll().ToList();
				string[] searchOptions = search.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

				searchResults.Value = noteList.Where(c =>
					searchOptions.All(term => c.Comments.ToString().Contains(term, StringComparison.InvariantCultureIgnoreCase))
				).ToList();
			}
			catch (Exception ex)
			{
				searchResults.SetExceptionAsync(ex);
			}

            return searchResults;
            
        }

		public async Task<CommonResponse<List<Note>>> GetNotes()
		{
			var noteList = new CommonResponse<List<Note>>();

			try 
			{
				noteList.Value = _noteRepository.GetAll().ToList();
			}

			catch (Exception ex)
			{
				await noteList.SetExceptionAsync(ex);
			}
			
			return noteList;
		}

		public async Task<CommonResponse<List<Note>>> GetNoteById(int userId)
		{
			var usersNotes = new CommonResponse<List<Note>>();
			try
			{
				List<Note> noteList = _noteRepository.GetAll().ToList();
				usersNotes.Value = noteList.Where(c => c.UserId == userId).ToList();

			}

			catch (Exception ex)
			{
			   await usersNotes.SetExceptionAsync(ex);
			}
			return usersNotes;
			
		}
		public async Task<CommonResponse<bool>> DeleteNote(Note note)
		{
			var returnVal = new CommonResponse<bool>();
			try
			{
				returnVal = await _noteRepository.Delete(note);
			}

			catch (Exception ex)
			{
				await returnVal.SetExceptionAsync(ex);
			}
			return returnVal;
		}

		public async Task<CommonResponse<Note>> UpdateNote(Note comments)
		{
			var returnVal = new CommonResponse<Note>();

			try
			{
				returnVal = await _noteRepository.UpdateAsync(comments);
			}
			
			catch (Exception ex)
			{
				await returnVal.SetExceptionAsync(ex);
			}
				
			return returnVal;
		}

		
	}
}
