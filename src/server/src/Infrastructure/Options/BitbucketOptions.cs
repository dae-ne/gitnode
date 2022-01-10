namespace GitNode.Infrastructure.Options
{
    internal class BitbucketOptions
    {
        public const string OptionName = "Bitbucket";
        
        public string Secret { get; set; }

        public string Key { get; set; }
    }
}