using DocumentManagerApi.Domain;
using DocumentManagerApi.Shared;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DocumentManagerApi.Features.Documents.Commands
{
    public class CreateDocumentCommand : IRequest<ResponseApi<Document>>
    {
        [Required]
        public bool Confidential { get; set; }
        [Required]
        public string Content { get; set; }
        [JsonIgnore]
        public string? UserLogin { get; set; }
    }
}
