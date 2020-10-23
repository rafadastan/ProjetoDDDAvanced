using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Projeto01.Infra.Data.SqlServer.Contexts
{
    public class SqlContextFactory : IDesignTimeDbContextFactory<SqlContext>
    {
        public SqlContext CreateDbContext(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            var connectionString = root.GetSection("ConnectionStrings")
                .GetSection("BDProjeto01").Value;

            //instanciar a classe SqlContext
            var builder = new DbContextOptionsBuilder<SqlContext>();
            builder.UseSqlServer(connectionString);

            return new SqlContext(builder.Options);
        }
    }
}
