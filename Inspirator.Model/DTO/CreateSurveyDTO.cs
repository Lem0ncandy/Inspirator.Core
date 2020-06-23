using Inspirator.Model.Entities;
using Inspirator.Model.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inspirator.Model.DTO
{
    public class CreateSurveyDTO
    {
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        public string Summary { get; set; }
        public OptionType OptionType { get; set; }
        public IList<SubjectDTO> SubjectDTOs { get; set; }
        public IList<OptionDTO> OptionDTOs { get; set; }
    }
}
