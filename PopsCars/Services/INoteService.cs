﻿using EFTest.Models;

namespace PopsCars;


public interface INoteService 
{
	Task<bool> AddNote(Note note);
	Task <List<Note>> GetNotes();
	
	Task<List<Note>> GetNoteById(int id);	
	Task<bool> DeleteNote(Note note);
	Task<bool> UpdateNote(Note comments);

	Task<List<Note>> MainSearch(string search);
}
