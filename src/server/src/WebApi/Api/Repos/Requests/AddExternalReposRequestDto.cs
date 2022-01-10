using System.Collections.Generic;

namespace GitNode.WebApi.Api.Repos.Requests
{
    public class AddExternalReposRequestDto
    {
        public string Account { get; set; }
        
        public string Platform { get; set; }

        public IEnumerable<int> OriginIds { get; set; }
    }
}