using GitNode.Domain.Entities;
using GitNode.Domain.Enums;
using MediatR;

namespace GitNode.Application.Accounts.Commands.AddAccount
{
    public class AddAccountCommand : IRequest<AccountEntity>
    {
        public AddAccountCommand(Platform platform, string code)
        {
            Platform = platform;
            Code = code;
        }

        public Platform Platform { get; set; }
        
        public string Code { get; set; }
    }
}