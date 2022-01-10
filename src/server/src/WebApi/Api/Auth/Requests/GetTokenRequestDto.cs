namespace GitNode.WebApi.Api.Auth.Requests
{
    public class GetTokenRequestDto
    {
        public string Code { get; set; }

        public string RefreshToken { get; set; }
        
        public string GrantType { get; set; }
    }
}