using System;
using System.Collections.Generic;
using System.Text;

namespace Inspirator.Model.DTO.Enum
{
    public enum StatusCode
    {
        #region Sucess
        Sucess = 1000,
        #endregion
        #region Erroe
        /// <summary>
        /// 未知错误
        /// </summary>
        UnkowError = 2001,
        /// <summary>
        /// 无权限
        /// </summary>
        NoPermission = 2004,
        /// <summary>
        /// 认证失败
        /// </summary>
        AuthenticationFailed = 2005,
        /// <summary>
        /// 资源不存在
        /// </summary>
        NotFound = 2007,
        /// <summary>
        /// 参数错误
        /// </summary>
        ParameterErroe = 2006,
        /// <summary>
        /// 令牌失效
        /// </summary>
        TokenInvalidation = 2006
        #endregion
    }
}
