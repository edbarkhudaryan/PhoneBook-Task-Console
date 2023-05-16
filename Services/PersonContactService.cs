using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PhoneBook.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace PhoneBook
{
	public class PersonContactService:IPersonContactService
    {

		public PersonContactService()
		{
		}

        public void FindALlPersonContact(MenuOrder menuOrder, CriteriaOrder criteria,List<Contact> contacts)
        {

            var orderBy = menuOrder.ToString() == "Ascending" ? MenuOrder.Ascending : MenuOrder.Descending;


            List<Contact> sortedList = new List<Contact>();
            switch (criteria)
            {
                case CriteriaOrder.Name:
                    {
                         sortedList = orderBy.Equals(MenuOrder.Ascending) ? contacts.OrderBy(x => x.Name).ToList() : contacts.OrderByDescending(x => x.Name).ToList();
                        break;
                    }

                case CriteriaOrder.Surname:
                    {
                         sortedList = orderBy.Equals(MenuOrder.Ascending) ? contacts.OrderBy(x => x.LastName).ToList() : contacts.OrderByDescending(x => x.LastName).ToList();
                        break;
                    }

                case CriteriaOrder.Phonenumbercode:
                    {
                         sortedList = orderBy.Equals(MenuOrder.Ascending) ? contacts.OrderBy(x => x.PhoneNumber).ToList() : contacts.OrderByDescending(x => x.PhoneNumber).ToList();
                        break;
                    }
            }


            for (int i = 0; i < sortedList.Count; i++)
            {
                Console.WriteLine(sortedList[i]);
         
            }

            ValidateFile(sortedList);

         
        }
        public List<Contact> ImportPersonContacts(string filePath)
        {
          
            List<Contact> contacts = new List<Contact>();

            List<string> separatingStrings = new List<string>{ "{", "}" };
            List<string> elements = File.ReadAllLines(filePath).ToList();


            for (int i = 0; i < elements.Count; i++)
            {
                string[] splitResult = elements[i].Split(separatingStrings.ToArray(), System.StringSplitOptions.RemoveEmptyEntries);
                contacts.Add(new PhoneBook.Contact(name: splitResult[0], lastName: splitResult[1], separator: splitResult[2], phoneNumber: splitResult[3] ));

            }

            return contacts;
        }

        public static void ValidateFile(List<Contact> contacts)
        {

            string ValidMessagePhoneNumber=null;
            string ValidMessageSeparator=null;


            for (int i = 0; i < contacts.Count; i++)
            {

                if ((!contacts[i].Separator.Equals(":") || contacts[i].Separator.Equals("-"))&&(contacts[i].Separator.Equals(":") || !contacts[i].Separator.Equals("-")))
                {
                    ValidMessageSeparator = ", the separator should be `:` or `-`.";
                }
                if (contacts[i].PhoneNumber.Length != 9)
                {
                    ValidMessagePhoneNumber = "phone number should be 9 digits";
                }

                Console.WriteLine("Validation:");
                Console.WriteLine($"Line {i+1}: {ValidMessagePhoneNumber} {ValidMessageSeparator} ");

                ValidMessagePhoneNumber = null;
                ValidMessageSeparator = null;
                
            }
        }


    }
}

