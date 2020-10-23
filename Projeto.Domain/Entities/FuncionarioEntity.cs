using Projeto01.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Domain.Entities
{
    public class FuncionarioEntity
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public SexoEnum Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public DateTime DataAdmissao { get; set; }
        public SituacaoFuncionarioEnum Situacao { get; set; }
        public Guid EmpresaId { get; set; }

        #region Relacionamentos

        public EmpresaEntity Empresa { get; set; }

        #endregion
    }
}
