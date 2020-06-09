using System;

namespace Ex04.Menus.Interfaces
{
    public class UserInputGetter
    {
        public int GetUserInput(int i_MaxInput)
        {
            bool isInputValid = false;
            int intUserInput = default;

            while (!isInputValid)
            {
                Console.WriteLine("Please choose an index of one of the options above: ");
                string userInput = Console.ReadLine();
                isInputValid = int.TryParse(userInput, out intUserInput) &&
                               intUserInput <= i_MaxInput && intUserInput >= 0;
            }

            return intUserInput;
        }
    }
}
