using Microsoft.EntityFrameworkCore;
using net6OnionArc.Application.Repositories.Abstract;
using net6OnionArc.Domain.Entities.Common;
using net6OnionArc.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace net6OnionArc.Persistence.Repositories.Concrete
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity, new()
    {
        private readonly OnionArcDbContext _context;

        public ReadRepository(OnionArcDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }


        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter, bool tracking = true) 
        {
            var query = Table.Where(filter);
            if (!tracking)
                query = query.AsNoTracking();
            return query;           
        }


        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, bool tracking = true) 
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(filter);
        }


        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        } 
      
    }
}
