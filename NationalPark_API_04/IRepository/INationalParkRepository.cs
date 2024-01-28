using NationalPark_API_04.Model;

namespace NationalPark_API_04.IRepository
{
    public interface INationalParkRepository
    {
        ICollection<NationalPark> GetNationalParks();
        NationalPark GetNationalPark(int nationalParkId);
        bool NationalParkExists(int nationalParkId);
        bool NationalParkExists(string nationalParkName);
        bool CreateNationalPark(NationalPark nationalPark);
        bool UpdateNationalPark(NationalPark nationalPark);
        bool DeleteNationalPark(NationalPark nationalPark);
        bool Save();

    }
}
