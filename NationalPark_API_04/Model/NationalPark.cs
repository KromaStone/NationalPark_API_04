namespace NationalPark_API_04.Model
{
    public class NationalPark
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public byte[]? Picture { get; set; }
        public DateTime Create { get; set; }
        public DateTime Stablished { get; set; }

    }
}
//DB