using github_search_api.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace github_search_api.Services.Bookmark
{
    public class BookmarkService : IBookmarkService
    {
        private readonly IDictionary<string, HashSet<Repository>> _memoryRepository =
            new ConcurrentDictionary<string, HashSet<Repository>>();

        public async Task<Repository[]> GetBookmarksAsync(string userId)
        {
            var items = GetByUserId(userId);

            return await Task.FromResult(items.ToArray());
        }

        public async Task BookmarkAsync(BookmarkInput input)
        {
            var items = GetByUserId(input.UserId);

            items.Add(input.Repository);

            await Task.CompletedTask;
        }

        public async Task UnmarkAsync(BookmarkInput input)
        {
            var items = GetByUserId(input.UserId);

            items.Remove(input.Repository);

            await Task.CompletedTask;
        }

        private HashSet<Repository> GetByUserId(string userId)
        {

            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if (!_memoryRepository.ContainsKey(userId))
            {
                _memoryRepository[userId] = new HashSet<Repository>();
            }

            return _memoryRepository[userId];
        }
    }
}
