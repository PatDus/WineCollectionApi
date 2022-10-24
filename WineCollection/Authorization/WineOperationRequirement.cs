using Microsoft.AspNetCore.Authorization;

namespace WineCollection.Authorization
{
    public class WineOperationRequirement : IAuthorizationRequirement
    {
        public ResourceOperation ResourceOperation { get; }

        public WineOperationRequirement(ResourceOperation resourceOperation)
        {
            ResourceOperation = resourceOperation;
        }
    }
}
