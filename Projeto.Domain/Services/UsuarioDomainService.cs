using Projeto01.Domain.Contracts.CrossCuttings.Cryptography;
using Projeto01.Domain.Contracts.Repositories;
using Projeto01.Domain.Contracts.Services;
using Projeto01.Domain.Entities;
using Projeto01.Domain.Exceptions.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Domain.Services
{
    public class UsuarioDomainService
        : BaseDomainService<UsuarioEntity>, IUsuarioDomainService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMD5Cryptography cryptography;

        public UsuarioDomainService(IUnitOfWork unitOfWork, IMD5Cryptography cryptography)
            : base(unitOfWork.UsuarioRepository)
        {
            this.unitOfWork = unitOfWork;
            this.cryptography = cryptography;
        }

        public override void Create(UsuarioEntity entity)
        {
            #region Email deve ser único

            if (unitOfWork.UsuarioRepository.Get(u => u.Email.Equals(entity.Email)) != null)
                throw new EmailDeveSerUnicoException(entity.Email);

            #endregion

            #region Criptografar a senha do usuário

            entity.Senha = cryptography.Encrypt(entity.Senha);

            #endregion

            base.Create(entity);
        }

        public UsuarioEntity Get(string email, string senha)
        {
            #region Criptografar a senha do usuário

            senha = cryptography.Encrypt(senha);

            #endregion

            return unitOfWork.UsuarioRepository
                .Get(u => u.Email.Equals(email)
                       && u.Senha.Equals(senha));
        }
    }
}
