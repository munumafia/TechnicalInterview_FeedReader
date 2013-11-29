using System;
using System.Linq;
using Argotic.Syndication;
using TechnicalInterview_FeedReader.Data.Entities;

namespace TechnicalInterval_FeedReader.Services.Feeds
{
    public class FeedParser : IFeedParser
    {
        public Feed ParseFeed(string url)
        {
            var reader = RssFeed.Create(new Uri(url));
            var feed = new Feed
                {
                    Url = url,
                    Name = reader.Channel.Title
                };

            feed.Stories = reader.Channel.Items.Select(i => new Story()
                {
                    Title = i.Title,
                    PublishedOn = i.PublicationDate,
                    Body = i.Description,
                    Url = i.Link.ToString()
                }).ToList();

            return feed;
        }
    }
}
