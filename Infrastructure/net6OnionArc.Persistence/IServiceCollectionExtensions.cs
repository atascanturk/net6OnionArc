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
            services.AddDbContext<OnionArcDbContext>(options => options.UseNpgsql(Configurations.ConnectionString));
            services.AddScoped<ICustomerReadRepository,CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository,CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository,OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository,OrderWriteRepository>();
            services.AddScoped<IProductReadRepository,ProductReadRepository>();
            services.AddScoped<IProductWriteRepository,ProductWriteRepository>();

        }
    }
}
