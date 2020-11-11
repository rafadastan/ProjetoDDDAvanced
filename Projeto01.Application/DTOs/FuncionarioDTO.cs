using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Application.DTOs
{
    public class FuncionarioDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public DateTime DataAdmissao { get; set; }
        public string Situacao { get; set; }

        public EmpresaDTO Empresa { get; set; }
    }
}
