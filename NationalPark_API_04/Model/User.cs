using System.ComponentModel.DataAnnotations.Schema;

namespace NationalPark_API_04.Model
{
    public class User
    {
        public int Id { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Role { get; set; }
        [NotMapped]
        public String Token { get; set; }
    }
}
