using Microsoft.Identity.Client;
using System.Drawing;

namespace EFTest.Models;

public class User
{
	public string? UserName { get; set; }
	public int ID { get; set; }

	public int CarId { get; set; }

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