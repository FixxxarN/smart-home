using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using smart_home_backend.Datasource.Context;
using smart_home_backend.Hubs;
using smart_home_backend.Mappers;
using smart_home_backend.Repositories;
using smart_home_backend.Services;

namespace smart_home_backend
{
    public class Startup
    {
        readonly string SpecificOrigins = "_specificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: SpecificOrigins, builder =>
                {
                    builder.WithOrigins("http://localhost:8080", "http://localhost:5000", "https://localhost:5001").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                });
            });
            services.AddControllers();
            services.AddMvc();
            services.AddRazorPages();
            services.AddSignalR();
            services.AddDbContext <Datasource.Context.smart_home_backend_context>(options => 
            options.UseSqlite("Data Source=SmartHome.db", db => {
                db.MigrationsAssembly("smart-home-backend");
            }));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PersonMapper());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            ConfigureRepositories(services);
        }

        protected virtual void ConfigureRepositories(IServiceCollection services)
        {
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IPersonService, PersonService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, smart_home_backend_context context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            context.Database.MigrateAsync();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(SpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<SmartHomeHub>("/hub");
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
