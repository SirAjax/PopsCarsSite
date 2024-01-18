using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFTest.Models;

public class Note
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	public string? Comments { get; set; }

	public int? UserId { get; set; }

	public int? CarId { get; set; }
	public Note()
	{

	}

	public Note(int noteId, int userId, int carId, string? comments)
    {
        this.Id = noteId;
		this.UserId = userId;
		this.CarId = carId;
		this.Comments = comments;
    }
}
