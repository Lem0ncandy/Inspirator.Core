using Inspirator.Model.DTO.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Inspirator.Model.Entities
{
    public class Option :BaseEntity 
    {
        [Required]
        public string Summary { get; set; }
        [Required]
        public int Index { get; set; }
        [Required]
        public int QuestionIndex { get; set; }
        public OptionIndexType Type { get; set; } = OptionIndexType.Number;

        public Guid QuestionId { get; set; }
        public Question Question { get; set; }

        public Option(string summary, int index)
        {
            Summary = summary;
            Index = index;
        }
    }
}
