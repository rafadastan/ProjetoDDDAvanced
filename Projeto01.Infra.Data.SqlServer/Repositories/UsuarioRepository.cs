using Projeto01.Domain.Contracts.Repositories;
using Projeto01.Domain.Entities;
using Projeto01.Infra.Data.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Infra.Data.SqlServer.Repositories
{
    public class UsuarioRepository : BaseRepository<UsuarioEntity>, IUsuarioRepository
    {
        private readonly SqlContext sqlContext;

        public UsuarioRepository(SqlContext sqlContext)
            : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}
