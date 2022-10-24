namespace WineCollection.Exceptions
{
    public class CellarIsFullException : Exception
    {
        public CellarIsFullException(string message) : base(message)
        {
        }
    }
}
