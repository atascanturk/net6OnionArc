using Microsoft.EntityFrameworkCore;
using net6OnionArc.Domain.Entities;
using net6OnionArc.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net6OnionArc.Persistence.Context
{
    public class OnionArcDbContext : DbContext
    {
        public OnionArcDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                 switch (data.State)
                 {
                    case EntityState.Added:
                        data.Entity.CreatedDate = DateTime.UtcNow;
                        break;


                     case EntityState.Modified :
                        data.Entity.ModifiedDate = DateTime.UtcNow;
                        break;

                    default:
                        break;
                            
                 };
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
