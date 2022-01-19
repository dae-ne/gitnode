using System.Collections.Generic;

namespace GitNode.Domain.Entities
{
    public class AccountEntity
    {
        public int Id { get; set; }

        public string OriginId { get; set; }

        public string Name { get; set; }
        
        public string Login { get; set; }

        public string Url { get; set; }

        public string AvatarUrl { get; set; }
        
        public string Token { get; set; }

        public string UserId { get; set; }

        public UserEntity User { get; set; }

        public int PlatformId { get; set; }

        public PlatformEntity Platform { get; set; }

        public ICollection<RepoEntity> Repository { get; set; }
    }
}