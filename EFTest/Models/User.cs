﻿namespace EFTest.Models;

public class User
{
	public string? UserName { get; set; }
	public int Id { get; set; }

	public User()
    {
		//intentially left blank for CRUD operations
    }
	public User(string userName, int id)
	{
		this.UserName = userName;
		this.Id = id;
	}
}