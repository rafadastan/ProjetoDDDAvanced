using Projeto01.Domain.Contracts.Repositories;
using Projeto01.Domain.Contracts.Services;
using Projeto01.Domain.Entities;
using Projeto01.Domain.Exceptions.Empresas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Domain.Services
{
    public class EmpresaDomainService : BaseDomainService<EmpresaEntity>, IEmpresaDomainService
    {
        private readonly IUnitOfWork unitOfWork;

        public EmpresaDomainService(IUnitOfWork unitOfWork) 
            : base(unitOfWork.EmpresaRepository)
        {
            this.unitOfWork = unitOfWork;
        }

        public override void Create(EmpresaEntity entity)
        {
            #region CNPJ deve ser único

            if (unitOfWork.EmpresaRepository.Get(e => e.Cnpj.Equals(entity.Cnpj)) != null)
                throw new CnpjDeveSerUnicoException(entity.Cnpj);

            #endregion

            #region Razão Social deve ser único

            if (unitOfWork.EmpresaRepository.Get(e => e.RazaoSocial.Equals(entity.RazaoSocial)) != null)
                throw new CnpjDeveSerUnicoException(entity.RazaoSocial);

            #endregion
            base.Create(entity);
        }
    }
}
