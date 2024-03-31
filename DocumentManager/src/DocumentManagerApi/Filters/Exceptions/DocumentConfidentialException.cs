namespace DocumentManagerApi.Filters.Exceptions
{
    public class DocumentConfidentialException : Exception
    {
        public DocumentConfidentialException(string message) : base(message) { }
    }
}
