using System.Threading.Tasks;
using GitNode.Application.Identity.Commands.GetToken;
using GitNode.Application.Identity.Commands.RevokeToken;
using GitNode.Domain.Enums;
using GitNode.WebApi.Api.Auth.Requests;
using GitNode.WebApi.Api.Auth.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GitNode.WebApi.Api.Auth
{
    [AllowAnonymous]
    public class AuthController : ApiControllerBase
    {
        [HttpPost("token")]
        public async Task<ActionResult<TokenResponseDto>> GetToken([FromBody] GetTokenRequestDto request)
        {
            var response = await Mediator.Send(new GetTokenCommand(
                request.Code,
                request.RefreshToken,
                GrantTypeUtils.FromString(request.GrantType)));
            var dto = TokenResponseDto.FromDomain(response);
            return Ok(dto);
        }

        [HttpPost("revoke")]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenRequestDto request)
        {
            await Mediator.Send(new RevokeTokenCommand(request.Token));
            return Ok();
        }
    }
}