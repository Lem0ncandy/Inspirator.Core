using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inspirator.Model.DTO
{
    public class PaginationParameterDTO : IValidatableObject
    {
        public int Page { get; set; }
        public int Size { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Page < 1)
            {
                yield return new ValidationResult("Page is less then 1!");
            }
            if (Size < 1)
            {
                yield return new ValidationResult("Size is less then 1!");
            }
        }
    }
}
