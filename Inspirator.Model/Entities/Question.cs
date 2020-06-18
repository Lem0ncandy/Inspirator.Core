using System;
using System.Collections.Generic;

namespace Inspirator.Model.Entities
{
    public class Question : BaseEntity
    {
        public string Title { get; set; }
        public int Index { get; set; }

        public Guid SurveyId { get; set; }
        public Survey Survey { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}
