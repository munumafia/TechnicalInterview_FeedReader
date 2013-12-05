using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using Ninject.Web.Common;
using TechnicalInterview_FeedReader.Data.Repository;

namespace TechnicalInterview_FeedReader.IoC
{
    public class DataModule : NinjectModule 
    {
        public override void Load()
        {
            Bind<IFeedRepository>().To<FeedRepository>().InRequestScope();
        }
    }
}