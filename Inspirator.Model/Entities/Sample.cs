using System;
using System.Collections.Generic;

namespace Inspirator.Model.Entities
{
    public class Sample :BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid SurveyId { get; set; }
        public Survey Survey { get; set; }
        public int Score { get; set; }
        public virtual IList<SampleOption> SampleOptions { get; set; }
    }
}
