using System.Threading.Tasks;
using GitNode.Application.Users.Commands.RemoveUser;
using GitNode.Application.Users.Queries.GetAuthenticatedUser;
using GitNode.Application.Users.Queries.GetUser;
using GitNode.WebApi.Api.Users.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GitNode.WebApi.Api.Users
{
    public class UserController : ApiControllerBase
    {
        [HttpGet]
        [Swagger(UsersDefaults.SwaggerTag, "getAuthenticatedUser")]
        public async Task<ActionResult<UserResponseDto>> GetAuthenticatedUser()
        {
            var response = await Mediator.Send(new GetAuthenticatedUserQuery());
            var dto = UserResponseDto.FromDomain(response);
            return Ok(dto);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        [Swagger(UsersDefaults.SwaggerTag, "getUser")]
        public async Task<ActionResult<UserResponseDto>> GetUser([FromRoute] string id)
        {
            var response = await Mediator.Send(new GetUserQuery(id));
            var dto = UserResponseDto.FromDomain(response);
            return Ok(dto);
        }

        [HttpDelete]
        [Swagger(UsersDefaults.SwaggerTag, "removeUser")]
        public async Task<IActionResult> RemoveUser()
        {
            await Mediator.Send(new RemoveUserCommand());
            return Accepted();
        }
    }
}