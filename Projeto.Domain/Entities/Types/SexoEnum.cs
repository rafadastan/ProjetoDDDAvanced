using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Projeto01.Domain.Entities.Types
{
    public enum SexoEnum
    {
        [Description("Feminino")]
        Feminino = 'F',
        [Description("Masculino")]
        Masculino = 'M'
    }
}
