using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GitNode.Application.Common.Interfaces;
using GitNode.Application.Users.Queries.GetUser;
using GitNode.Domain.Entities;
using Moq;
using Xunit;

namespace Application.Tests.Integration
{
    public class GetUserQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnSingleUser()
        {
            // Arrange
            var cancellationToken = new CancellationToken();
            var query = new GetUserQuery("userId");
            var user = new UserEntity
            {
                Id = "userId",
                GivenName = "givenName",
                Surname = "surname",
                Email = "email",
                ImageUrl = "imageUrl",
                CreatedAt = DateTimeOffset.Now,
                Accounts = Enumerable.Empty<AccountEntity>().ToList()
            };

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock
                .Setup(uow => uow.Users.GetAsync(query.Id, cancellationToken))
                .Returns(Task.FromResult(user));

            var handler = new GetUserQueryHandler(unitOfWorkMock.Object);

            // Act
            var response = await handler.Handle(query, cancellationToken);
            
            // Assert
            Assert.Equal(user.Id, response.Id);
            Assert.Equal(user.GivenName, response.GivenName);
        }
    }
}
