using System.ComponentModel.DataAnnotations;
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

        [Required]
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string AvatarUrl { get; set; }

        public static RepoOwnerResponseDto FromDomain(AccountEntity account) =>
            new(account.Id, account.Login, account.Url, account.AvatarUrl);
    }
}