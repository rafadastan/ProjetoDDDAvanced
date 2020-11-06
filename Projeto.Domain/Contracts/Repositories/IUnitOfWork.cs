using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Domain.Contracts.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        #region Repositories

        IEmpresaRepository EmpresaRepository { get; }
        IFuncionarioRepository FuncionarioRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }

        #endregion

        #region Transactions

        void BeginTransaction();
        void Commit();
        void Rollback();

        #endregion
    }
}
