using WebApp_API.Model;
using WebApp_API.Repository.IRipository;

namespace WebApp_API.Repository
{
    public class TrailRepository:Repository<Trail>,ITrailRepository
        //Repository<Trail>,ITrailRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public TrailRepository(IHttpClientFactory httpClientFactory):base(httpClientFactory) 
        {
            _httpClientFactory = httpClientFactory;
        }   
    }
}
