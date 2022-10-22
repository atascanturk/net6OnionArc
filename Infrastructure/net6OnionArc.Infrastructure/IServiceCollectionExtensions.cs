using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using net6OnionArc.Application.Repositories;
using net6OnionArc.Application.Services.Abstract;
using net6OnionArc.Infrastructure.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net6OnionArc.Infrastructure
{
    public static class IServiceCollectionExtensions
    {
        public static void RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();

        }
    }
}
