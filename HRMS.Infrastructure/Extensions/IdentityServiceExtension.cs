using HRMS.Domain.SeedWork;
using HRMS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRMS.Infrastructure.Extensions;

public static class IdentityServiceExtension
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultString")));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericGenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddAutoMapper(typeof(IdentityServiceExtension));
        
        return services;
    }
}