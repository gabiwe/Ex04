using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private readonly UserInputGetter r_UserInputGetter = new UserInputGetter();
        private List<MenuItem> m_MenuItems;
        private string m_Title;

        public string Title
        {
            set { m_Title = value; }
        }

        public void Build(List<MenuItem> i_MenuItems)
        {
            m_MenuItems = i_MenuItems;
        }

        public void Show()
        {
            bool quit = false;
            while (!quit)
            {
                Console.Clear();
                Console.WriteLine("{0}", m_Title);
                Console.WriteLine("0. Exit");
                for (int i = 1; i <= m_MenuItems.Count; i++)
                {
                    Console.WriteLine("{0}. {1}", i, m_MenuItems[i - 1].Text);
                }

                int intUserInput = r_UserInputGetter.GetUserInput(m_MenuItems.Count);
                if (intUserInput == 0)
                {
                    Console.WriteLine("Bye bye!");
                    quit = true;
                }
                else
                {
                    m_MenuItems[intUserInput - 1].ChosenOccured();
                }
            }
        }
    }
}
