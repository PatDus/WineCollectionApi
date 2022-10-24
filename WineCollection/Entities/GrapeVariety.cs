namespace WineCollection.Entities
{
    public class GrapeVariety
    {
        public int Id { get; set; }
        public string GrapeVarietyName { get; set; }
        public string Description { get; set; }

        public List<Wine> Wines { get; set; } = new List<Wine>();
    }
}