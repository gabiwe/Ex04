using System;
using System.Collections.Generic;
using System.Threading;

namespace Ex04.Menus.Delegates
{
    public class Program
    {
        public static void Main()
        {
            var menuItem0 = new MenuItem("Exit");
            var menuItem1 = new MenuItem("Insert car");
            var menuItem11 = new MenuItem("Show def");
            var menuItem10 = new MenuItem("Back");
            
            menuItem1.MenuItems = new List<MenuItem>()
            {
                menuItem11
            };

            var menuItem2 = new MenuItem("Show abc");

            
            menuItem11.MenuItems = new List<MenuItem>()
            {
                new MenuItem("StamMashu")
            };
            menuItem2.Chosen += MenuItem2_Chosen;
            List<MenuItem> menuItems = new List<MenuItem>()
            {
                menuItem1,
                menuItem2
            };

            MainMenu mainMenu = new MainMenu(menuItems, "Welcome!");
            mainMenu.Show();
        }

        private static void MenuItem11_Chosen(MenuItem obj)
        {
            Console.WriteLine("DEF");
            Thread.Sleep(new TimeSpan(0, 0, 3));

        }

        private static void MenuItem2_Chosen(MenuItem obj)
        {
            Console.WriteLine("ABC");
            Thread.Sleep(new TimeSpan(0,0,3));
        }

        private static void MenuItem1_Chosen(MenuItem obj)
        {
            Console.WriteLine("Insert car succeeded!");
            Thread.Sleep(new TimeSpan(0, 0, 3));

        }
    }
}
