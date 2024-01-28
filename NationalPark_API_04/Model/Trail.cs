using System.ComponentModel.DataAnnotations.Schema;

namespace NationalPark_API_04.Model
{
    public class Trail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Distane { get; set; }
        public string Elevation { get; set; }
        public DateTime DateCreated { get; set; }
        public enum DifficultyType { Easy, Medium, Difficult }
        public DifficultyType difficulty { get; set; }
        public int NationalParkId { get; set; }

        [ForeignKey("NationalParkId")]
        public NationalPark NationalPark { get; set; }
    }
}

//DB