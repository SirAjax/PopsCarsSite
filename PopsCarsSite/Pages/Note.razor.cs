using Microsoft.AspNetCore.Components;
using PopsCars;

namespace PopsCarsSite.Pages
{
	public class NoteComponent : ComponentBase
	{
		protected List<EFTest.Models.Note> ListOfNotes = new();
		protected string? search;
		protected EFTest.Models.Note? newNote = new();
		protected EFTest.Models.Note? noteToDelete = new();

		[Inject]
		private INoteService _noteservice { get; set; } = default!;


		protected override async Task OnInitializedAsync()
		{
			await PopulateList();
		}

		protected async Task PopulateList()
		{
			ListOfNotes =  _noteservice.GetNotes();
			newNote = new();
		}

		
		
		protected async Task CreateNote()
		{
			await _noteservice.CreateNote(newNote);
			await PopulateList();
		}
		protected async Task DeleteNote(Note noteToDelete)
		{
			var noteList = _noteservice.GetNotes().ToList();
			var actualNoteToDelete = noteList.FirstOrDefault();
			if (actualNoteToDelete != null)
			{
				await _noteservice.DeleteNote(actualNoteToDelete);
				await PopulateList();
			}

			


		}
	}

}

