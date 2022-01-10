namespace GitNode.Infrastructure.Options
{
    internal class GitLabOptions
    {
        public const string OptionName = "GitLab";
        
        public string ApplicationId { get; set; }

        public string Secret { get; set; }
        
        public string CallbackUrl { get; set; }
    }
}