namespace GitNode.Domain.Models.Platforms
{
    public class Repo
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string Url { get; set; }
        
        public bool Private { get; set; }
        
        public Owner Owner { get; set; }
    }
}