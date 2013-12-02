using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalInterview_FeedReader.Models
{
    public class FeedModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int UnreadCount { get; set; }
    }

    public class StoryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Url { get; set; }
        public DateTime PublishedOn { get; set; }
        public bool IsRead { get; set; }
    }
}