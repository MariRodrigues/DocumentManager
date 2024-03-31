using DocumentManagerApi.Data;
using DocumentManagerApi.Domain;
using DocumentManagerApi.Features.Documents.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DocumentManagerApi.Features.Documents
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly AppDbContext _context;

        public DocumentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Document> GetDocumentById(int id)
        {
            return await _context.Documents.FirstOrDefaultAsync(doc => doc.Id == id);
        }

        public void AddDocument(Document document)
        {
            _context.Add(document);
            _context.SaveChanges();
        }
    }
}
