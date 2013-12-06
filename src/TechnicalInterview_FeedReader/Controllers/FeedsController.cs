using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using TechnicalInterval_FeedReader.Services.Feeds;
using TechnicalInterview_FeedReader.Data.Entities;
using TechnicalInterview_FeedReader.Data.Repository;
using TechnicalInterview_FeedReader.Models;

namespace TechnicalInterview_FeedReader.Controllers
{
    public class FeedsController : ApiController
    {
        private readonly IFeedRepository _feedRepository;
        private readonly IFeedService _feedService;
        private readonly IStoryRepository _storyRepository;

        public FeedsController(IFeedRepository feedRepository, IFeedService feedService, IStoryRepository storyRepository)
        {
            _feedRepository = feedRepository;
            _feedService = feedService;
            _storyRepository = storyRepository;
        }

        [HttpGet]
        [Route("api/feeds")]
        public IList<FeedModel> Get()
        {
            return _feedRepository.GetAll().OrderBy(c => c.Name).Select(ToViewModel).ToList();
        }

        [HttpPost]
        [Route("api/feeds")]
        public FeedModel Post([FromBody]string feedUrl)
        {
            var username = Thread.CurrentPrincipal.Identity.Name;
            var feed = _feedService.AddSubscription(username, feedUrl);
            return ToViewModel(feed);
        }
            
        [HttpGet]
        [Route("api/feeds/{feedId:int}/stories")]
        public IList<StoryModel> ListStories(int feedId)
        {
            return _feedRepository.FindStories(feedId).Select(ToViewModel).ToList();
        }

        [HttpPost]
        [Route("api/feeds/search")]
        public IList<StoryModel> SearchFeeds([FromBody]string searchText)
        {
            return _feedRepository.SearchFeeds(searchText).Select(ToViewModel).ToList();
        }

        [HttpPost]
        [Route("api/feeds/refresh")]
        public void RefreshFeeds()
        {
                        
        }

        [HttpGet]
        [Route("api/stories")]
        public IList<StoryModel> ListAllStories()
        {
            var username = Thread.CurrentPrincipal.Identity.Name;
            return _storyRepository.FindAllForUser(username).Select(ToViewModel).ToList();
        }

        private FeedModel ToViewModel(Feed feed)
        {
            return new FeedModel
                {
                    Id = feed.Id,
                    Name = feed.Name,
                    Url = feed.Url,
                    UnreadCount = feed.Stories.Count()
                };
        }

        private StoryModel ToViewModel(Story story)
        {
            return new StoryModel
                {
                    Id = story.Id,
                    Body = story.Body,
                    PublishedOn = story.PublishedOn,
                    IsRead = false,
                    Title = story.Title,
                    Url = story.Url
                };
        }
    }
}
