using Microsoft.EntityFrameworkCore.Storage;
using Projeto01.Domain.Contracts.Repositories;
using Projeto01.Infra.Data.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Infra.Data.SqlServer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        //atributos
        private readonly SqlContext sqlContext;
        private IDbContextTransaction transaction;

        //construtor para inicialização (injeção de dependência)
        public UnitOfWork(SqlContext sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public IEmpresaRepository EmpresaRepository
            => new EmpresaRepository(sqlContext);

        public IFuncionarioRepository FuncionarioRepository
            => new FuncionarioRepository(sqlContext);

        public IUsuarioRepository UsuarioRepository
            => new UsuarioRepository(sqlContext);

        public void BeginTransaction()
        {
            transaction = sqlContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public void Dispose()
        {
            sqlContext.Dispose();
        }
    }
}
