using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TechnicalInterval_FeedReader.Services.Feeds;
using TechnicalInterview_FeedReader.Data.Entities;
using TechnicalInterview_FeedReader.Data.Repository;
using TechnicalInterview_FeedReader.Models;

namespace TechnicalInterview_FeedReader.Controllers
{
    [RoutePrefix("api/feeds")]
    public class FeedsController : ApiController
    {
        private readonly IFeedRepository _feedRepository;
        private readonly IFeedService _feedService;

        public FeedsController(IFeedRepository feedRepository, IFeedService feedService)
        {
            _feedRepository = feedRepository;
            _feedService = feedService;
        }

        [HttpGet]
        [Route("")]
        public IList<FeedModel> Get()
        {
            return _feedRepository.GetAll().OrderBy(c => c.Name).Select(ToViewModel).ToList();
        }

        [HttpPost]
        [Route("")]
        public FeedModel Post([FromBody]string feedUrl)
        {
            var feed = _feedService.AddSubscription(null, feedUrl);
            return ToViewModel(feed);
        }
            
        [HttpGet]
        [Route("{feedId:int}/stories")]
        public IList<StoryModel> ListStories(int feedId)
        {
            return _feedRepository.FindStories(feedId).Select(ToViewModel).ToList();
        }

        [HttpPost]
        [Route("search")]
        public IList<StoryModel> SearchFeeds([FromBody]string searchText)
        {
            return _feedRepository.SearchFeeds(searchText).Select(ToViewModel).ToList();
        }

        [HttpPost]
        [Route("refresh")]
        public void RefreshFeeds()
        {
                        
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
