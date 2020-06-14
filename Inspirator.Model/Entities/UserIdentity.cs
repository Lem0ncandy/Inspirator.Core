using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inspirator.Model.Entities
{
    public class UserIdentity : BaseEntity
    {
        public const string GitHub = "GitHub";
        public const string Password = "Password";
        public const string QQ = "QQ";
        public const string WeiXin = "WeiXin";
        /// <summary>
        ///认证类型， Password，GitHub、QQ、WeiXin等
        /// </summary>
        [Column(TypeName = "varchar(20)")]
        public string IdentityType { get; set; }

        /// <summary>
        /// 认证者，例如 用户名,手机号，邮件等，
        /// </summary>
        [Column(TypeName = "varchar(24)")]
        public string Identifier { get; set; }

        /// <summary>
        ///  凭证，例如 密码,存OpenId、Id，同一IdentityType的OpenId的值是唯一的
        /// </summary>
        [Column(TypeName = "varchar(50)")]
        public string Credential { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
