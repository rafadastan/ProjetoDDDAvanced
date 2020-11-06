using Projeto01.Application.DTOs;
using Projeto01.Application.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Application.Contracts
{
    public interface IUsuarioApplicationService : IDisposable
    {
        UsuarioDTO Create(UsuarioCadastroModel model);
        UsuarioDTO Get(string email, string senha);
    }
}
