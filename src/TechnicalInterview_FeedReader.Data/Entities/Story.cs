using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalInterview_FeedReader.Data.Entities
{
    public class Story : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public DateTime PublishedOn { get; set; }

        public virtual Feed Feed { get; set; }

        public ICollection<StoryStatus> StoryStatuses { get; set; } 
    }
}