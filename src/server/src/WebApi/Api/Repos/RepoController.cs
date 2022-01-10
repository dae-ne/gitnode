using System.Threading.Tasks;
using GitNode.Application.Repos.Commands.AddRepo;
using GitNode.Application.Repos.Commands.UpdateRepo;
using GitNode.Application.Repos.Queries.GetRepo;
using GitNode.Domain.Enums;
using GitNode.WebApi.Api.Repos.Requests;
using GitNode.WebApi.Api.Repos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GitNode.WebApi.Api.Repos
{
    public class RepoController : ApiControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<ActionResult<RepoResponseDto>> GetRepo([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetRepoQuery(id));
            var dto = RepoResponseDto.FromDomain(response);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<RepoResponseDto>> AddRepo([FromBody] AddRepoRequestDto request)
        {
            var response = await Mediator.Send(new AddRepoCommand(
                request.Name,
                request.Description,
                request.Private,
                request.Account,
                PlatformUtils.FromString(request.Platform)));
            var dto = RepoResponseDto.FromDomain(response);
            return Created($"/repo/{dto.Id}", dto);
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateRepo([FromRoute] int id, [FromBody] UpdateRepoRequestDto request)
        {
            await Mediator.Send(new UpdateRepoCommand(id, request.Name, request.Description, request.Private));
            return Ok();
        }
    }
}