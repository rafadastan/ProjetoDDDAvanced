using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Application.DTOs
{
    public class EmpresaDTO
    {
        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
    }
}
