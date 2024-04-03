using BookStoreCore.Models;

namespace BookStoreCore.Repository
{
    public interface INhaXuatBanRepository
    {
        Nhaxuatban Add(Nhaxuatban NXB);
		Nhaxuatban Update(Nhaxuatban NXB);
		Nhaxuatban Delete(int maNXB);
		Nhaxuatban GetNXB(int maNXB);

        IEnumerable<Nhaxuatban> GetAllNXB();  

            
    }
}
