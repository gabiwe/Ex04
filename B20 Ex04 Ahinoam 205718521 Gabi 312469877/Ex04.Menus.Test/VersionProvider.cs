using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class VersionProvider : IStartable
    {
        public void Start()
        {
            Console.WriteLine("Version: 20.2.4.30620");
            Console.WriteLine("Enter any key to continue...");
            Console.ReadKey();
        }
    }
}
