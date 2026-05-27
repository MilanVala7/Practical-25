using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Practical25.DAL.Data;
using Practical25.DAL.Repositories;

namespace Practical25.DAL;

public static class DependencyInjection
{
    public static IServiceCollection AddDal(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped(typeof(GenericRepo<>));
        services.AddScoped<EmployeeCommandRepo>();
        services.AddScoped<EmployeeQueryRepo>();

        return services;
    }
}
