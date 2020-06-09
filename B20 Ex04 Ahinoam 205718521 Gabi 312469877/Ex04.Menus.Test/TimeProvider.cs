using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class TimeProvider : IStartable
    {
        public void Start()
        {
            Console.WriteLine("{0}", DateTime.Now.TimeOfDay);
            Console.WriteLine("Enter any key to continue...");
            Console.ReadKey();
        }
    }
}
