using System.Threading;
using System.Threading.Tasks;
using GitNode.Application.Common.Interfaces;
using GitNode.Application.Repos.Queries.GetRepo;
using GitNode.Domain.Entities;
using Moq;
using Xunit;

namespace Application.Tests.Integration
{
    public class GetRepoQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnSingleRepo()
        {
            // Arrange
            var cancellationToken = new CancellationToken();
            var query = new GetRepoQuery(12345);
            var repo = new RepoEntity
            {
                Id = 12345,
                OriginId = 54321,
                Name = "repoName",
                Description = "description",
                Url = "url",
                Private = true,
                AccountId = 98765,
                Account = new AccountEntity()
            };

            var currentUserServiceMock = new Mock<ICurrentUserService>();
            currentUserServiceMock.Setup(cus => cus.Id)
                .Returns("userId");
            
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(uow => uow.Repos.GetWithAccountAsync(
                    query.Id, currentUserServiceMock.Object.Id, cancellationToken))
                .Returns(Task.FromResult(repo));

            var handler = new GetRepoQueryHandler(unitOfWorkMock.Object, currentUserServiceMock.Object);

            // Act
            var response = await handler.Handle(query, cancellationToken);
            
            // Assert
            Assert.Equal(repo.Id, response.Id);
            Assert.Equal(repo.Name, response.Name);
        }
    }
}
