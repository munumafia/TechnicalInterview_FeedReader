using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalInterview_FeedReader.Data.Entities;

namespace TechnicalInterview_FeedReader.Data.Repository
{
    public class FeedRepository : Repository<Feed>, IFeedRepository
    {
        public bool FeedExists(string url)
        {
            return FeedContext.Feeds.Any(u => u.Url == url);
        }

        public Feed FindByUrl(string url)
        {
            return FeedContext.Feeds.SingleOrDefault(u => u.Url == url);
        }

        public IList<Story> FindStories(int feedId)
        {
            return FeedContext.Stories.Where(f => f.Feed.Id == feedId).ToList();
        }

        public IList<Story> SearchFeeds(string searchText)
        {
            return FeedContext.Stories.Where(f => f.Title.Contains(searchText))
                .ToList();
        }

        public void AddForUser(string username, Feed feed)
        {
            var user = FeedContext.Users.FirstOrDefault(u => u.UserName == username);
            if (user == null)
            {
                var errorMessage = string.Format(@"No user with username ""{0}""", username);
                throw new InvalidOperationException(errorMessage);
            }

            user.Feeds.Add(feed);
        }
    }
}
