namespace DocumentManagerApi.Domain
{
    public class Document
    {
        public int Id { get; set; }
        public bool Confidential { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Content { get; set; }

        public Document()
        {
        }

        public Document(bool confidential, string content, string userLogin)
        {
            Confidential = confidential;
            Content = content;
            CreatedBy = userLogin;
            CreatedAt = DateTime.Now;
        }
    }
}
