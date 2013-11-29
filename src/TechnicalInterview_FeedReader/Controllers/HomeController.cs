using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnicalInterval_FeedReader.Services.Feeds;
using TechnicalInterview_FeedReader.Data.Repository;

namespace TechnicalInterview_FeedReader.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var feedParser = new FeedParser();
            var feedRepo = new FeedRepository();
            var feedService = new FeedService(feedRepo, feedParser);

            const string url = "http://www.hanselman.com/blog/SyndicationService.asmx/GetRss";
            feedService.AddSubscription(null, url);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
