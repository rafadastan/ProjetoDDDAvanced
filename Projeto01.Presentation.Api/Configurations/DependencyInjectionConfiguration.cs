using Microsoft.Extensions.DependencyInjection;
using Projeto01.Application.Contracts;
using Projeto01.Application.Services;
using Projeto01.CrossCutting.Cryptography;
using Projeto01.Domain.Contracts.CrossCuttings.Cryptography;
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
            services.AddTransient<IFuncionarioApplicationService, FuncionarioApplicationService>();
            services.AddTransient<IUsuarioApplicationService, UsuarioApplicationService>();

            #endregion

            #region Domain

            services.AddTransient<IEmpresaDomainService, EmpresaDomainService>();
            services.AddTransient<IFuncionarioDomainService, FuncionarioDomainService>();
            services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();

            #endregion

            #region InfraStructure

            services.AddTransient<IEmpresaRepository, EmpresaRepository>();
            services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #endregion

            #region CrossCutting

            services.AddTransient<IMD5Cryptography, MD5Cryptography>();

            #endregion
        }
    }
}
