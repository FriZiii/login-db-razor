namespace login_db_razor.Models
{
	public class User
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		
		public User(int id, string firstName, string lastName, string email, string password)
		{
            Id = id;
            FirstName = firstName;
			LastName = lastName;
			Email = email;
			Password = password;
		}

		public override string ToString()
		{
			return Id + "," + FirstName + "," + LastName + "," + Email + "," + Password;
		}
	}
}
