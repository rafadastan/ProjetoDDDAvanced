using Projeto01.Application.DTOs;
using Projeto01.Application.Models.Empresas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Application.Contracts
{
    public interface IEmpresaApplicationService : IDisposable
    {
        EmpresaDTO Create(EmpresaCadastroModel model);
        EmpresaDTO Update(EmpresaEdicaoModel model);
        EmpresaDTO Delete(Guid id);

        List<EmpresaDTO> GetAll();
        EmpresaDTO GetById(Guid id);
    }
}
