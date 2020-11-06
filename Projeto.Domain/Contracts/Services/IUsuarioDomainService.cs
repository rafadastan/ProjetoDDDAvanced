using Projeto01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Domain.Contracts.Services
{
    public interface IUsuarioDomainService : IBaseDomainService<UsuarioEntity>
    {
        UsuarioEntity Get(string email, string senha);
    }
}
