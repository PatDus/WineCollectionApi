using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using WineCollection.Entities;

namespace WineCollection.Authorization
{
    public class WineCellarOperationRequirementHandler : AuthorizationHandler<WineCellarOperationRequirement, WineCellar>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, WineCellarOperationRequirement requirement, WineCellar wineCellar)
        {

            var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (wineCellar.UserId == int.Parse(userId))
            {
                context.Succeed(requirement);
            }


            return Task.CompletedTask;
        }
    }
}
