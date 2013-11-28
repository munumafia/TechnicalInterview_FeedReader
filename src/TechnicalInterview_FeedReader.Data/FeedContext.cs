using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalInterview_FeedReader.Data.Entities;

namespace TechnicalInterview_FeedReader.Data
{
    public class FeedContext : DbContext 
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Story> Stories { get; set; }
    }
}