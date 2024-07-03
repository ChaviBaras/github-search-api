using github_search_api.Models;
using github_search_api.Services.Bookmark;
using github_search_api.Services.Github;

namespace UnitTests
{
    public class ServicesTest
    {
        [Fact]
        public async Task GithubServiceTest()
        {
            IGithubService service = new GithubService();
            var spec = new RepositorySearch()
            {
                Text = "Phoenix"
            };

            var results = await service.SearchAsync(spec);

            Assert.NotNull(results);
        }

        [Fact]
        public async Task BookmarkServiceTest()
        {
            IBookmarkService service = new BookmarkService();
            var item = new BookmarkInput()
            {
                UserId = Guid.NewGuid().ToString(),
                Repository = new Repository()
            };

            await service.BookmarkAsync(item);
            var bookmarks = await service.GetBookmarksAsync(item.UserId);

            Assert.NotNull(bookmarks);
            Assert.Single(bookmarks);
        }
    }
}