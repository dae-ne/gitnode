namespace GitNode.Infrastructure.Options
{
    internal class GitHubOptions
    {
        public const string OptionName = "GitHub";
        
        public string ClientId { get; set; }
        
        public string ClientSecret { get; set; }
    }
}