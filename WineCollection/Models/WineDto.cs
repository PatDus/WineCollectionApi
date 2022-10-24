namespace WineCollection.Models
{
    public class WineDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TasteDescription { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public string Style { get; set; }
        public string Color { get; set; }
        public string GrapeVariety { get; set; }
        public string Vineyard { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public int WineCellarId { get; set; }
    }
}
