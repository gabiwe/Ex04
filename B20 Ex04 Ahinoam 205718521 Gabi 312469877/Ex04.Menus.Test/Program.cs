using System;
using System.Collections.Generic;
using Ex04.Menus.Interfaces;
using MenuItem = Ex04.Menus.Delegates.MenuItem;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            List<Interfaces.MenuItem> menuItems = buildMenuItemsWithInterfaces();
            Interfaces.MainMenu mainMenu = new Interfaces.MainMenu();
            mainMenu.Build(menuItems);
            mainMenu.Show();
        }

        private static List<MenuItem> buildMenuItemsWithDelegates()
        {
            MenuItem menuItemVersionsAndDigits = new MenuItem("Versions and Digits");
            MenuItem menuItemCountCapitals = new MenuItem("Count Capitals");
            MenuItem menuItemShowVersion = new MenuItem("ShowVersion");

            menuItemVersionsAndDigits.MenuItems = new List<MenuItem>()
            {
                menuItemCountCapitals,
                menuItemShowVersion
            };

            menuItemCountCapitals.Chosen += menuItemCountCapitals_Chosen;
            menuItemShowVersion.Chosen += menuItemShowVersion_Chosen;

            MenuItem menuItemShowDateOrTime = new MenuItem("Show Date/Time");
            MenuItem menuItemShowTime = new MenuItem("Show Time");
            MenuItem menuItemShowDate = new MenuItem("Show Date");

            menuItemShowDateOrTime.MenuItems = new List<MenuItem>
            {
                menuItemShowTime,
                menuItemShowDate
            };

            menuItemShowTime.Chosen += menuItemShowTime_Chosen;
            menuItemShowDate.Chosen += menuItemShowDate_Chosen;

            List<MenuItem> menuItems = new List<MenuItem>()
            {
                menuItemVersionsAndDigits,
                menuItemShowDateOrTime
            };

            return menuItems;
        }

        private static List<Interfaces.MenuItem> buildMenuItemsWithInterfaces()
        {
            Interfaces.MenuItem menuItemVersionsAndDigits = new Interfaces.MenuItem("Versions and Digits");
            Interfaces.MenuItem menuItemCountCapitals = new Interfaces.MenuItem("Count Capitals");
            Interfaces.MenuItem menuItemShowVersion = new Interfaces.MenuItem("ShowVersion");

            menuItemVersionsAndDigits.MenuItems = new List<Interfaces.MenuItem>()
            {
                menuItemCountCapitals,
                menuItemShowVersion
            };

            menuItemCountCapitals.StartableItems = new List<IStartable> { new CapitalLettersCounter() };
            menuItemShowVersion.StartableItems = new List<IStartable> { new VersionProvider() };

            Interfaces.MenuItem menuItemShowDateOrTime = new Interfaces.MenuItem("Show Date/Time");
            Interfaces.MenuItem menuItemShowTime = new Interfaces.MenuItem("Show Time");
            Interfaces.MenuItem menuItemShowDate = new Interfaces.MenuItem("Show Date");

            menuItemShowDateOrTime.MenuItems = new List<Interfaces.MenuItem>
            {
                menuItemShowTime,
                menuItemShowDate
            };

            menuItemShowTime.StartableItems = new List<IStartable> { new TimeProvider() };
            menuItemShowDate.StartableItems = new List<IStartable> { new DateProvider() };

            List<Interfaces.MenuItem> menuItems = new List<Interfaces.MenuItem>()
            {
                menuItemVersionsAndDigits,
                menuItemShowDateOrTime
            };

            return menuItems;
        }

        private static void menuItemShowDate_Chosen(MenuItem i_MenuItem)
        {
            Console.WriteLine("Date: {0}/{1}/{2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            printInTheEndOfFunction();
        }

        private static void printInTheEndOfFunction()
        {
            Console.WriteLine("Enter any key to continue...");
            Console.ReadKey();
        }

        private static void menuItemShowTime_Chosen(MenuItem i_MenuItem)
        {
            Console.WriteLine("{0}", DateTime.Now.TimeOfDay);
            printInTheEndOfFunction();
        }

        private static void menuItemShowVersion_Chosen(MenuItem i_MenuItem)
        {
            Console.WriteLine("Version: 20.2.4.30620");
            printInTheEndOfFunction();
        }

        private static void menuItemCountCapitals_Chosen(MenuItem i_MenuItem)
        {
            bool isValid = false;
            string userInput = string.Empty;

            while (!isValid)
            {
                Console.WriteLine("Please enter a sentence: ");
                userInput = Console.ReadLine();
                if (userInput != null && !string.IsNullOrEmpty(userInput))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }

            char[] characters = userInput.ToCharArray();
            int capitalsCount = 0;
            foreach (char character in characters)
            {
                if (char.IsUpper(character))
                {
                    capitalsCount++;
                }
            }

            Console.WriteLine("There are {0} capital letters in this sentence.", capitalsCount);
            printInTheEndOfFunction();
        }
    }
}
