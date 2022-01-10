using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace GitNode.WebApi.Policies.Conventions
{
    internal class DefaultAuthorizationConvention : IActionModelConvention
    {
        public void Apply(ActionModel action)
        {
            if (!ShouldApply(action)) return;
            var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            action.Filters.Add(new AuthorizeFilter(policy));
        }
        
        private static bool ShouldApply(ICommonModel action) =>
            action.Attributes.All(attr => attr.GetType() != typeof(AuthorizeAttribute)) &&
            action.Attributes.All(attr => attr.GetType() != typeof(AllowAnonymousAttribute));
    }
}