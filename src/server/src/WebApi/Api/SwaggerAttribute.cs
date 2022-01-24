using System;
using Swashbuckle.AspNetCore.Annotations;

namespace GitNode.WebApi.Api
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class SwaggerAttribute : SwaggerOperationAttribute
    {
        public SwaggerAttribute(string tag, string operationId)
        {
            OperationId = operationId;
            Tags = new[] {tag};
        }
    }
}