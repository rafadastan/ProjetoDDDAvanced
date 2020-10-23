using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Domain.Entities
{
    public class EmpresaEntity
    {
        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }

        #region Relacionamentos

        public ICollection<FuncionarioEntity> Funcionarios { get; set; }

        #endregion
    }
}
