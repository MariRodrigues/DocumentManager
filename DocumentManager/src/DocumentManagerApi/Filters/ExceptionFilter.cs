using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using DocumentManagerApi.Filters.Exceptions;

namespace DocumentManagerApi.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            switch (exception)
            {
                case DocumentConfidentialException documentConfidentialException:
                    context.Result = new ContentResult
                    {
                        Content = documentConfidentialException.Message,
                        StatusCode = (int)HttpStatusCode.Forbidden,
                        ContentType = "text/plain"
                    };
                    break;

                case BadRequestException badRequestException:
                    context.Result = new ContentResult
                    {
                        Content = badRequestException.Message,
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        ContentType = "text/plain"
                    };
                    break;

                case NotFoundException notFoundException:
                    context.Result = new ContentResult
                    {
                        Content = notFoundException.Message,
                        StatusCode = (int)HttpStatusCode.NotFound,
                        ContentType = "text/plain"
                    };
                    break;

                default:
                    context.Result = new ContentResult
                    {
                        Content = exception.Message + exception.StackTrace,
                        StatusCode = (int)HttpStatusCode.InternalServerError,
                        ContentType = "text/plain"
                    };
                    break;

            }
        }
    }
}
