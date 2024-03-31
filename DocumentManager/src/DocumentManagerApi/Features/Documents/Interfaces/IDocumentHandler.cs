using DocumentManagerApi.Domain;
using DocumentManagerApi.Features.Documents.Commands;
using DocumentManagerApi.Features.Documents.Queries;
using DocumentManagerApi.Shared;
using MediatR;

namespace DocumentManagerApi.Features.Documents.Interfaces
{
    public interface IDocumentHandler :
        IRequestHandler<CreateDocumentCommand, ResponseApi<Document>>,
        IRequestHandler<DocumentQuery, ResponseApi<Document>>
    {
    }
}
