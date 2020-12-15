using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneCafeRepo
{
    public class CafeMenuRepo
    {
        private List<MenuItem> _menuDirectory = new List<MenuItem>();

        //create
        public void AddItemToDirectory(MenuItem item)
        {
            _menuDirectory.Add(item);
        }
        //read
        public List<MenuItem> SeeMenu()
        {
            return _menuDirectory;
        }
        //update
        public bool UpdateMenuItem(int originalMenuItem, MenuItem newMenuItem)
        {
            MenuItem oldMenuItem = GetItemByNumber(originalMenuItem);

            if (oldMenuItem != null) 
            {
                oldMenuItem.MealNumber = newMenuItem.MealNumber;
                oldMenuItem.Name = newMenuItem.Name;
                oldMenuItem.Description = newMenuItem.Description;
                oldMenuItem.ListOfIngredients = newMenuItem.ListOfIngredients;
                oldMenuItem.Price = newMenuItem.Price;
                return true;
            }
            else
            {
                return false;
            }
        }
        //delete
        public bool RemoveItemFromMenu(int number)
        {
            MenuItem item = GetItemByNumber(number);

            if (item == null)
            {
                return false;
            }
            int initialCount = _menuDirectory.Count;
            _menuDirectory.Remove(item);

            if (initialCount >_menuDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //helper method
        public MenuItem GetItemByNumber(int number)
        {
            foreach(MenuItem item in _menuDirectory)
            {
                if (item.MealNumber == number)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
