using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Trackerfy.Application.Interfaces;
using Trackerfy.Infrastructure.Persistence.Issues;
using Trackerfy.Infrastructure.Persistence.IssueTypes;

namespace Trackerfy.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<Context>(options =>
                options.UseSqlite("Data Source=trackerfy.db",
                    b => b.MigrationsAssembly(typeof(Context).Assembly.FullName)));

            services.AddScoped<IContext>(provider => provider.GetService<Context>());
            services.AddScoped<IIssueRepository, IssueRepository>();
            services.AddScoped<IIssueTypeRepository, IssueTypeRepository>();
            return services;
        }
    }
}
