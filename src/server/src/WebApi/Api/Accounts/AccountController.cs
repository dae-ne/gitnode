﻿using System.Threading.Tasks;
using GitNode.Application.Accounts.Commands.AddAccount;
using GitNode.Application.Accounts.Queries.GetAccount;
using GitNode.Domain.Enums;
using GitNode.WebApi.Api.Accounts.Requests;
using GitNode.WebApi.Api.Accounts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GitNode.WebApi.Api.Accounts
{
    public class AccountController : ApiControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AccountResponseDto>> AddAccount([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetAccountQuery(id));
            var dto = AccountResponseDto.FromDomain(response);
            return Ok(dto);
        }
        
        [HttpPost]
        public async Task<ActionResult<AccountResponseDto>> AddAccount([FromBody] AddAccountRequestDto request)
        {
            var response = await Mediator.Send(new AddAccountCommand(
                PlatformUtils.FromString(request.Platform),
                request.Code));
            var dto = AccountResponseDto.FromDomain(response);
            return Created($"/account/{dto.Id}", dto);
        }
    }
}