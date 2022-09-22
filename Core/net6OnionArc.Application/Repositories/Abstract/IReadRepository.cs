using net6OnionArc.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace net6OnionArc.Application.Repositories.Abstract
{
    public interface IReadRepository<T> :IRepository<T> where T : BaseEntity, new()
    {
        IQueryable<T> GetAll(bool tracking);
        IQueryable<T> GetAll(Expression<Func<T,bool>> filter, bool tracking);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, bool tracking);
        Task<T> GetByIdAsync(string id, bool tracking);
    }
}
