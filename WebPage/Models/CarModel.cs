namespace WebPage.Models
{
    public class CarModel
    {
        public long Id { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }

        public Int16 Doors { get; set; }

        public string? Color { get; set; }

        public float Price { get; set; }
    }
}