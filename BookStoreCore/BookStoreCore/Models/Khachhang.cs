using System;
using System.Collections.Generic;

namespace BookStoreCore.Models;

public partial class Khachhang
{
    public int MaKh { get; set; }

    public string? HoTen { get; set; }

    public string TaiKhoan { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string? Email { get; set; }

    public string? DiaChiKh { get; set; }

    public int? DienThoaiKh { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public virtual ICollection<Dondathang> Dondathangs { get; set; } = new List<Dondathang>();
}
