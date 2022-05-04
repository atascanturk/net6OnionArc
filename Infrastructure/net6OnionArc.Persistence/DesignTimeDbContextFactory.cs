using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using net6OnionArc.Persistence.Context;
using System;
using Microsoft.Extensions.Configuration
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net6OnionArc.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OnionArcDbContext>
    {
        public OnionArcDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<OnionArcDbContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<OnionArcDbContext>();
            dbContextOptionsBuilder.UseNpgsql(Configurations.ConnectionString);
            return new OnionArcDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
