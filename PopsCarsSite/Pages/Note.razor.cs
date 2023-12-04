using EFTest.Models;
using Microsoft.AspNetCore.Components;
using PopsCars;
using System.Diagnostics.Eventing.Reader;

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
		protected async Task FilterByCommentSearch()
		{
			if (string.IsNullOrEmpty(search))
			{
				Console.WriteLine("no search criteria");
			}
			else
			{
				ListOfNotes = await _noteservice.GetCommentsAsync(search);
			}
		}

	}

}

