using Microsoft.Build.Framework;

namespace WebApp_API.Model
{
    public class NationalPark
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public byte[]? Picture { get; set; }
        public DateTime Created { get; set; }
        public DateTime Established { get; set; }

    }
}
// web