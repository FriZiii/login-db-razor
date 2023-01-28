using System.Collections.Generic;

namespace login_db_razor.Models
{
    public class DataBase
    {
        List<User> users;
        string filePath = "db.txt";
        public DataBase() {
            users = read();
        }
        public void AddUser(string firstName, string lastName, string email, string password)
        {
            users.Add(new User(users.Count+1,firstName, lastName, email, password));
        }

		public override string ToString()
		{
            string output = "";
			foreach (var user in users)
			{
				output += user.ToString() + "\n";
			}
            return output;
		}
        public void save()
        {
            List<string> output = new List<string>();
            foreach (var user in users)
            {
				output.Add(user.ToString());
            }
            File.WriteAllLines(filePath, output);
        }

        public List<User> read()
        {
            List<String> lines = File.ReadLines(filePath).ToList();

            List<User> users = new List<User>();
            foreach (var line in lines)
            {
                string[] entries = line.Split(',');

                try
                {
                    int id = Int32.Parse(entries[0]);
                    User newUser = new User(id, entries[1], entries[2], entries[3], entries[4]);
                    users.Add(newUser);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input string is invalid.");
                }
            }
            return users;
        }

        public string getId(int id)
        {
            foreach(var user in users) { 
                if(user.Id == id)
                    return user.ToString();
            }
            return "ERROR";
        }

        public bool login(string email, string password)
        {
            foreach(var user in users)
            {
                if(user.Email.Equals(email))
                {
                    if(user.Password == password)
                        return true;
                }
            }
            return false;
        }
    }
}
