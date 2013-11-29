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
    }
}
