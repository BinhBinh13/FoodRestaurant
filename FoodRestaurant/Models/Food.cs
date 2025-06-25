using System;
using System.Collections.Generic;

namespace FoodRestaurant.Models;

public partial class Food
{
    public int FoodId { get; set; }

    public string FoodName { get; set; } = null!;

    public string Status { get; set; } = null!;

    public double Price { get; set; }

    public int CategoryId { get; set; }

    public virtual ICollection<BillInfo> BillInfos { get; set; } = new List<BillInfo>();

    public virtual FoodCategory Category { get; set; } = null!;
}
