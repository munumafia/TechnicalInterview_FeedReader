using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using TechnicalInterval_FeedReader.Services.Feeds;

namespace TechnicalInterview_FeedReader.IoC
{
    public class ServicesModule : NinjectModule 
    {
        public override void Load()
        {
            Bind<IFeedParser>().To<FeedParser>();
            Bind<IFeedService>().To<FeedService>();
        }
    }
}