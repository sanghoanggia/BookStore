using System;
using System.Collections.Generic;

namespace BookStoreCore.Models;

public partial class Nhaxuatban
{
    public int MaNxb { get; set; }

    public string? TenNxb { get; set; }

    public string? DiaChi { get; set; }

    public int? DienThoai { get; set; }

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
}
