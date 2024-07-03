using github_search_api.Models;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace github_search_api.Services.Github
{
    public class GithubService : IGithubService
    {
        // The GitHub API URL
        private readonly string apiUrl = "https://api.github.com";
        private IGitHubApi apiProxy;

        public GithubService()
        {
            this.apiProxy = RestService.For<IGitHubApi>(apiUrl);
        }

        public async Task<SearchResult> SearchAsync(RepositorySearch input)
        {
            // Validate search term
            if (input == null || string.IsNullOrEmpty(input.Text))
            {
                throw new ArgumentException("Search input cannot be empty");
            }

            return await apiProxy.SearchAsync(input.Text);
        }
    }
}
