using System;
using System.Collections.Generic;

namespace BookStoreCore.Models;

public partial class Chitietdonhang
{
    public int MaDonHang { get; set; }

    public int MaSach { get; set; }

    public int? Soluong { get; set; }

    public decimal? Dongia { get; set; }

    public virtual Dondathang MaDonHangNavigation { get; set; } = null!;

    public virtual Sach MaSachNavigation { get; set; } = null!;
}
