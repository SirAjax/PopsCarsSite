using EFTest.Models;
using Microsoft.AspNetCore.Components;
using PopsCars;

namespace PopsCarsSite.Pages
{
    public class NoteComponent : ComponentBase
    {
        protected List<Note> ListOfNotes = new();
        protected string? search;
        protected Note? newNote = new();
        protected Note? noteToDelete = new();

        [Inject]
        private INoteService _noteservice { get; set; } = default!;


        protected override async Task OnInitializedAsync()
        {
            await PopulateList();
        }

        protected async Task PopulateList()
        {
            ListOfNotes = _noteservice.GetNotes();
            newNote = new();
        }



        protected async Task AddNote()
        {
            await _noteservice.AddNote(newNote);
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

