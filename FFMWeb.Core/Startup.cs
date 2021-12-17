using FFMWeb.Core.API.Config;
using FFMWeb.Core.API.Helpers;
using FFMWeb.Core.API.Services;
using FFMWeb.Core.API.Services.Interfaces;
using FFMWebCore.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFMWeb.Core.API
{
    public class Startup
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public IConfiguration Configuration { get; set; }

        public Startup (IConfiguration config)
        {
            Configuration = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddCors(cfg =>
            {
                cfg.AddPolicy("Default", policy =>
                {
                    policy.AllowAnyMethod();
                    policy.AllowAnyHeader();
                    policy.AllowAnyOrigin();
                });
            });

            services.AddOpenApiDocument(doc =>
            {
                doc.Title = "FFM WEB API";
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // service for managing Authorization-Tokens
            .AddJwtBearer(options =>
            {
                options.Authority = "https://ffmweb.eu.auth0.com/";
                options.Audience = "https://api.ffmweb.de";

                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = HelperMethods.OnTokenValidated
                };
            });

            services.AddDbContext<FootballContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });

            // testServices
            services.AddTransient<IValuesService, ValuesService>();
            services.AddSingleton<IShoppingListService, ShoppingListService>();

            var mapper = AutoMapperConfig.ConfigureAutoMapper();
            services.AddSingleton(mapper);

            // inject UsersService
            services.AddScoped<IUsersService, UsersService>();
            // inject UserTeamsService
            services.AddScoped<IUserTeamsService, UserTeamsService>();
            // inject PlayersService
            services.AddScoped<IPlayersService, PlayersService>();
            // inject TeamsService
            services.AddScoped<ITeamsService, TeamsService>();
            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("Default");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
             
            app.UseOpenApi();

            //app.Use(async (ctx, next) =>
            //{

            //});
            
            app.UseSwaggerUi3(cfg =>
            {
                cfg.Path = "/swagger";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
