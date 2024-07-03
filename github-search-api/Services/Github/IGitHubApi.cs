using github_search_api.Models;
using Refit;
using System.Threading.Tasks;

namespace github_search_api.Services.Github
{
    public interface IGitHubApi
    {
        [Get("/search/repositories?q={text}")]
        [Headers("User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.132 Safari/537.36")]
        Task<SearchResult> SearchAsync(string text);
    }
}
