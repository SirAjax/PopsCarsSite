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
        protected Note? noteToUpdate = new();

        [Inject]
        private INoteService _noteservice { get; set; } = default!;


        protected override async Task OnInitializedAsync()
        {
            await PopulateList();
        }

        protected async Task PopulateList()
        {
            ListOfNotes = await _noteservice.GetNotes();
            newNote = new();
        }

        protected async Task MainSearch()
        {
            if (string.IsNullOrEmpty(search))
            {
                Console.WriteLine("no search criteria");
            }
            else
            {
                ListOfNotes = await _noteservice.MainSearch(search);
            }
        }

        protected async Task AddNote()
        {
            await _noteservice.AddNote(newNote);
            await PopulateList();
        }
        protected async Task DeleteNote(Note noteToDelete)
        {
            var noteList = await _noteservice.GetNotes();
            var actualNoteToDelete = noteList.FirstOrDefault(c => c.Comments == noteToDelete.Comments);
            if (actualNoteToDelete != null)
            {
                await _noteservice.DeleteNote(actualNoteToDelete);
                await PopulateList();
            }
        }

        protected async Task UpdateNote(Note noteToUpdate)
        {
            await _noteservice.UpdateNote(noteToUpdate);
            await PopulateList();
        }
    }

}

