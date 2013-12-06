using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalInterview_FeedReader.Data.Entities;
using TechnicalInterview_FeedReader.Data.Repository;

namespace TechnicalInterval_FeedReader.Services.Feeds
{
    public class FeedService : IFeedService 
    {
        private readonly IFeedRepository _feedRepository;
        private readonly IFeedParser _feedParser;

        public FeedService(IFeedRepository feedRepository, IFeedParser feedParser)
        {
            _feedRepository = feedRepository;
            _feedParser = feedParser;
        }

        public Feed AddSubscription(string username, string feedUrl)
        {

            var feed = _feedRepository.FindByUrl(feedUrl) ?? _feedParser.ParseFeed(feedUrl);
            _feedRepository.AddForUser(username, feed);
            _feedRepository.SaveChanges();

            return feed;
        }

        public void RefreshFeeds(User user)
        {
            throw new NotImplementedException();
        }
    }
}
