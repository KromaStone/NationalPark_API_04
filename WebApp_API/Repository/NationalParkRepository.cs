using WebApp_API.Model;
using WebApp_API.Repository.IRipository;

namespace WebApp_API.Repository
{
    public class NationalParkRepository : Repository<NationalPark>,INationalParkRepository
        //Repository<NationalPark>,INationalParkRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public NationalParkRepository (IHttpClientFactory httpClientFactory):base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


    }
}
