using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalInterview_FeedReader.Data.Entities
{
    public class User : IEntity
    {
        public User()
        {
            CreatedOn = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<Feed> Feeds { get; set; }
    }
}
