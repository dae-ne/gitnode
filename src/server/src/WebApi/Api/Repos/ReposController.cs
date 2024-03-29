﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitNode.Application.Repos.Commands.AddExternalRepos;
using GitNode.Application.Repos.Queries.GetExternalRepos;
using GitNode.Application.Repos.Queries.GetRepos;
using GitNode.Domain.Enums;
using GitNode.WebApi.Api.Repos.Requests;
using GitNode.WebApi.Api.Repos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GitNode.WebApi.Api.Repos
{
    public class ReposController : ApiControllerBase
    {
        [HttpGet]
        [Swagger(ReposDefaults.SwaggerTag, "getRepos")]
        public async Task<ActionResult<IEnumerable<RepoResponseDto>>> GetRepos()
        {
            var response = await Mediator.Send(new GetReposQuery());
            var dto = response.Select(RepoResponseDto.FromDomain);
            return Ok(dto);
        }
        
        [HttpGet("{platform}/{account}")]
        [Swagger(ReposDefaults.SwaggerTag, "getExternalRepos")]
        public async Task<ActionResult<IEnumerable<ExternalRepoResponseDto>>> GetExternalRepos(
            [FromRoute] string platform,
            [FromRoute] string account)
        {
            var response = await Mediator.Send(new GetExternalReposQuery(
                account,
                PlatformUtils.FromString(platform)));
            var dto = response.Select(ExternalRepoResponseDto.FromDomain);
            return Ok(dto);
        }
        
        [HttpPost]
        [Swagger(ReposDefaults.SwaggerTag, "addMultipleRepos")]
        public async Task<IActionResult> AddMultipleRepos([FromBody] AddExternalReposRequestDto request)
        {
            await Mediator.Send(new AddExternalReposCommand(
                request.Account,
                PlatformUtils.FromString(request.Platform),
                request.OriginIds));
            return Ok();
        }
    }
}