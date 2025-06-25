using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFood_ConsoleApp
{
    internal class FoodCategory
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Food> Foods { get; set; } = new List<Food>();
    }
}
