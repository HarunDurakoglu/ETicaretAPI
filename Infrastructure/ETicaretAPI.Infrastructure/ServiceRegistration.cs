using ETicaretAPI.Application.Abstractions.Storage;
using ETicaretAPI.Application.Abstractions.Token;
using ETicaretAPI.Application.Identity;
using ETicaretAPI.Infrastructure.Identity.Service;
using ETicaretAPI.Infrastructure.Services.Storage;
using ETicaretAPI.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;


namespace ETicaretAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<IIdentityService, IdentityService>();
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
        }
        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : class, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
    }
}
