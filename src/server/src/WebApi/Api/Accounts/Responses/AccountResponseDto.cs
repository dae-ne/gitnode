using System.ComponentModel.DataAnnotations;
using GitNode.Domain.Entities;

namespace GitNode.WebApi.Api.Accounts.Responses
{
    public class AccountResponseDto
    {
        private AccountResponseDto(
            int id,
            string originId,
            string userId,
            string platform,
            string name,
            string login,
            string url,
            string avatarUrl)
        {
            Id = id;
            OriginId = originId;
            UserId = userId;
            Platform = platform;
            Name = name;
            Login = login;
            Url = url;
            AvatarUrl = avatarUrl;
        }

        [Required]
        public int Id { get; set; }
        
        [Required]
        public string OriginId { get; set; }
        
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Platform { get; set; }
        
        public string Name { get; set; }

        [Required]
        public string Login { get; set; }
        
        [Required]
        public string Url { get; set; }
        
        [Required]
        public string AvatarUrl { get; set; }

        public static AccountResponseDto FromDomain(AccountEntity account) =>
            new(account.Id,
                account.OriginId,
                account.UserId,
                account.Platform.Name,
                account.Name,
                account.Login,
                account.Url,
                account.AvatarUrl);
    }
}