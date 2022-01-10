namespace GitNode.Domain.Entities
{
    public class RepoEntity
    {
        public int Id { get; set; }

        public int OriginId { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }
        
        public string Url { get; set; }

        public bool Private { get; set; }
        
        public int AccountId { get; set; }

        public AccountEntity Account { get; set; }
    }
}