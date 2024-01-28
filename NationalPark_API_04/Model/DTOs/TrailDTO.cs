using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NationalPark_API_04.Model.DTOs
{
    public class TrailDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Distance { get; set; }
        [Required]
        public string Elevation { get; set; }
        public enum DifficultyType { Easy, Medium, Difficult }

        public DifficultyType difficulty { get; set; }
        public int NationalParkId { get; set; }

        [ForeignKey("NationalParkId")]
        public NationalPark NationalPark { get; set; }


    }
}
