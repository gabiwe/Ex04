using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        public event Action<MenuItem> Chosen;

        private readonly UserInputGetter r_UserInputGetter = new UserInputGetter();
        private readonly string r_Text;
        private List<MenuItem> m_MenuItems;

        public string Text
        {
            get { return r_Text; }
        }

        public List<MenuItem> MenuItems
        {
            get { return m_MenuItems; }
            set { m_MenuItems = value; }
        }

        public MenuItem(string i_Text)
        {
            r_Text = i_Text;
        }

        public void ChosenOccured()
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
            bool continueShow = true;

            while (continueShow)
            {
                Console.Clear();
                Console.WriteLine("{0}", r_Text);
                Console.WriteLine("0. Back");
                for (int i = 1; i <= m_MenuItems.Count; i++)
                {
                    Console.WriteLine("{0}. {1}", i, m_MenuItems[i - 1].Text);
                }

                int intUserInput = r_UserInputGetter.GetUserInput(m_MenuItems.Count);
                if (intUserInput == 0)
                {
                    continueShow = false;
                }
                else
                {
                    handleUserChoice(intUserInput);
                }
            }
        }

        private void handleUserChoice(int i_UserInput)
        {
            MenuItem chosenMenuItem = m_MenuItems[i_UserInput - 1];

            if (chosenMenuItem.MenuItems == null)
            {
                chosenMenuItem.OnChosen(this);
            }
            else
            {
                chosenMenuItem.show();
            }
        }

        protected virtual void OnChosen(MenuItem i_MenuItem)
        {
            Chosen?.Invoke(i_MenuItem);
        }
    }
}
