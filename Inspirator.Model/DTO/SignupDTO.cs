using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text;

namespace Inspirator.Model.DTO
{
    public class SignupDTO : IValidatableObject
    {
        [StringLength(12,MinimumLength = 4,ErrorMessage ="用户名长度必须在4~12之间")]
        public string Username { get; set; }
        [StringLength(18, MinimumLength = 6, ErrorMessage = "密码长度必须在6~18之间")]
        [Required(ErrorMessage ="密码不可为空")]
        public string Password { get; set; }
        [Required(ErrorMessage ="邮件不为空")]
        public string Email { get; set; }
        [StringLength(maximumLength:10, ErrorMessage= "昵称长度必须在10个以内之间")]
        public string NickName { get; set; }
        [StringLength(maximumLength: 20, ErrorMessage = "号码太长了")]
        public string PhoneNumber { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Email))
            {
                string address = null;
                try
                {
                    address = new MailAddress(Email).Address;
                }
                catch
                {

                }
                if (string.IsNullOrEmpty(address))
                {
                    yield return new ValidationResult("电子邮箱不和规范，请输入正确的邮箱");
                }
            }
        }
    }
}
