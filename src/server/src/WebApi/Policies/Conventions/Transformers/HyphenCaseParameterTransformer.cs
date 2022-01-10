using GitNode.WebApi.Extensions;
using Microsoft.AspNetCore.Routing;

namespace GitNode.WebApi.Policies.Conventions.Transformers
{
    internal class HyphenCaseParameterTransformer : IOutboundParameterTransformer
    {
        public string TransformOutbound(object value)
        {
            if (value is not string valueStr || string.IsNullOrWhiteSpace(valueStr))
                return string.Empty;

            return valueStr.ToHyphenCase();
        }
    }
}