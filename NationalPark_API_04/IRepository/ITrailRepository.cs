using NationalPark_API_04.Model;

namespace NationalPark_API_04.IRepository
{
    public interface ITrailRepository
    {
        ICollection <Trail> GetTrails ();
        Trail GetTrail(int trailId);
        ICollection<Trail> GetTrailNationalPark (int nationalParkId);
        bool TrailExists(int trailId);
        bool TrailExists(string trailName);
        bool CreateTrail(Trail trail);
        bool UpdateTrail (Trail trail);
        bool DeleteTrail(Trail trail);
        bool Save();
    }
}
