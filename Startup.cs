using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using CoreAPIAndEfCore.Services;
using CoreAPIAndEfCore.MapperConfig;
using System.Reflection;
using CoreAPIAndEfCore.Attributes;
using Scrutor;
using CoreAPIAndEfCore.ServiceExtension;

namespace CoreAPIAndEfCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // RegisterServices(services);
            services.AddControllers();
            // services.AddScoped<ICharacterservice, CharacterService>();
            services.AddNonGenericServices();
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
        private static void RegisterServices(IServiceCollection services)
        {

            var assembly = Assembly.LoadFrom(
                $"{System.IO.Path.GetDirectoryName(typeof(Startup).Assembly.Location)}\\CoreAPIAndEfCore.dll"

            );
            services.Scan(scan =>
            scan.FromAssemblies(assembly)
            .AddClasses(classes => classes.WithAttribute<Injectable>(), true)
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
