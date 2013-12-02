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
    public class FeedsController : ApiController
    {
        public IList<FeedModel> Get()
        {
            var feedRepo = new FeedRepository();
            return feedRepo.GetAll().OrderBy(c => c.Name).Select(ToViewModel).ToList();
        }

        [HttpGet]
        [Route("{id:int}/stories")]
        public IList<StoryModel> ListStories()
        {
            return new List<StoryModel>();
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
    }
}
