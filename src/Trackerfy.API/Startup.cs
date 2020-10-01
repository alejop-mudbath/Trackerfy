using System;
using System.Security.Claims;
using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Trackerfy.API.Common;
using Trackerfy.Application;
using Trackerfy.Application.Common.Interfaces;
using Trackerfy.Infrastructure;

namespace Trackerfy.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string domain = $"https://{Configuration["Auth0:Domain"]}/";
            string audience = Configuration["Auth0:Audience"];
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = domain;
                    options.Audience = audience;
                });

            services.AddHttpClient("auth0", c =>
            {
                c.BaseAddress = new Uri(domain);
                c.DefaultRequestHeaders.Add("Authorization", $"Bearer {Configuration["Auth0:MAPI-token"]}");
            });

            services.AddApplication();
            services.AddInfrastructure(Configuration);

            services.AddControllers().AddNewtonsoftJson();

            services.AddValidatorsFromAssembly(typeof(IContext).Assembly);

            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()));

            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAll");

            //    app.UseOpenApi(); // serve OpenAPI/Swagger documents
            app.UseSwaggerUi3(); // serve Swagger UI
            //  app.UseReDoc(); // serve ReDoc UI

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomExceptionHandler();
            app.UseHttpsRedirection();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMvc();

        }
    }
}