using GitNode.WebApi.Policies.Conventions.Transformers;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace GitNode.WebApi.Policies.Conventions
{
    internal class HyphenCaseRouteConvention : RouteTokenTransformerConvention
    {
        private static readonly HyphenCaseParameterTransformer Transformer = new();
        
        public HyphenCaseRouteConvention() : base(Transformer) { }
    }
}