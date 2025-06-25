using System;
using System.Collections.Generic;

namespace FoodRestaurant.Models;

public partial class BillInfo
{
    public int BillInfoId { get; set; }

    public int BillId { get; set; }

    public int FoodId { get; set; }

    public int Count { get; set; }

    public virtual Bill Bill { get; set; } = null!;

    public virtual Food Food { get; set; } = null!;
}
