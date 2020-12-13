using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneCafeRepo
{
    public class CafeMenuRepo
    {
        private List<CafeMenu> _listOfMenuItems = new List<CafeMenu>();

        //create
        public void AddNewMenuItem(CafeMenu item)
        {
            _listOfMenuItems.Add(item);
        }
        //read
        public List<CafeMenu> SeeMenu()
        {
            return _listOfMenuItems;
        }
        //update
        public bool UpdateMenuItem(int originalMenuItem, CafeMenu newMenuItem)
        {
            CafeMenu oldMenuItem = GetItemByNumber(originalMenuItem);

            if (oldMenuItem != null) 
            {
                oldMenuItem.MealNumber = newMenuItem.MealNumber;
                oldMenuItem.Name = newMenuItem.Name;
                oldMenuItem.Description = newMenuItem.Description;
                oldMenuItem.Ingredients = newMenuItem.Ingredients;
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
            CafeMenu item = GetItemByNumber(number);

            if (item == null)
            {
                return false;
            }
            int initialCount = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(item);

            if (initialCount >_listOfMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //helper method
        public CafeMenu GetItemByNumber(int number)
        {
            foreach(CafeMenu item in _listOfMenuItems)
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
