using net6OnionArc.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net6OnionArc.Application.Repositories.Abstract
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        bool Delete(T model);
        bool DeleteRange(List<T> datas);
        Task<bool> DeleteByIdAsync(string id);
        bool Update(T model);
        Task<int> SaveAsync();
    }
}
