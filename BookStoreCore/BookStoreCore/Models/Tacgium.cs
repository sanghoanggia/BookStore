using System;
using System.Collections.Generic;

namespace BookStoreCore.Models;

public partial class Tacgium
{
    public int MaTg { get; set; }

    public string TenTg { get; set; } = null!;

    public string? DiaChi { get; set; }

    public string? TieuSu { get; set; }

    public int? DienThoai { get; set; }

    public virtual ICollection<Vietsach> Vietsaches { get; set; } = new List<Vietsach>();
}
