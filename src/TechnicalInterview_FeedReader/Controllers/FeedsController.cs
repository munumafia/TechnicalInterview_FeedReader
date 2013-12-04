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
        [HttpGet]
        [Route("")]
        public IList<FeedModel> Get()
        {
            var feedRepo = new FeedRepository();
            return feedRepo.GetAll().OrderBy(c => c.Name).Select(ToViewModel).ToList();
        }

        [HttpGet]
        [Route("{feedId:int}/stories")]
        public IList<StoryModel> ListStories(int feedId)
        {
            var feedRepo = new FeedRepository();
            return feedRepo.FindStories(feedId).Select(ToViewModel).ToList();
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
