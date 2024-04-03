using BookStoreCore.Models;

namespace BookStoreCore.Repository
{
    public interface IChuDeRepository
    {
        Chude Add(Chude chuDe);
        Chude Update(Chude chuDe);
        Chude Delete(int maChuDe);
        Chude GetChuDe(int maChuDe);

        IEnumerable<Chude> GetAllChuDe();  

            
    }
}
