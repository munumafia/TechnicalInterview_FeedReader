using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalInterview_FeedReader.Data.Entities;

namespace TechnicalInterview_FeedReader.Data.Repository
{
    public interface IFeedRepository : IRepository<Feed>
    {
        bool FeedExists(string url);
        Feed FindByUrl(string url);
        IList<Story> FindStories(int feedId);
        IList<Story> SearchFeeds(string searchText);
        void AddForUser(string username, Feed feed);
    }
}
