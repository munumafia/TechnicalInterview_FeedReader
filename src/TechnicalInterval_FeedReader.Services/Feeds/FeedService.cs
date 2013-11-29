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

        public void AddSubscription(User user, string feedUrl)
        {
            var feed = _feedRepository.FindByUrl(feedUrl);
            if (feed == null)
            {
                feed = _feedParser.ParseFeed(feedUrl);
                _feedRepository.Add(feed);
                _feedRepository.SaveChanges();
            }
        }
    }
}
