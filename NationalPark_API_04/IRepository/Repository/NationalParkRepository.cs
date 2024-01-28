using NationalPark_API_04.Data;
using NationalPark_API_04.Model;

namespace NationalPark_API_04.IRepository.Repository
{
    public class NationalParkRepository : INationalParkRepository
    {
        private readonly ApplicationDbContext _context;
        public NationalParkRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CreateNationalPark(NationalPark nationalPark)
        {
            _context.nationalParks.Add(nationalPark);
            return Save();
        }

        public bool DeleteNationalPark(NationalPark nationalPark)
        {
            _context.nationalParks.Remove(nationalPark);
            return Save();  
        }

        public NationalPark GetNationalPark(int nationalParkId)
        {
            return _context.nationalParks.Find(nationalParkId);
        }

        public ICollection<NationalPark> GetNationalParks()
        {
                return _context.nationalParks.ToList();
        }

        public bool NationalParkExists(int nationalParkId)
        {
            return _context.nationalParks.Any(np=>np.Id == nationalParkId); 
        }

        public bool NationalParkExists(string nationalParkName)
        {
            return _context.nationalParks.Any(np => np.Name == nationalParkName);
        }

        public bool Save()
        {
            return _context.SaveChanges()==1? true:false;
        }

        public bool UpdateNationalPark(NationalPark nationalPark)
        {
            _context.nationalParks.Update(nationalPark);
            return Save();
        }
    }
}
