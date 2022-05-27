using GitNode.Infrastructure.ExternalApis.GitHub.Auth.Responses;
using GitNode.Infrastructure.ExternalApis.GitHub.Repos.Responses;
using GitNode.Infrastructure.ExternalApis.GitHub.Users.Responses;
using GitNode.Infrastructure.ExternalApis.Mappers;
using Xunit;

namespace Infrastructure.Tests.Unit
{
    public class GitHubMapperTests
    {
        [Fact]
        public void Map_ShouldMapRepoDtoToDomainRepoCorrectly()
        {
            // Arrange
            var mapper = new GitHubMapper();
            var repoDto = new GitHubRepoResponseDto
            {
                Id = 12345,
                Name = "repoName",
                Description = "repoDescription",
                HtmlUrl = "repoUrl",
                Private = true,
                Owner = new GitHubOwnerResponseDto
                {
                    Id = 54321,
                    Login = "userLogin"
                }
            };
            
            // Act
            var repo = mapper.Map(repoDto);

            // Assert
            Assert.Equal(repo.Id, repoDto.Id);
            Assert.Equal(repo.Name, repoDto.Name);
            Assert.Equal(repo.Description, repoDto.Description);
            Assert.Equal(repo.Url, repoDto.HtmlUrl);
            Assert.Equal(repo.Private, repoDto.Private);
            Assert.Equal(repo.Owner.Id, repoDto.Owner.Id.ToString());
            Assert.Equal(repo.Owner.Login, repoDto.Owner.Login);
        }
        
        [Fact]
        public void Map_ShouldMapUserDtoToDomainUserCorrectly()
        {
            // Arrange
            var mapper = new GitHubMapper();
            var userDto = new GitHubUserResponseDto
            {
                Id = 12345,
                Login = "userLogin",
                HtmlUrl = "userUrl",
                Name = "username",
                AvatarUrl = "avatarUrl"
            };
            
            // Act
            var user = mapper.Map(userDto);

            // Assert
            Assert.Equal(user.Id, userDto.Id.ToString());
            Assert.Equal(user.Login, userDto.Login);
            Assert.Equal(user.Name, userDto.Name);
            Assert.Equal(user.Url, userDto.HtmlUrl);
            Assert.Equal(user.AvatarUrl, userDto.AvatarUrl);
        }
        
        [Fact]
        public void Map_ShouldMapTokenDtoToDomainTokenCorrectly()
        {
            // Arrange
            var mapper = new GitHubMapper();
            var tokenDto = new GitHubTokenResponseDto
            {
                AccessToken = "accessToken"
            };
            
            // Act
            var user = mapper.Map(tokenDto);

            // Assert
            Assert.Equal(user.AccessToken, tokenDto.AccessToken);
            Assert.Null(user.RefreshToken);
        }
    }
}
