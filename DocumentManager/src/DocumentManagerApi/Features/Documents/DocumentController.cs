using DocumentManagerApi.Features.Documents.Commands;
using DocumentManagerApi.Features.Documents.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DocumentManagerApi.Features.Documents
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly IHttpContextAccessor _acessor;
        private readonly IAuthorizationService _authorizationService;

        public DocumentController(IHttpContextAccessor acessor, IAuthorizationService authorizationService)
        {
            _acessor = acessor;
            _authorizationService = authorizationService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra novo documento",
                  OperationId = "Post")]
        [ProducesResponseType(201)]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> CreateCategory([FromServices] IMediator mediator, [FromBody] CreateDocumentCommand request)
        {
            request.UserLogin = _acessor?.HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == "username")?.Value;

            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("documentId")]
        [SwaggerOperation(Summary = "Busca documentos por Id",
          OperationId = "Get")]
        [ProducesResponseType(200)]
        [Authorize]
        public async Task<IActionResult> CreateCategory([FromServices] IMediator mediator, int id, CancellationToken cancellationToken)
        {
            var query = new DocumentQuery(id);

            var response = await mediator.Send(query, cancellationToken);

            if (response.Success)
            {
                var authorizationResult = await _authorizationService.AuthorizeAsync(
                    HttpContext.User,
                    response.Result.Confidential,
                    "DocumentConfidential");

                if (!authorizationResult.Succeeded)
                {
                    return StatusCode(403);
                }
            }

            return Ok(response);
        }
    }
}
