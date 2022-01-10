namespace GitNode.Infrastructure.Options
{
    internal class IdentityOptions
    {
        public const string OptionName = "Google";
        
        public string ClientId { get; set; }
        
        public string ClientSecret { get; set; }
        
        public string RedirectUri { get; set; }
    }
}