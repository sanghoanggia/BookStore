using System;
using System.Collections.Generic;

namespace BookStoreCore.Models;

public partial class Vietsach
{
    public int MaTg { get; set; }

    public int Masach { get; set; }

    public string? Vaitro { get; set; }

    public string? Vitri { get; set; }

    public virtual Tacgium MaTgNavigation { get; set; } = null!;

    public virtual Sach MasachNavigation { get; set; } = null!;
}
