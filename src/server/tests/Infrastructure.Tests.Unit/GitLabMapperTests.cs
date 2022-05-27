using GitNode.Infrastructure.ExternalApis.GitLab.Auth.Responses;
using GitNode.Infrastructure.ExternalApis.GitLab.Repos.Responses;
using GitNode.Infrastructure.ExternalApis.GitLab.Users.Responses;
using GitNode.Infrastructure.ExternalApis.Mappers;
using Xunit;

namespace Infrastructure.Tests.Unit
{
    public class GitLabMapperTests
    {
        [Fact]
        public void Map_ShouldMapRepoDtoToDomainRepoCorrectly()
        {
            // Arrange
            var mapper = new GitLabMapper();
            var repoDto = new GitLabRepoResponseDto
            {
                Id = 12345,
                Path = "repoName",
                Description = "repoDescription",
                WebUrl = "repoUrl",
                Visibility = "private",
                Owner = new GitLabOwnerResponseDto
                {
                    Id = 54321,
                    Name = "userLogin"
                }
            };
            
            // Act
            var repo = mapper.Map(repoDto);

            // Assert
            Assert.Equal(repo.Id, repoDto.Id);
            Assert.Equal(repo.Name, repoDto.Path);
            Assert.Equal(repo.Description, repoDto.Description);
            Assert.Equal(repo.Url, repoDto.WebUrl);
            Assert.True(repo.Private);
            Assert.Equal(repo.Owner.Id, repoDto.Owner.Id.ToString());
            Assert.Equal(repo.Owner.Login, repoDto.Owner.Name);
        }
        
        [Fact]
        public void Map_ShouldMapUserDtoToDomainUserCorrectly()
        {
            // Arrange
            var mapper = new GitLabMapper();
            var userDto = new GitLabUserResponseDto
            {
                Id = 12345,
                Username = "userLogin",
                WebUrl = "userUrl",
                Name = "username",
            };
            
            // Act
            var user = mapper.Map(userDto);

            // Assert
            Assert.Equal(user.Id, userDto.Id.ToString());
            Assert.Equal(user.Login, userDto.Username);
            Assert.Equal(user.Name, userDto.Name);
            Assert.Equal(user.Url, userDto.WebUrl);
        }
        
        [Fact]
        public void Map_ShouldMapTokenDtoToDomainTokenCorrectly()
        {
            // Arrange
            var mapper = new GitLabMapper();
            var tokenDto = new GitLabTokenResponseDto
            {
                AccessToken = "accessToken",
                RefreshToken = "refreshToken"
            };
            
            // Act
            var user = mapper.Map(tokenDto);

            // Assert
            Assert.Equal(user.AccessToken, tokenDto.AccessToken);
            Assert.Equal(user.RefreshToken, tokenDto.RefreshToken);
        }
    }
}
