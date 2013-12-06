using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalInterview_FeedReader.Data.Entities;

namespace TechnicalInterview_FeedReader.Data.Repository
{
    public interface IStoryRepository : IRepository<Story>
    {
        List<Story> FindAllForUser(string username);
    }
}
