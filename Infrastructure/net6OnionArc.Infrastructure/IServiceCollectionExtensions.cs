using Microsoft.Extensions.DependencyInjection;
using net6OnionArc.Application.Abstractions.Storage;
using net6OnionArc.Infrastructure.Enums;
using net6OnionArc.Infrastructure.Services.Concrete.Storage;
using net6OnionArc.Infrastructure.Services.Concrete.Storage.Local;

namespace net6OnionArc.Infrastructure
{
    public static class IServiceCollectionExtensions
    {
        public static void RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IStorageService, StorageService>();
        }

        public static void AddStorage<T>(this IServiceCollection services) where T : class, IStorage
        {
           services.AddScoped<IStorage,T>();
        }

        public static void AddStorage(this IServiceCollection services, StorageType storageType)
        {

            switch (storageType)
            {
                case StorageType.Local:
                    services.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    break;
                case StorageType.AWS:
                    break;
                default:
                    services.AddScoped<IStorage, LocalStorage>();
                    break;
            }           
        }
    }
}
