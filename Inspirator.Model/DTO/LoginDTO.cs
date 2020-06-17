using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inspirator.Model.DTO
{
    public class LoginDTO : IValidatableObject
    {
        public string password { get; set; }
        public string username { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                yield return new ValidationResult("password is null");
            }
            if (string.IsNullOrWhiteSpace(username))
            {
                yield return new ValidationResult("username is null");
            }
        }
    }
}
