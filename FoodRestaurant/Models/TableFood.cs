using System;
using System.Collections.Generic;

namespace FoodRestaurant.Models;

public partial class TableFood
{
    public int TableId { get; set; }

    public string TableName { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
}
