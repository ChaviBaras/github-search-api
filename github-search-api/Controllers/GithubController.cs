using github_search_api.Models;
using github_search_api.Services.Github;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace github_search_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GithubController : ControllerBase
    {
        private readonly ILogger<GithubController> _logger;
        private IGithubService _githubService;

        public GithubController(ILogger<GithubController> logger, IGithubService githubService)
        {
            _logger = logger;
            _githubService = githubService;
        }


        // GET: api/Bookmark
        [HttpGet("Search")]
        public async Task<SearchResult> Get([FromQuery] RepositorySearch request)
        {
            var input = new RepositorySearch()
            {
                Text = request.Text
            };

            return await this._githubService.SearchAsync(input);
        }
    }
}
