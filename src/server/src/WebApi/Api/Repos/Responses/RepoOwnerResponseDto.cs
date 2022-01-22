using GitNode.Domain.Entities;

namespace GitNode.WebApi.Api.Repos.Responses
{
    public class RepoOwnerResponseDto
    {
        private RepoOwnerResponseDto(int id, string login, string url, string avatarUrl)
        {
            Id = id;
            Login = login;
            Url = url;
            AvatarUrl = avatarUrl;
        }

        public int Id { get; set; }

        public string Login { get; set; }

        public string Url { get; set; }

        public string AvatarUrl { get; set; }

        public static RepoOwnerResponseDto FromDomain(AccountEntity account) =>
            new(account.Id, account.Login, account.Url, account.AvatarUrl);
    }
}