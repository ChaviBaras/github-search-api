namespace github_search_api.Models
{
    public class Repository
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Url { get; set; } 
        public string Description { get; set; }
        public Owner Owner { get; set; }
    }
}
