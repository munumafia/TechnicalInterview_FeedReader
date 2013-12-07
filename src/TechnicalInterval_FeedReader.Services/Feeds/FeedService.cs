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
        private readonly IStoryRepository _storyRepository;
        private readonly IFeedParser _feedParser;

        public FeedService(IFeedRepository feedRepository, IStoryRepository storyRepository, 
            IFeedParser feedParser)
        {
            _feedRepository = feedRepository;
            _storyRepository = storyRepository;
            _feedParser = feedParser;
        }

        public Feed AddSubscription(string username, string feedUrl)
        {

            var feed = _feedRepository.FindByUrl(feedUrl) ?? _feedParser.ParseFeed(feedUrl);
            _feedRepository.AddForUser(username, feed);
            _feedRepository.SaveChanges();

            return feed;
        }

        public void RefreshFeeds(string username)
        {
            var feeds = _feedRepository.FindForUsername(username);
            feeds.ToList().ForEach(RefreshFeed);
            _feedRepository.SaveChanges();
        }

        private void RefreshFeed(Feed existing)
        {
            var feed = _feedParser.ParseFeed(existing.Url);
            feed.LastCheckedOn = DateTime.Now;
            
            // TODO: Find a better way to check for existing stories, this will
            // kill performance as we add more and more feeds
            foreach (var story in feed.Stories)
            {
                if (_storyRepository.StoryExists(story.ExternalId))
                {
                    // We're only interested in new stories that we want to add
                    // to the database
                    continue;
                }

                feed.Stories.Add(story);
            }
        }
    }
}
