namespace WineCollection.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public List<Wine> Wines { get; set; } = new List<Wine>();
        public List<WineCellar> WineCellars { get; set; } = new List<WineCellar>();


    }
}
