namespace WineCollection.Entities
{
    public class Wine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TasteDescription { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public string ImgPath { get; set; }
        public string Style { get; set; }
        public decimal ServingTemperature { get; set; }

        public Color Color { get; set; }
        public int ColorId { get; set; }

        public GrapeVariety GrapeVariety { get; set; }
        public int GrapeVarietyId { get; set; }

        public Vineyard Vineyard { get; set; }
        public int VineyardId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public WineCellar WineCellar { get; set; }
        public int WineCellarId { get; set; }
    }


}
