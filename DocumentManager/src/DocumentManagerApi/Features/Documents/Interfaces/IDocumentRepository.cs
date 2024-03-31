using DocumentManagerApi.Domain;

namespace DocumentManagerApi.Features.Documents.Interfaces
{
    public interface IDocumentRepository
    {
        Task<Document> GetDocumentById(int id);
        void AddDocument(Document document);
    }
}
