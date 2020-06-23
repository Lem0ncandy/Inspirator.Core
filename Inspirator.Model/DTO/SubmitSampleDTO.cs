using System;
using System.Collections.Generic;
using System.Text;

namespace Inspirator.Model.DTO
{
    public class SubmitSampleDTO
    {
        public Guid Id { get; set; }
        public IList<int> Options { get; set; }
    }
}
