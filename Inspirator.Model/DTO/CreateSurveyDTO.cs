using Inspirator.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inspirator.Model.DTO
{
    public class CreateSurveyDTO
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}
