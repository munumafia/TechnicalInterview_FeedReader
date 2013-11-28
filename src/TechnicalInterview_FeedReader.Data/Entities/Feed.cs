using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalInterview_FeedReader.Data.Entities
{
    public class Feed
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        public DateTime? LastCheckedOn { get; set; }

        public virtual ICollection<Story> Stories { get; set; }

        public virtual ICollection<User> Users { get; set; } 
    }
}
