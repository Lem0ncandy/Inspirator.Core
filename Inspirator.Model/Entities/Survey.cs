using Inspirator.Model.DTO.Enum;
using Inspirator.Model.Entities.Enum;
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
        public int StarCount { get; set; } = 0;
        public int ViewCount { get; set; } = 0;
        public OptionType OptionType { get; set; }

        public IList<Subject> Subjects { get; set; }
        public IList<Sample> Sample { get; set; }
        public Survey(string title, string summary, OptionType optionType)
        {
            Title = title;
            Summary = summary;
            OptionType = optionType;
        }
        private Survey()
        {

        }
    }
}
