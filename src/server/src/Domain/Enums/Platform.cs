using System;

namespace GitNode.Domain.Enums
{
    public enum Platform
    {
        GitHub,
        Bitbucket,
        GitLab
    }
    
    public static class PlatformUtils
    {
        private const string GitHub = "github";
        private const string Bitbucket = "bitbucket";
        private const string GitLab = "gitlab";
        private const string ErrorMessage = "Unsupported platform";
        
        public static string ToStringValue(this Platform platform) => platform switch
        {
            Platform.GitHub => GitHub,
            Platform.Bitbucket => Bitbucket,
            Platform.GitLab => GitLab,
            // TODO: exception type
            _ => throw new ArgumentOutOfRangeException(nameof(platform), platform, ErrorMessage)
        };

        public static Platform FromString(string platform) => platform.ToLower() switch
        {
            GitHub => Platform.GitHub,
            Bitbucket => Platform.Bitbucket,
            GitLab => Platform.GitLab,
            // TODO: exception type
            _ => throw new ArgumentOutOfRangeException(nameof(platform), platform, ErrorMessage)
        };
    }
}