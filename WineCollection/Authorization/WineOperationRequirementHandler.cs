using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using WineCollection.Entities;

namespace WineCollection.Authorization
{
    public class WineOperationRequirementHandler : AuthorizationHandler<WineOperationRequirement, Wine>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, WineOperationRequirement requirement, Wine wine)
        {
            var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (wine.UserId == int.Parse(userId))
            {
                context.Succeed(requirement);
            }


            return Task.CompletedTask;
        }
    }

}
