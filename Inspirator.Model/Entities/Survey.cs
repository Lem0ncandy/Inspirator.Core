using System.Collections.Generic;

namespace Inspirator.Model.Entities
{
    public class Survey : BaseEntity
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public int StarCount { get; set; }
        public int ViewCount { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
