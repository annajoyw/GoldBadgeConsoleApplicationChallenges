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
            SeedData();
            AppMenu();
        }
        private void SeedData()
        {
            var cookie = new MenuItem(1, "Chocolate Chip Cookie", "Delicious fresh baked cookie", new List<string> { "chocolate chips", "butter", "sugar", "brown sugar", "egg", "flour", "baking powder" }, 1.99);
            _menuRepo.AddItemToDirectory(cookie);
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
                        Console.WriteLine("Goodbye! Have a wonderful day :-)");
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
            MenuItem newItem = new MenuItem();

            Console.WriteLine("Please enter meal number");
            string mealNumAsString = Console.ReadLine();
            newItem.MealNumber = int.Parse(mealNumAsString);

            Console.WriteLine("Please enter meal name" );
            newItem.Name = Console.ReadLine();

            Console.WriteLine("Please enter meal description");
            newItem.Description = Console.ReadLine();

            Console.WriteLine("Enter meal ingredients (please separate each ingredient with a comma)");
            List<string> listOfIngredientsAsString = Console.ReadLine().Split(',').ToList();
            newItem.AddIngredientsToList(listOfIngredientsAsString);

            Console.WriteLine("Please enter meal price(enter price as decimal ex. 2.99 or 10.00)");
            string priceAsString = Console.ReadLine();
            newItem.Price = double.Parse(priceAsString);
            _menuRepo.AddItemToDirectory(newItem);
        }

        private void UpdateMenuItem()
        {
            ViewMenu();
            Console.WriteLine("Pleae enter meal number of the item you wish to update");
            int mealNumber = int.Parse(Console.ReadLine());
            MenuItem mealToUpdate = _menuRepo.GetItemByNumber(mealNumber);
            Console.Clear();
            DisplayMenuItem(mealToUpdate);
            MenuItem newItem = new MenuItem();
            Console.WriteLine("What would you like to update?\n" +
                "1. Meal Number\n" +
                "2. Meal Name\n" +
                "3. Descpription\n" +
                "4. Ingredients\n" +
                "5. Price");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Please enter updated meal number");
                    string mealNumAsString = Console.ReadLine();
                    newItem.MealNumber = int.Parse(mealNumAsString);
                    break;
                case "2":
                    Console.WriteLine("Please enter updated meal name");
                    newItem.Name = Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("Please enter updated meal description");
                    newItem.Description = Console.ReadLine();
                    break;
                case "4":
                    Console.WriteLine("Would you like to add or remove ingredients? Press 'a' to add or 'r' to remove");
                    //string userInput=(Console.ReadLine());
                    //yes/no method also takes in "a" and "r"
                    bool input = GetYesNoAnswer();
                    if (input == true)
                    {
                        Console.WriteLine("Please enter the ingredients you would like to add separeted by a comma");
                        int initialCount = newItem.ListOfIngredients.Count;
                        List<string> listOfIngredientsAsString = Console.ReadLine().Split(',').ToList();
                        //newItem.ListOfIngredients.Add(listOfIngredientsAsString);
                        foreach(var item in listOfIngredientsAsString)
                        {
                            newItem.ListOfIngredients.Add(item);
                        }
                        if (initialCount < newItem.ListOfIngredients.Count)
                        {
                            Console.WriteLine("Hooray! New Ingredients were successfully added");
                        }
                        else
                        {
                            Console.WriteLine("New Ingredients could not be added");
                        }
                    }
                    if(input == false)
                    {
                        Console.WriteLine("Please enter the ingredient you wish to remove from list");
                        string removedIngredient = Console.ReadLine();
                        newItem.ListOfIngredients.Remove(removedIngredient);
                        int initialCount = newItem.ListOfIngredients.Count;
                        if (initialCount > newItem.ListOfIngredients.Count)
                        {
                            Console.WriteLine("Ingredient was successfully deleted");
                        }
                        else
                        {
                            Console.WriteLine("Ingredient was not deleted");
                        }
                    }
                    break;
                case "5":
                    Console.WriteLine("Please enter updated meal price");
                    string priceAsString = Console.ReadLine();
                    newItem.Price = double.Parse(priceAsString);
                    break;
            }
            _menuRepo.UpdateMenuItem(mealNumber, newItem);
            Console.WriteLine("Bravo! Item has been updated.");

        }
        private void ViewMenu()
        {
            Console.Clear();
            List<MenuItem> cafeMenus = _menuRepo.SeeMenu();
            foreach (MenuItem item in cafeMenus)
            {
                Console.WriteLine($"Meal Number:{item.MealNumber}, Name: {item.Name}, Description: {item.Description}, Price: {item.Price}");
                Console.WriteLine("Ingredients:");
                foreach(var ingredient in item.ListOfIngredients)
                {
                    Console.WriteLine($"\t{ingredient}");
                }
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
        private void DisplayMenuItem(MenuItem item)
        {
            Console.WriteLine($"\tMealNumber:{item.MealNumber}");
            Console.WriteLine($"\tMeal Name:{item.Name}");
            Console.WriteLine($"\tDescpription:{item.Description}");
            Console.WriteLine("\tIngredients:");
            foreach(var ingredient in item.ListOfIngredients)
            {
                Console.WriteLine($"\t{ingredient}");
            }
            Console.WriteLine($"\tPrice:{item.Price}");
        }
        private bool GetYesNoAnswer()
        {
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "yes":
                    case "y":
                    case "a":
                        return true;
                    case "no":
                    case "n":
                    case "r":
                        return false;
                }
                Console.WriteLine("Please enter valid input");
            }
        }
        
    }
}
