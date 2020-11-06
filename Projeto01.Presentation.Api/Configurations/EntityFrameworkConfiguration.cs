using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto01.Infra.Data.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto01.Presentation.Api.Configurations
{
    public class EntityFrameworkConfiguration
    {
        public static void AddEntityFramework(IServiceCollection services, IConfiguration configuration)
        {
            //ler a connectionstring no appsettings.json
            var connectionString = configuration.GetConnectionString("BDProjeto01");

            //configurando a classe SqlContext do projeto Infra.Data
            services.AddDbContext<SqlContext>
                (options => options.UseSqlServer(connectionString));
        }
    }
}
