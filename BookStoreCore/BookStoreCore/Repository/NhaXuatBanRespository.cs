using BookStoreCore.Models;
namespace BookStoreCore.Repository
{
    public class NhaXuatBanRespository : INhaXuatBanRepository
    {
        private  readonly QlbookstoreContext _context;
        public NhaXuatBanRespository(QlbookstoreContext context)
        {
            _context = context;
        }
        public Nhaxuatban Add(Nhaxuatban NXB)
        {
            _context.Nhaxuatbans.Add(NXB);  
            _context.SaveChanges();
            return NXB;
        }

        public Nhaxuatban Delete(int maNXB)
        {
            throw new NotImplementedException();
        }

  
        public IEnumerable<Nhaxuatban> GetAllNXB()
        {
            return _context.Nhaxuatbans;
        }
    

        public Nhaxuatban GetNXB(int maNXB)
        {
           
            return _context.Nhaxuatbans.Find(maNXB);
        }

        public Nhaxuatban Update(Nhaxuatban NXB)
        {
            _context.Update(NXB);
            _context.SaveChanges();
            return NXB;
        }
    }
}
