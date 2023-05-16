using System;
namespace PhoneBook
{
	public class Contact
	{
        public string Name { get; set; }
        public string LastName { get; set; }
		public string Separator { get; set; }

        public string PhoneNumber { get; set; }

        public Contact(string name,string phoneNumber, string separator, string lastName = null)
		{
			this.Name = name;
			this.LastName = lastName;
			this.Separator = separator;
			this.PhoneNumber = phoneNumber;
		}

        public override string ToString()
        {
            return " " + Name + " " + LastName+ " "+ Separator+ " "+ PhoneNumber;
        }
    }
}

