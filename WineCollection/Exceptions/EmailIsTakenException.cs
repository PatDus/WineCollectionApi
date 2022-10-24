namespace WineCollection.Exceptions
{
    public class EmailIsTakenException : Exception
    {
        public EmailIsTakenException(string message) : base(message)
        {

        }
    }
}
