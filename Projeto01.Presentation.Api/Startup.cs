using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Projeto01.Presentation.Api.Configurations;

namespace Projeto01.Presentation.Api
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
            services.AddControllers();

            //configuração do swagger
            SwaggerConfiguration.AddSwagger(services);

            //configuração do EntityFramework
            EntityFrameworkConfiguration.AddEntityFramework(services, Configuration);

            //configuração para autenticação por JWT
            JwtConfiguration.AddJwt(services, Configuration);

            //configuração para injeção de dependência
            DependencyInjectionConfiguration.AddDependencyInjection(services);

            //configuração de CORS
            CorsConfiguration.AddCors(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //configuração de CORS
            CorsConfiguration.UseCors(app);

            //configuração do JWT
            JwtConfiguration.UseJwt(app);

            //configuração do swagger
            SwaggerConfiguration.UseSwagger(app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
