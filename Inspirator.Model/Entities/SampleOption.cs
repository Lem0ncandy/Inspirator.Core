using System;
using System.Collections.Generic;
using System.Text;

namespace Inspirator.Model.Entities
{
    public class SampleOption : BaseEntity
    {
        public Guid SampleId { get; set; }
        public Sample Sample { get; set; }
        public Guid OptionId { get; set; }
        public Option Option { get; set; }
    }
}
