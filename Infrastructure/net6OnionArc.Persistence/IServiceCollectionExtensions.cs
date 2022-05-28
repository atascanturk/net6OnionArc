using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using net6OnionArc.Application.Repositories;
using net6OnionArc.Persistence.Context;
using net6OnionArc.Persistence.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net6OnionArc.Persistence
{
    public static class IServiceCollectionExtensions
    {
        public static void RegisterPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<OnionArcDbContext>(options => options.UseNpgsql(Configurations.ConnectionString),ServiceLifetime.Singleton);
            services.AddSingleton<ICustomerReadRepository,CustomerReadRepository>();
            services.AddSingleton<ICustomerWriteRepository,CustomerWriteRepository>();
            services.AddSingleton<IOrderReadRepository,OrderReadRepository>();
            services.AddSingleton<IOrderWriteRepository,OrderWriteRepository>();
            services.AddSingleton<IProductReadRepository,ProductReadRepository>();
            services.AddSingleton<IProductWriteRepository,ProductWriteRepository>();

        }
    }
}
