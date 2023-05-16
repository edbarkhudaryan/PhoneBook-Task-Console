using System;
using System.Collections.Generic;
using System.IO;
using PhoneBook.Enums;

namespace PhoneBook
{
	public interface IPersonContactService
	{
		public void FindALlPersonContact(MenuOrder menuOrder, CriteriaOrder criteria,List<Contact> contacts);
		public  List<Contact> ImportPersonContacts(string filePath);

    }
}

