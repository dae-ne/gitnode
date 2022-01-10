using GitNode.Domain.Interfaces.Identity;

namespace GitNode.Domain.Models.Identity
{
    public class UserData : IUserData
    {
        public string Id { get; set; }
        
        public string Email { get; set; }
        
        public string GivenName { get; set; }
        
        public string Surname { get; set; }
        
        public string Name => $"{GivenName} {Surname}".Trim();

        public string Picture { get; set; }
    }
}