﻿using EFTest.Models;
using PopsCarsSite.Common.Models;
namespace PopsCars;


public interface INoteService 
{
	Task<CommonResponse<bool>> AddNote(Note note);
	Task<CommonResponse<List<Note>>> GetNotes();
	
	Task<CommonResponse<List<Note>>> GetNoteById(int id);	
	Task<CommonResponse<bool>> DeleteNote(Note note);
	Task<CommonResponse<bool>> UpdateNote(Note comments);

	Task<CommonResponse<List<Note>>> MainSearch(string search);
}
