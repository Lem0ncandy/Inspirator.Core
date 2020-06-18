using Inspirator.Model.DTO.Enum;
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
        public OptionIndexType Type { get; set; } = OptionIndexType.Number;

        public ICollection<Subject> Subject { get; set; }
        public Survey(string title, string summary)
        {
            Title = title;
            Summary = summary;
        }
    }
}
