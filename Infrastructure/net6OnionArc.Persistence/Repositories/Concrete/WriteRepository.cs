using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using net6OnionArc.Application.Repositories.Abstract;
using net6OnionArc.Domain.Entities.Common;
using net6OnionArc.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net6OnionArc.Persistence.Repositories.Concrete
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity, new()
    {
        readonly private OnionArcDbContext _context;

        public WriteRepository(OnionArcDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityState = await Table.AddAsync(model);

            return entityState.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public bool Delete(T model)
        {
            EntityEntry<T> entityState = Table.Remove(model);
            return entityState.State == EntityState.Deleted;
        }

        public async Task<bool> DeleteByIdAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            return Delete(model);
        }

        public bool DeleteRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
        

        public bool Update(T model)
        {
            EntityEntry entityState = Table.Update(model);
            return entityState.State == EntityState.Modified;
        }
    }
}
