using github_search_api.Models;
using System.Threading.Tasks;

namespace github_search_api.Services.Github
{
    public interface IGithubService
    {
        Task<SearchResult> SearchAsync(RepositorySearch term);
    }
}
