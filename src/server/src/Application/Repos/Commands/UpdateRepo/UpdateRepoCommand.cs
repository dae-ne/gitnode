using MediatR;

namespace GitNode.Application.Repos.Commands.UpdateRepo
{
    public class UpdateRepoCommand : IRequest
    {
        public UpdateRepoCommand(int id, string name, string description, bool @private)
        {
            Id = id;
            Name = name;
            Description = description;
            Private = @private;
        }

        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Private { get; set; }
    }
}