using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inspirator.Model.Entities
{
    public class Subject : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int Index { get; set; }

        public Guid SurveyId { get; set; }
        public Survey Survey { get; set; }
        public IList<Option> Options { get; set; }

        public Subject(string title, int index)
        {
            Title = title;
            Index = index;
        }
    }
}
