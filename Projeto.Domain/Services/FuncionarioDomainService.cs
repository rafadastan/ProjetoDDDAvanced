using Projeto01.Domain.Contracts.Repositories;
using Projeto01.Domain.Contracts.Services;
using Projeto01.Domain.Entities;
using Projeto01.Domain.Exceptions.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Domain.Services
{
    public class FuncionarioDomainService : BaseDomainService<FuncionarioEntity>, IFuncionarioDomainService
    {
        private readonly IUnitOfWork unitOfWork;

        public FuncionarioDomainService(IUnitOfWork unitOfWork) 
            : base(unitOfWork.FuncionarioRepository)
        {
            this.unitOfWork = unitOfWork;
        }

        public override void Create(FuncionarioEntity entity)
        {
            #region cpf deve ser único

            if (unitOfWork.FuncionarioRepository.Get(e => e.Cpf.Equals(entity.Cpf)) != null)
                throw new CpfDeveSerUnicoException(entity.Cpf);

            #endregion

            base.Create(entity);    
        }
    }
}
