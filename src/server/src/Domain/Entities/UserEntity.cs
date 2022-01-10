using System;
using System.Collections.Generic;

namespace GitNode.Domain.Entities
{
    public class UserEntity
    {
        public string Id { get; set; }
        
        public string GivenName { get; set; }
        
        public string Surname { get; set; }

        public string Email { get; set; }
        
        public string ImageUrl { get; set; }
        
        public DateTimeOffset CreatedAt { get; set; }

        public ICollection<AccountEntity> Accounts { get; set; }
    }
}