using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneCafeRepo
{
    public class CafeMenu
    {
        public int  MealNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }

        public CafeMenu(int mealNumber, string name, string description, string ingredients, double price) 
        {
            MealNumber = mealNumber;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }

        public CafeMenu()
        {
        }
    }
}
