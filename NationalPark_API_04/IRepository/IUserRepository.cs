using NationalPark_API_04.Model;

namespace NationalPark_API_04.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser (string username);
        User Authenticate(string username, string password);
        User Register(string username, string password);
    }
}
