using Microsoft.EntityFrameworkCore;
using Projeto01.Domain.Contracts.Repositories;
using Projeto01.Domain.Entities;
using Projeto01.Infra.Data.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto01.Infra.Data.SqlServer.Repositories
{
    public class FuncionarioRepository
        : BaseRepository<FuncionarioEntity>, IFuncionarioRepository
    {
        //atributo
        private readonly SqlContext sqlContext;

        //construtor para inicialização do atributo
        public FuncionarioRepository(SqlContext sqlContext)
            : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public override List<FuncionarioEntity> GetAll()
        {
            return sqlContext
                .Funcionario
                .Include(f => f.Empresa) //LEFT JOIN
                .ToList();
        }

        public override List<FuncionarioEntity> GetAll(Func<FuncionarioEntity, bool> where)
        {
            return sqlContext
                .Funcionario
                .Include(f => f.Empresa) //LEFT JOIN
                .Where(where)
                .ToList();
        }

        public override FuncionarioEntity GetById(Guid id)
        {
            return sqlContext
                .Funcionario
                .Include(f => f.Empresa) //LEFT JOIN
                .FirstOrDefault(f => f.Id == id);
        }

        public override FuncionarioEntity Get(Func<FuncionarioEntity, bool> where)
        {
            return sqlContext
                .Funcionario
                .Include(f => f.Empresa) //LEFT JOIN
                .FirstOrDefault(where);
        }
    }
}
