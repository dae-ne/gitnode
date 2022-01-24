using System;
using System.ComponentModel.DataAnnotations;
using GitNode.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

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

        [Required]
        public string Id { get; set; }
        
        [Required]
        public string GivenName { get; set; }
        
        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }
        
        [Required]
        public string ImageUrl { get; set; }
        
        [Required]
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