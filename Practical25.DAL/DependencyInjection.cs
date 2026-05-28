namespace Practical25.DAL;

public static class DependencyInjection
{
    public static IServiceCollection AddDAL(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped(typeof(GenericRepo<>));
        services.AddScoped<EmployeeCommandRepo>();
        services.AddScoped<EmployeeQueryRepo>();

        return services;
    }
}
