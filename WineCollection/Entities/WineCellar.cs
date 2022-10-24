namespace WineCollection.Entities
{
    public class WineCellar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public List<Wine> Wines { get; set; } = new List<Wine>();
    }
}
