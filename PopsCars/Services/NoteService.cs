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
				retVal = await _noteRepository.Add(note);
			}

			catch (Exception ex)
			{
				await retVal.SetExceptionAsync(ex);
			}
			return retVal;
		}

		public async Task<CommonResponse<List<Note>>> MainSearch(string search)
		{
			var retVal= new CommonResponse<List<Note>>();

			try
			{
				var noteList = await _noteRepository.GetAll();
				string[] searchOptions = search.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

				retVal.Value = noteList.Value.Where(c =>
					searchOptions.All(term => c.Comments.ToString().Contains(term, StringComparison.InvariantCultureIgnoreCase))
				).ToList();
			}
			catch (Exception ex)
			{
				await retVal.SetExceptionAsync(ex);
			}

			return retVal;

		}
		public async Task<CommonResponse<List<Note>>> GetNotes()

		{
			var retVal = new CommonResponse<List<Note>>();

			try
			{
				var noteList = await _noteRepository.GetAll();
				retVal.Value = noteList.Value.ToList();
			}

			catch (Exception ex)
			{
				await retVal.SetExceptionAsync(ex);
			}

			return retVal;
		}

		public async Task<CommonResponse<List<Note>>> GetNoteById(int userId)
		{
			var retVal = new CommonResponse<List<Note>>();
			try
			{
				var noteList = await _noteRepository.GetAll();
				retVal.Value = noteList.Value.Where(c => c.UserId == userId).ToList();
			}

			catch (Exception ex)
			{
				await retVal.SetExceptionAsync(ex);
			}
			return retVal;

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
