using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inspirator.Model.Entities
{
    public class Question : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int Index { get; set; }

        public Guid SurveyId { get; set; }
        public Survey Survey { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}
