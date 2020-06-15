using System;
using System.Collections.Generic;
using System.Text;

namespace Inspirator.Model.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string Avatar { get; set; }
        public virtual ICollection<UserIdentity> UserIdentitys { get; set; }
    }
}
