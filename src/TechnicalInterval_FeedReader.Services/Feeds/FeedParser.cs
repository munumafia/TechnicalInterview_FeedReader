using System;
using System.Linq;
using Argotic.Common;
using Argotic.Syndication;
using TechnicalInterview_FeedReader.Data.Entities;

namespace TechnicalInterval_FeedReader.Services.Feeds
{
    public class FeedParser : IFeedParser
    {
        public Feed ParseFeed(string url)
        {
            var genericFeed = GenericSyndicationFeed.Create(new Uri(url));
            var format = genericFeed.Format;
            Feed feed = null;

            switch (format)
            {
                case SyndicationContentFormat.Rss:
                    feed = ParseRssFeed(genericFeed, url);
                    break;
                case SyndicationContentFormat.Atom:
                    feed = ParseAtomFeed(genericFeed, url);
                    break;
            }

            return feed;
        }

        private Feed ParseRssFeed(GenericSyndicationFeed genericFeed, string url)
        {
            var rssReader = (RssFeed)genericFeed.Resource;
            var rssFeed = new Feed
            {
                Url = url,
                Name = rssReader.Channel.Title
            };

            rssFeed.Stories = rssReader.Channel.Items.Select(i => new Story()
            {
                Title = i.Title,
                PublishedOn = i.PublicationDate,
                Body = i.Description,
                Url = i.Link.ToString(),
                ExternalId = i.Guid.Value
            }).ToList();

            return rssFeed;
        }

        private Feed ParseAtomFeed(GenericSyndicationFeed genericFeed, string url)
        {
            var atomReader = (AtomFeed)genericFeed.Resource;
            var atomFeed = new Feed
            {
                Url = url,
                Name = atomReader.Title.Content
            };

            atomFeed.Stories = atomReader.Entries.Select(i => new Story()
            {
                Title = i.Title.Content,
                PublishedOn = i.UpdatedOn,
                Body = i.Content.Content,
                Url = i.Id.Uri.ToString(),
                ExternalId = i.Id.Uri.ToString()
            }).ToList();

            return atomFeed;
        }
    }
}