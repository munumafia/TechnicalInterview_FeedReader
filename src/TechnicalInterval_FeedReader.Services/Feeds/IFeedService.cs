using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalInterview_FeedReader.Data.Entities;

namespace TechnicalInterval_FeedReader.Services.Feeds
{
    public interface IFeedService
    {
        Feed AddSubscription(string username, string feedUrl);
        void RefreshFeeds(string username);
    }
}
