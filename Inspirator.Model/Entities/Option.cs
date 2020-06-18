using Inspirator.Model.DTO.Enum;
using System;

namespace Inspirator.Model.Entities
{
    public class Option :BaseEntity 
    {
        public int MyProperty { get; set; }
        public int Index { get; set; }
        public OptionIndexType Type { get; set; } = OptionIndexType.Number;

        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
