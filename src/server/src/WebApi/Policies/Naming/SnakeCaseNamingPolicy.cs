using System.Text.Json;
using GitNode.WebApi.Extensions;

namespace GitNode.WebApi.Policies.Naming
{
    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            return name.ToSnakeCase();
        }
    }
}