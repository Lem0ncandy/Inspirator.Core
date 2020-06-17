using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inspirator.IRepository
{
    public interface IUnitOfWork
    {
        Task<bool> SaveAsync();
        bool Save();
    }
}
