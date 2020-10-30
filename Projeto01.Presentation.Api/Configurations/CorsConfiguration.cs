using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto01.Presentation.Api.Configurations
{
    public class CorsConfiguration
    {
        public static void AddCors(IServiceCollection services)
        {
            //definindo uma politica de chamadas à API..
            services.AddCors(
                s => s.AddPolicy("DefaultPolicy",
                builder =>
                {
                    builder.AllowAnyOrigin()  //requisições de qualquer origem
                           .AllowAnyMethod()  //requisições para qualquer metodo (POST, PUT, DELETE, GET etc)
                           .AllowAnyHeader(); //qualquer tipo de cabeçalho de requisição
                }));
        }

        public static void UseCors(IApplicationBuilder app)
        {
            //aplicando a politica CORS definida.
            app.UseCors("DefaultPolicy");
        }
    }
}
