using System.ComponentModel.DataAnnotations;

namespace BookStoreCore.Models.API
{
    public class CartItem
    {/*
        public int? MaDH { get; set; } = null!;*/
		[Key]	
        public int? MaSach { get; set; } = null!;
		public string TenSach { get; set; } = null!;
		public string? Anh { get; set; }
		public int SoLuong { get; set; } 
        public decimal  DonGia { get; set; }

        public decimal ThanhTien  => SoLuong * DonGia;

		public CartItem()
		{

		}

	}	
  
}
