using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Domain.Contracts.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        #region Repository
        public IEmpresaRepository EmpresaRepository { get; }
        public IFuncionarioRepository FuncionarioRepository { get; }

        #endregion

        #region Transactions

        void BeginTransaction();
        void Commit();
        void Rollback();

        #endregion
    }
}
