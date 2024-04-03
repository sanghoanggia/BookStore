using System;
using System.Collections.Generic;

namespace BookStoreCore.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? HoTen { get; set; }
}
