using System;
using System.Collections.Generic;

namespace Inspirator.Model.DTO
{
    public class SubmitSampleDTO
    {
        public Guid Id { get; set; }
        public IList<int> Options { get; set; }
    }
}
