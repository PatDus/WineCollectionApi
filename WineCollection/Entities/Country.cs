namespace WineCollection.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Vineyard> Vineyards { get; set; } = new List<Vineyard>();
    }
}