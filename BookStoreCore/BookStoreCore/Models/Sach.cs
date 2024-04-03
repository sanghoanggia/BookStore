using System;
using System.Collections.Generic;

namespace BookStoreCore.Models;

public partial class Sach
{
    public int Masach { get; set; }

    public string Tensach { get; set; } = null!;

    public decimal? Giaban { get; set; }

    public string? Mota { get; set; }

    public string? Anhbia { get; set; }

    public DateOnly? Ngaycapnhap { get; set; }

    public int? Soluongton { get; set; }

    public int? MaCd { get; set; }

    public int? MaNxb { get; set; }

    public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; } = new List<Chitietdonhang>();

    public virtual Chude? MaCdNavigation { get; set; }

    public virtual Nhaxuatban? MaNxbNavigation { get; set; }

    public virtual ICollection<Vietsach> Vietsaches { get; set; } = new List<Vietsach>();
}
