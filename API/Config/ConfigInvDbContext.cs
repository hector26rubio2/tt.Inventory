namespace API.Config
{
    using Infrastructure.Config;
    using Microsoft.EntityFrameworkCore;

    public static class ConfigInvDbContext
    {
        public static IServiceCollection AddInfrastructureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InvDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("PostgreSqlConnection"),
                    npgsqlOptions => npgsqlOptions.MigrationsAssembly("Infrastructure")
                ));

            return services;
        }
    }
}
