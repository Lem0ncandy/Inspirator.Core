using Inspirator.Model.DTO.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inspirator.Model.DTO
{
    public class UnifyResponseDto
    {
        public StatusCode Code { get; set; }
        public object Message { get; set; }

        public UnifyResponseDto(StatusCode code, object message)
        {
            Code = code;
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }

        public UnifyResponseDto()
        {
        }

        public static UnifyResponseDto Sucess(string message = "sucess")
        {
            return new UnifyResponseDto
            {
                Code = StatusCode.Sucess,
                Message = message
            };
        }
        public static UnifyResponseDto Fail(StatusCode code = StatusCode.UnkowError,string message = "fail")
        {
            return new UnifyResponseDto
            {
                Code = code,
                Message = message
            };
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
