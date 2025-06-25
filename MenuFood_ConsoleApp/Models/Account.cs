using System;
using System.Collections.Generic;

namespace MenuFood_ConsoleApp.Models;

public partial class Account
{
    public string Displayname { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Role { get; set; }
}
