using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Projeto01.Domain.Entities.Types
{
    public enum SituacaoFuncionarioEnum
    {
        [Description("Admitido")]
        Admitido = 1,

        [Description("Demitido")]
        Demitido = 2,

        [Description("Férias")]
        Ferias = 3,

        [Description("Afastado")]
        Afastado = 4
    }
}
