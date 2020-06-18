using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inspirator.Model.Entities
{
    public class Survey : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Summary { get; set; }
        public int StarCount { get; set; }
        public int ViewCount { get; set; }
        public ICollection<Question> Questions { get; set; }
        public Survey(string title, string summary)
        {
            Title = title;
            Summary = summary;
        }
    }
}
