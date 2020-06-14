using System.Collections.Generic;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class InterfacesMenuCreator
    {
        public static List<MenuItem> BuildMenuItemsWithInterfaces()
        {
            MenuItem menuItemVersionsAndDigits = new MenuItem("Versions and Digits");
            MenuItem menuItemCountCapitals = new MenuItem("Count Capitals");
            MenuItem menuItemShowVersion = new MenuItem("Show Version");

            menuItemVersionsAndDigits.MenuItems = new List<MenuItem>()
            {
                menuItemCountCapitals,
                menuItemShowVersion
            };

            menuItemCountCapitals.StartableItems = new List<IStartable> { new CapitalLettersCounter() };
            menuItemShowVersion.StartableItems = new List<IStartable> { new VersionProvider() };

            MenuItem menuItemShowDateOrTime = new MenuItem("Show Date/Time");
            MenuItem menuItemShowTime = new MenuItem("Show Time");
            MenuItem menuItemShowDate = new MenuItem("Show Date");

            menuItemShowDateOrTime.MenuItems = new List<MenuItem>
            {
                menuItemShowTime,
                menuItemShowDate
            };

            menuItemShowTime.StartableItems = new List<IStartable> { new TimeProvider() };
            menuItemShowDate.StartableItems = new List<IStartable> { new DateProvider() };

            List<MenuItem> menuItems = new List<MenuItem>()
            {
                menuItemVersionsAndDigits,
                menuItemShowDateOrTime
            };

            return menuItems;
        }
    }
}