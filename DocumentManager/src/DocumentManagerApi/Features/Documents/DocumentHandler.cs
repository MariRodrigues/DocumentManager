using DocumentManagerApi.Domain;
using DocumentManagerApi.Features.Documents.Commands;
using DocumentManagerApi.Features.Documents.Interfaces;
using DocumentManagerApi.Features.Documents.Queries;
using DocumentManagerApi.Shared;

namespace DocumentManagerApi.Features.Documents
{
    public class DocumentHandler : IDocumentHandler
    {
        private readonly IDocumentRepository _repository;

        public DocumentHandler(IDocumentRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseApi<Document>> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            Document newDocument = new(request.Confidential, request.Content, request.UserLogin);

            _repository.AddDocument(newDocument);

            return new ResponseApi<Document>(true, "Documento criado com sucesso.");
        }

        public async Task<ResponseApi<Document>> Handle(DocumentQuery request, CancellationToken cancellationToken)
        {
            var document = await _repository.GetDocumentById(request.DocumentId);

            if (document == null)
            {
                return new ResponseApi<Document>(false, "Documento não encontrado.");
            }

            return new ResponseApi<Document>(true, document);
        }
    }
}
