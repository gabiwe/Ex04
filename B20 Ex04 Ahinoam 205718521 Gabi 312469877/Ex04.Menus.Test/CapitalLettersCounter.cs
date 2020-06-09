using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class CapitalLettersCounter : IStartable
    {
        public void Start()
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
            Console.WriteLine("Enter any key to continue...");
            Console.ReadKey();
        }
    }
}
