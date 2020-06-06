using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        public event Action<MenuItem> Chosen;
        public event Action<MenuItem> ReturnedBack; 
        private readonly string r_Text;
        private List<MenuItem> m_MenuItems;

        public string Text
        {
            get { return r_Text; }
        }

        public List<MenuItem> MenuItems
        {
            set
            {
                m_MenuItems = value;
                foreach (MenuItem menuItem in m_MenuItems)
                {
                    menuItem.ReturnedBack += this.MenuItem_ReturnedBack;
                }
            }
        }

        private void MenuItem_ReturnedBack(MenuItem obj)
        {
            show();
        }

        public MenuItem(string i_Text)
        {
            r_Text = i_Text;
        }

        //TODO
        public void AMethodChooseMe()
        {
            if (m_MenuItems == null) 
            {
                OnChosen(this);
            }
            else
            {
                show();
            }
        }

        private void show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("{0}", r_Text);
                Console.WriteLine("0. Back");
                for (int i = 1; i <= m_MenuItems.Count; i++)
                {
                    Console.WriteLine("{0}. {1}", i, m_MenuItems[i - 1].Text);
                }

                Console.WriteLine("Please choose an index of one of the options above: ");
                string userInput = Console.ReadLine();
                if (userInput == "0")
                {
                   OnReturnedBack(this); 
                }

                // validation
                int.TryParse(userInput, out int intUserInput);
                if (m_MenuItems == null)
                {
                    AMethodChooseMe();
                }
                else
                {
                    m_MenuItems[intUserInput - 1].AMethodChooseMe();
                }
            }
        }

        protected virtual void OnChosen(MenuItem i_MenuItem)
        {
            Chosen?.Invoke(i_MenuItem);
        }

        protected virtual void OnReturnedBack(MenuItem i_MenuItem)
        {
            ReturnedBack?.Invoke(i_MenuItem);
        }
    }
}
