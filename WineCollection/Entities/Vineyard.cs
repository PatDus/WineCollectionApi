namespace WineCollection.Entities
{
    public class Vineyard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }

        public Country Country { get; set; }
        public int CountryId { get; set; }

        public List<Wine> Wines { get; set; } = new List<Wine>();

    }
}