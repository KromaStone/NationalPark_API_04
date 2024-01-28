using Microsoft.EntityFrameworkCore;
using NationalPark_API_04.Data;
using NationalPark_API_04.Model;

namespace NationalPark_API_04.IRepository.Repository
{
    public class TrailRepository : ITrailRepository
    {
        private readonly ApplicationDbContext _context;
        public TrailRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public bool CreateTrail(Trail trail)
        {
            _context.trails.Add(trail);
            return Save();
        }

        public bool DeleteTrail(Trail trail)
        {
            _context.trails.Remove(trail);
            return Save();
        }

        public Trail GetTrail(int trailId)
        {
            return _context.trails.Include(t => t.NationalPark).FirstOrDefault(t => t.Id == trailId);
        }

        public ICollection<Trail> GetTrailNationalPark(int nationalParkId)
        {
            return _context.trails.Include(t=>t.NationalPark).Where(t => t.NationalParkId==nationalParkId).ToList();

        }

        public ICollection<Trail> GetTrails()
        {
            return _context.trails.Include(t => t.NationalPark).ToList();

        }

        public bool Save()
        {
            return _context.SaveChanges()==1? true: false;
        }

        public bool TrailExists(int trailId)
        {
            return _context.trails.Any(t=>t.Id==trailId);
        }

        public bool TrailExists(string trailName)
        {
            return _context.trails.Any(t=>t.Name==trailName);
        }

        public bool UpdateTrail(Trail trail)
        {
            _context.trails.Update(trail);
            return Save();
        }
    }
}


//error