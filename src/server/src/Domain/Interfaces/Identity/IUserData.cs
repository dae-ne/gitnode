namespace GitNode.Domain.Interfaces.Identity
{
    public interface IUserData
    {
        string Id { get; }
        
        string Email { get; }
        
        string GivenName { get; }
        
        string Surname { get; }
        
        string Name { get; }

        string Picture { get; }
    }
}