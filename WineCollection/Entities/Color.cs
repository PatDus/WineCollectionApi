namespace WineCollection.Entities
{
    public class Color
    {
        public int Id { get; set; }
        public string ColorName { get; set; }

        public List<Wine> Wines { get; set; } = new List<Wine>();
    }
}