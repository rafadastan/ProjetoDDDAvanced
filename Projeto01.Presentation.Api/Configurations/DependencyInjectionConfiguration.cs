using Microsoft.Extensions.DependencyInjection;
using Projeto01.Application.Contracts;
using Projeto01.Application.Services;
using Projeto01.Domain.Contracts.Repositories;
using Projeto01.Domain.Contracts.Services;
using Projeto01.Domain.Services;
using Projeto01.Infra.Data.SqlServer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto01.Presentation.Api.Configurations
{
    public class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(IServiceCollection services)
        {
            #region Application

            services.AddTransient<IEmpresaApplicationService, EmpresaApplicationService>();

            #endregion

            #region Domain

            services.AddTransient<IEmpresaDomainService, EmpresaDomainService>();
            services.AddTransient<IFuncionarioDomainService, FuncionarioDomainService>();

            #endregion

            #region InfraStructure

            services.AddTransient<IEmpresaRepository, EmpresaRepository>();
            services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #endregion
        }

    }
}
