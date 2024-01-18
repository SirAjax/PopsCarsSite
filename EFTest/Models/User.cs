using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace EFTest.Models;

public class User
{
	public string? UserName { get; set; }
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int ID { get; set; }




	public ICollection<Car> Cars { get; } = new List<Car>();	

	public User()
    {
		//intentially left blank for CRUD operations
    }
	public User(string userName, int id)
	{
		this.UserName = userName;
		this.ID = id;
	}

	

}