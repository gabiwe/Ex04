using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class DateProvider : IStartable
    {
        public void Start()
        {
            Console.WriteLine("Date: {0}/{1}/{2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            Console.WriteLine("Enter any key to continue...");
            Console.ReadKey();
        }
    }
}
