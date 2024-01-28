using NationalPark_API_04.Model;
using System.ComponentModel.DataAnnotations;

namespace WebApp_API.Model
{
    public class Trail
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Distance { get; set; }
        [Required]
        public string Elevation { get; set; }
        public enum DifficultyType { Easy, Medium, Difficult }

        public DifficultyType Difficulty { get; set; }
        public int NationalParkId { get; set; }
        public NationalPark NationalPark { get; set; }
    }
}

//web