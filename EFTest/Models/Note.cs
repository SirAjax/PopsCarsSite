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

	public Note(int noteId, int userId, int carId, string? comments)
    {
        this.NoteId = noteId;
		this.UserId = userId;
		this.CarId = carId;
		this.Comments = comments;
    }
}
