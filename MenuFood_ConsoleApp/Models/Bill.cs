using System;
using System.Collections.Generic;

namespace MenuFood_ConsoleApp.Models;

public partial class Bill
{
    public int BillId { get; set; }

    public DateTime DateCheckIn { get; set; }

    public DateTime? DateCheckOut { get; set; }

    public int TableId { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<BillInfo> BillInfos { get; set; } = new List<BillInfo>();

    public virtual TableFood Table { get; set; } = null!;
}
