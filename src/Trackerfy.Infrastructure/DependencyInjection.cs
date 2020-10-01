using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trackerfy.Application.Interfaces;
using Trackerfy.Infrastructure.Identity;
using Trackerfy.Infrastructure.Persistence;
using Trackerfy.Infrastructure.Persistence.Issues;
using Trackerfy.Infrastructure.Persistence.IssueStates;
using Trackerfy.Infrastructure.Persistence.IssueTypes;

namespace Trackerfy.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(Context).Assembly.FullName)));

            services.AddScoped<IContext>(provider => provider.GetService<Context>());
            services.AddScoped<IIssueRepository, IssueRepository>();
            services.AddScoped<IIssueTypeRepository, IssueTypeRepository>();
            services.AddScoped<IIssueStateRepository, IssueStateRepository>();


            services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<Context>();

            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}