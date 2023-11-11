namespace EFTest.Models;

public class Note
{
	public int NoteId { get; set; }
	public string? Comments { get; set; }

	public Note()
	{

	}

	public Note(int noteId, string? comments)
    {
        this.NoteId = noteId;
		this.Comments = comments;
    }
}
