using Newtonsoft.Json;

namespace github_search_api.Models
{
    public class SearchResult
    {
        [JsonProperty("total_count")]
        public int Total { get; set; }


        [JsonProperty("items")]
        public Repository[] Items { get; set; }
    }
}
