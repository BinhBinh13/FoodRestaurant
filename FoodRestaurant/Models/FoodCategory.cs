using System;
using System.Collections.Generic;

namespace FoodRestaurant.Models;

public partial class FoodCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Food> Foods { get; set; } = new List<Food>();
}
