using System;
using GitNode.Domain.Entities;

namespace GitNode.WebApi.Api.Users.Responses
{
    public class UserResponseDto
    {
        private UserResponseDto(
            string id,
            string givenName,
            string surname,
            string email,
            string imageUrl,
            DateTimeOffset createdAt)
        {
            Id = id;
            GivenName = givenName;
            Surname = surname;
            Email = email;
            ImageUrl = imageUrl;
            CreatedAt = createdAt;
        }

        public string Id { get; set; }
        
        public string GivenName { get; set; }
        
        public string Surname { get; set; }

        public string Email { get; set; }
        
        public string ImageUrl { get; set; }
        
        public DateTimeOffset CreatedAt { get; set; }

        public static UserResponseDto FromDomain(UserEntity user) =>
            new(user.Id,
                user.GivenName,
                user.Surname,
                user.Email,
                user.ImageUrl,
                user.CreatedAt);
    }
}