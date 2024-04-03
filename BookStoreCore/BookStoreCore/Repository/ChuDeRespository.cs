using BookStoreCore.Models;
namespace BookStoreCore.Repository
{
    public class ChuDeRespository : IChuDeRepository
    {
        private  readonly QlbookstoreContext _context;
        public ChuDeRespository(QlbookstoreContext context)
        {
            _context = context;
        }
        public Chude Add(Chude chuDe)
        {
            _context.Chudes.Add(chuDe);  
            _context.SaveChanges();
            return chuDe;
        }

        public Chude Delete(int chuDe)
        {
            throw new NotImplementedException();
        }

  
        public IEnumerable<Chude> GetAllChuDe()
        {
            return _context.Chudes;
        }
    

        public Chude GetChuDe(int maChuDe)
        {
           
            return _context.Chudes.Find(maChuDe);
        }

        public Chude Update(Chude chuDe)
        {
            _context.Update(chuDe);
            _context.SaveChanges();
            return chuDe;
        }
    }
}
