using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Trackerfy.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Context>(options =>
                options.UseSqlite("Data Source=trackerfy.db",
                    b => b.MigrationsAssembly(typeof(Context).Assembly.FullName)));

            services.AddScoped<IContext>(provider => provider.GetService<Context>());

            return services;
        }
    }
}
