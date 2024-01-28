namespace WebApp_API.Repository.IRipository
{
    public interface IRepository<T> where T : class
    {
        //declaration of methods

        Task<T> GetAsync(string Url,int id );
         Task<IEnumerable<T>> GetAllAsync(string Url);
        Task<bool> CreateAsync (string Url, T objToCreate);
        Task<bool> UpdateAsync (string Url, T objToUpdate);
        Task<bool> DeleteAsync (string Url, int id);













    }
}
