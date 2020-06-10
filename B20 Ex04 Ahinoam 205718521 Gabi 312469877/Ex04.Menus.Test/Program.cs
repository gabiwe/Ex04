using System.Collections.Generic;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            List<Interfaces.MenuItem> menuItemsWithInterfaces = InterfacesMenuCreator.BuildMenuItemsWithInterfaces();
            Interfaces.MainMenu mainMenuWithInterfaces = new Interfaces.MainMenu();
            mainMenuWithInterfaces.Build(menuItemsWithInterfaces);
            mainMenuWithInterfaces.Title = "Main Menu With Interfaces!";
            mainMenuWithInterfaces.Show();

            List<Delegates.MenuItem> menuItemsWithDelegates = DelegatesMenuCreator.BuildMenuItemsWithDelegates();
            Delegates.MainMenu mainMenuWithDelegates = new Delegates.MainMenu();
            mainMenuWithDelegates.Build(menuItemsWithDelegates);
            mainMenuWithDelegates.Title = "Main Menu With Delegates!";
            mainMenuWithDelegates.Show();
        }
    }
}
