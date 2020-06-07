﻿using SQLite;

namespace Shopper.Models
{
	public class User
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Username { get; set; }

		public string Password { get; set; }

		public string Email { get; set; }
	}
}
