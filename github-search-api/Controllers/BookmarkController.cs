using github_search_api.Models;
using github_search_api.Services.Bookmark;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace github_search_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookmarkController : ControllerBase
    {
        private readonly ILogger<BookmarkController> _logger;

        private IBookmarkService _bookmarkService;
        private string UserId => this.User.Identity.Name;

        public BookmarkController(ILogger<BookmarkController> logger, IBookmarkService bookmarkService)
        {
            _logger = logger;
            _bookmarkService = bookmarkService;
        }

        // GET: api/Bookmark
        [HttpGet]
        public async Task<Repository[]> Get()
        {
            var model = await _bookmarkService.GetBookmarksAsync(this.UserId);
            return model;
        }

        // POST: api/Bookmark
        [HttpPost]
        public async Task Post([FromBody] Repository request)
        {
            var item = new BookmarkInput()
            {
                Repository = request,
                UserId = UserId
            };

            await this._bookmarkService.BookmarkAsync(item);
        }

        // POST: api/Unmark
        [HttpDelete]
        public async Task Delete([FromBody] Repository request)
        {
            var item = new BookmarkInput()
            {
                Repository = request,
                UserId = UserId
            };

            await this._bookmarkService.UnmarkAsync(item);
        }
    }
}
