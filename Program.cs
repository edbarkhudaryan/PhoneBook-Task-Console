using System;
using System.Collections.Generic;
using System.Numerics;
using PhoneBook.Enums;
using PhoneBook.Utils;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello your PhoneBook");

            Console.WriteLine("Find the files here: PhoneBook.txt}");



            //string filePath = @"C:\path\to\your\file.txt";

            string filePath= Console.ReadLine();
            //  string[] lines = ReadAllLinesFromFile(filePath);

            var path=  PathUtil.GetFilePath("PhoneBook.txt");
            PersonContactService personContact = new PersonContactService();
            var contact=   personContact.ImportPersonContacts(path);

     
            MenuOrder();
            string menuType = Console.ReadLine();

            MenuOrder menuOrder = TypeCriteriaMapper.ReadMenuOrder(menuType[0].ToString().ToUpper()+ menuType.Substring(1).ToLower());


            Criteria();

            string criteriaType = Console.ReadLine();
            CriteriaOrder criteriaOrder = TypeCriteriaMapper.ReadOrderCreteria(criteriaType[0].ToString().ToUpper()+ criteriaType.Substring(1).ToLower());
 

            personContact.FindALlPersonContact(menuOrder: menuOrder, criteria: criteriaOrder, contacts: contact);
            Console.ReadLine();
        }

        private static void MenuOrder()
        {
            Console.WriteLine("Please choose an ordering to sort: “Ascending” or “Descending");

          
        }

        private static void Criteria()
        {
            Console.WriteLine("Please choose criteria: “Name”, “Surname” or “PhoneNumberCode");
        }

    }
}

