using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalInterview_FeedReader.Data.Entities
{
    public class StoryStatus : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual User User { get; set; }

        [Required]
        public virtual Story Story { get; set; }

        [Required]
        public bool IsRead { get; set; }

        public DateTime? ReadOn { get; set; }
    }
}