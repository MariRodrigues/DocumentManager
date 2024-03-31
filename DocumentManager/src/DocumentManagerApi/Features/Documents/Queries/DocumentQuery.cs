using DocumentManagerApi.Domain;
using DocumentManagerApi.Shared;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DocumentManagerApi.Features.Documents.Queries
{
    public class DocumentQuery : IRequest<ResponseApi<Document>>
    {
        [Required]
        public int DocumentId { get; set; }

        public DocumentQuery(int id)
        {
            DocumentId = id;
        }

        public DocumentQuery() { }
    }
}
