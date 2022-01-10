using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitNode.Application.Accounts.Queries.GetAccounts;
using GitNode.WebApi.Api.Accounts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GitNode.WebApi.Api.Accounts
{
    public class AccountsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountResponseDto>>> GetAccounts()
        {
            var response = await Mediator.Send(new GetAccountsQuery());
            var dto = response.Select(AccountResponseDto.FromDomain);
            return Ok(dto);
        }
    }
}