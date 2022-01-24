using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitNode.Application.Users.Queries.GetUsers;
using GitNode.WebApi.Api.Users.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GitNode.WebApi.Api.Users
{
    [AllowAnonymous]
    public class UsersController : ApiControllerBase
    {
        [HttpGet]
        [Swagger(UsersDefaults.SwaggerTag, "getUsers")]
        public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetUsers()
        {
            var response = await Mediator.Send(new GetUsersQuery());
            var dto = response.Select(UserResponseDto.FromDomain);
            return Ok(dto);
        }
    }
}