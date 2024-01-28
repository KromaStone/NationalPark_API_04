using Newtonsoft.Json;
using System.Text;
using WebApp_API.Repository.IRipository;

//namespace WebApp_API.Repository ye namespace add krna h
namespace WebApp_API.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public Repository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> CreateAsync(string Url, T objToCreate)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, Url);
            if (objToCreate != null)
            {
            // request.Content = new StringContent(JsonConvert.SerializeObject(objToCreate), encoding,Utf8,"aplicatiotn/json");
               request.Content = new StringContent(JsonConvert.SerializeObject(objToCreate), Encoding.UTF8,"application/json");
            }
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response=await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
                return true;
            return false;
        }

        public async Task<bool> DeleteAsync(string Url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, Url + "/" +id.ToString());
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response= await client.SendAsync(request);  
            if(response.StatusCode== System.Net.HttpStatusCode.OK)    
                    return true;
                return false;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string Url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Url);
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode==System.Net.HttpStatusCode.OK)
            {   
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString);
            }
            return null;
                 
        }

        public async Task<T> GetAsync(string Url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Url + "/" + id.ToString());
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            return null;
        }

        public async Task<bool> UpdateAsync(string Url, T objToUpdate)
        {
           var request =new HttpRequestMessage(HttpMethod.Put, Url);
            if(objToUpdate!=null)
            {
                request.Content= new StringContent(JsonConvert.SerializeObject(objToUpdate),Encoding.UTF8,"application/json");
            }
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return true;
            return false;
        }
    }
}
