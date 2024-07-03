using github_search_api.Models;
using System.Threading.Tasks;

namespace github_search_api.Services.Bookmark
{
    public interface IBookmarkService
    {
        Task<Repository[]> GetBookmarksAsync(string userId);
        Task BookmarkAsync(BookmarkInput input);
        Task UnmarkAsync(BookmarkInput input);
    }
}
