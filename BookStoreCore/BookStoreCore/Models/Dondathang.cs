using System;
using System.Collections.Generic;

namespace BookStoreCore.Models;

public partial class Dondathang
{
    public int MaDonHang { get; set; }

    public string? Dathanhtoan { get; set; }

    public string Tinhtranggiaohang { get; set; } = null!;

    public string Ngaydat { get; set; } = null!;

    public string? Ngaygiao { get; set; }

    public int MaKh { get; set; }

    public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; } = new List<Chitietdonhang>();

    public virtual Khachhang MaKhNavigation { get; set; } = null!;
}
