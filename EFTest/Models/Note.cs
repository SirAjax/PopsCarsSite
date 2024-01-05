namespace EFTest.Models;

public class Note
{
	public int NoteId { get; set; }
	public string? Comments { get; set; }

	public int? UserId { get; set; }

	public int? CarId { get; set; }
	public Note()
	{

	}

	public Note(int noteId, int UserId, int CarId, string? comments)
    {
        this.NoteId = noteId;
		this.UserId = UserId;
		this.CarId = CarId;
		this.Comments = comments;
    }
}
