using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneCafeRepo
{
    public class MenuItem
    {
        public int  MealNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> ListOfIngredients { get; set; } = new List<string>();
        public double Price { get; set; }

        public MenuItem()
        {

        }
        public MenuItem(int mealNumber, string name, string description, List<string> listOfIngredients, double price) 
        {
            MealNumber = mealNumber;
            Name = name;
            Description = description;
            ListOfIngredients = listOfIngredients;
            Price = price;
        }
        public void AddIngredientsToList(List<string> ingredientToAdd)
        {
            MenuItem item = new MenuItem();
            item.ListOfIngredients = new List<string>();
            item.ListOfIngredients.AddRange(ingredientToAdd);
        }
    }
}
