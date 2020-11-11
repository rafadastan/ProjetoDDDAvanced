using Projeto01.Application.DTOs;
using Projeto01.Application.Models.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Application.Contracts
{
    public interface IFuncionarioApplicationService : IDisposable
    {
        FuncionarioDTO Create(FuncionarioCadastroModel model);
        FuncionarioDTO Update(FuncionarioEdicaoModel model);
        FuncionarioDTO Delete(Guid id);

        List<FuncionarioDTO> GetAll();
        FuncionarioDTO GetById(Guid id);
    }
}
