namespace WineCollection.Models
{
    public class CellarDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int UserId { get; set; }
        public List<WineDto> Wines { get; set; }
    }
}
