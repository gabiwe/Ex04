using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private readonly List<MenuItem> r_MenuItems;
        private readonly string r_Title;

        public MainMenu(List<MenuItem> i_MenuItems, string i_Title)
        {
            r_MenuItems = i_MenuItems;
            foreach (MenuItem menuItem in r_MenuItems)
            {
                menuItem.ReturnedBack += MenuItem_ReturnedBack;
            }
            r_Title = i_Title;
        }

        private void MenuItem_ReturnedBack(MenuItem obj)
        {
            Show();
        }

        public void Show()
        {
            bool quit = false;
            while (!quit)
            {
                Console.Clear();
                Console.WriteLine("{0}", r_Title);
                // need to be an item
                Console.WriteLine("0. Exit");
                for (int i = 1; i <= r_MenuItems.Count; i++)
                {
                    Console.WriteLine("{0}. {1}", i, r_MenuItems[i - 1].Text);
                }

                Console.WriteLine("Please choose an index of one of the options above: ");
                string userInput = Console.ReadLine();
                if (userInput == "0")
                {
                    quit = true;
                }

                //validation
                int.TryParse(userInput, out int intUserInput);
                r_MenuItems[intUserInput - 1].AMethodChooseMe();
            }
        }
    }
}
