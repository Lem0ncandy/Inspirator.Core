using System;
using System.Collections.Generic;
using System.Text;

namespace Inspirator.Model.DTO
{
    public class PaginationDTO<T> where T : class
    {
        public int Count { get; set; }
        public T Data { get; set; }

        public PaginationDTO(int count, T data)
        {
            Count = count;
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }
        public PaginationDTO()
        {

        }
    }
}
