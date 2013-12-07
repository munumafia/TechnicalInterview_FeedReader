using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalInterview_FeedReader.Data.Entities;

namespace TechnicalInterview_FeedReader.Data.Repository
{
    public class StoryRepository : Repository<Story>, IStoryRepository
    {
        public List<Story> FindAllForUser(string username)
        {
            return FeedContext.Users.Where(u => u.UserName == username)
                .SelectMany(f => f.Feeds.SelectMany(s => s.Stories))
                .OrderByDescending(f => f.PublishedOn)
                .ToList();
        }

        public bool StoryExists(string externalId)
        {
            return true;
        }
    }
}
