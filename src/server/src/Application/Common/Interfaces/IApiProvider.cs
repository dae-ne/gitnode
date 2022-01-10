namespace GitNode.Application.Common.Interfaces
{
    public interface IApiProvider
    {
        IPlatformApi GitHub { get; }

        IPlatformApi Bitbucket { get; }

        IPlatformApi GitLab { get; }
    }
}
