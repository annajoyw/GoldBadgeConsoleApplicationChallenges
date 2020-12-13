using ChallengeOneCafeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneCafeConsole
{
    public class ProgramUI
    {
        private CafeMenuRepo _menuRepo = new CafeMenuRepo();
        public void Run()
        {
            //seedMenuItems
            AppMenu();
        }

        private void AppMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome! Please select one of the following options:\n" +
                    "1. Create new menu item\n" +
                    "2. Update existing menu item\n" +
                    "3. View current Cafe Menu\n" +
                    "4. Delete menu item\n" +
                    "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //create
                        AddNewMenuItem();
                        break;
                    case "2":
                        //update
                        UpdateMenuItem();
                        break;
                    case "3":
                        //view
                        ViewMenu();
                        break;
                    case "4":
                        //delete
                        DeleteMenuItem();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddNewMenuItem()
        {
            Console.Clear();
            CafeMenu newItem = new CafeMenu();

            Console.WriteLine("Please enter meal number");
            string mealNumAsString = Console.ReadLine();
            newItem.MealNumber = int.Parse(mealNumAsString);

            Console.WriteLine("Please enter meal name" );
            newItem.Name = Console.ReadLine();

            Console.WriteLine("Please enter meal description");
            newItem.Description = Console.ReadLine();

            Console.WriteLine("Please enter meal ingredients");
            newItem.Ingredients = Console.ReadLine();

            Console.WriteLine("Please enter meal price");
            string priceAsString = Console.ReadLine();
            newItem.Price = double.Parse(priceAsString);
        }

        private void UpdateMenuItem()
        {
            ViewMenu();
            Console.WriteLine("Pleae enter meal number of the item you wish to update");
            int oldMealNumberAsString = int.Parse(Console.ReadLine());
            CafeMenu newItem = new CafeMenu();

            Console.WriteLine("Please enter meal number");
            string mealNumAsString = Console.ReadLine();
            newItem.MealNumber = int.Parse(mealNumAsString);

            Console.WriteLine("Please enter meal name");
            newItem.Name = Console.ReadLine();

            Console.WriteLine("Please enter meal description");
            newItem.Description = Console.ReadLine();

            Console.WriteLine("Please enter meal ingredients");
            newItem.Ingredients = Console.ReadLine();

            Console.WriteLine("Please enter meal price");
            string priceAsString = Console.ReadLine();
            newItem.Price = double.Parse(priceAsString);

           bool wasUpdated = _menuRepo.UpdateMenuItem(oldMealNumberAsString, newItem);
            if (wasUpdated)
            {
                Console.WriteLine("Menu item was successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not delete item");
            }
        
        }
        private void ViewMenu()
        {
            Console.Clear();
            List<CafeMenu> cafeMenus = _menuRepo.SeeMenu();
            foreach (CafeMenu item in cafeMenus)
            {
                Console.WriteLine($"Meal Number:{item.MealNumber}, Name: {item.Name}, Description: {item.Description}, Ingredients: {item.Ingredients}, Price: {item.Price}");
            }

        }
        private void DeleteMenuItem()
        {
            Console.Clear();
            ViewMenu();
            Console.WriteLine("Please enter the Meal Number of the item you wish to delete");
            int MealNumber = int.Parse(Console.ReadLine());
           bool wasDeleted = _menuRepo.RemoveItemFromMenu(MealNumber);
            if (wasDeleted)
            {
                Console.WriteLine("Item was successfully removed from menu.");
            }
            else
            {
                Console.WriteLine("Item could not be removed");
            }

        }
    }
}
