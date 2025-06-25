using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFood_ConsoleApp
{
    internal class Food
    {
        public int FoodId { get; set; }

        public string FoodName { get; set; } = null!;

        public string Status { get; set; } = null!;

        public double Price { get; set; }

        public int CategoryId { get; set; }
    
        public virtual FoodCategory Category { get; set; } = null!;
    }
}
