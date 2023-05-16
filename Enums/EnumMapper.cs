using System;
namespace PhoneBook.Enums
{
	public static class TypeCriteriaMapper
	{
        public static MenuOrder ReadMenuOrder(string input)
        {
           
            if (!Enum.TryParse(input, out MenuOrder menuOption))
            {
                menuOption = MenuOrder.Ascending;
            }

            return menuOption;
        }

        public static CriteriaOrder ReadOrderCreteria(string input)
        {
            if (!Enum.TryParse(input, out CriteriaOrder menuOption))
            {
                menuOption = CriteriaOrder.Name;
            }

            return menuOption;
        }

    }
}

