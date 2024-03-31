using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace DocumentManagerApi.Extensions
{
    public class DocumentConfidentialAuthHandler : AuthorizationHandler<DocumentConfidentialRequirement, bool>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, DocumentConfidentialRequirement requirement, bool resource)
        {
            var userRole = context.User.FindFirstValue(ClaimTypes.Role);

            if (string.IsNullOrEmpty(userRole))
                return;

            if (resource == true && userRole != "Admin")
                return;

            context.Succeed(requirement);
        }
    }

    public class DocumentConfidentialRequirement : IAuthorizationRequirement
    {
    }
}
