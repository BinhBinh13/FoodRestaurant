using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuFood_ConsoleApp.Models;
namespace MenuFood_ConsoleApp
{
    internal class FoodManagement
    {
        private FoodRestaurantContext context = new FoodRestaurantContext();
        public void PrintListFood()
        {
            List<Food> foods = context.Foods.ToList();
            Console.WriteLine("Food Name | Price | CategoryName");
        }
    
    }
}
