using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private readonly List<MenuItem> r_MenuItems;
        private readonly string r_Title;
        private readonly UserInputGetter r_UserInputGetter = new UserInputGetter();

        public MainMenu(List<MenuItem> i_MenuItems, string i_Title)
        {
            r_MenuItems = i_MenuItems;
            r_Title = i_Title;
        }

        public void Show()
        {
            bool quit = false;
            while (!quit)
            {
                Console.Clear();
                Console.WriteLine("{0}", r_Title);
                Console.WriteLine("0. Exit");
                for (int i = 1; i <= r_MenuItems.Count; i++)
                {
                    Console.WriteLine("{0}. {1}", i, r_MenuItems[i - 1].Text);
                }

                int intUserInput = r_UserInputGetter.GetUserInput(r_MenuItems.Count);
                if (intUserInput == 0)
                {
                    Console.WriteLine("Bye bye!");
                    quit = true;
                }
                else
                {
                    r_MenuItems[intUserInput - 1].ChosenOccured();
                }
            }
        }
    }
}
