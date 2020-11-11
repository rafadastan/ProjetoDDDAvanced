using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Domain.Exceptions.Empresas
{
    public class ExclusaoNaoPermitidaException : Exception
    {
        //atributo
        private int numFuncionarios;

        //construtor para inicialização
        public ExclusaoNaoPermitidaException(int numFuncionarios)
        {
            this.numFuncionarios = numFuncionarios;
        }

        public override string Message
            => $"Não é permitido excluir a empresa pois ela possui {numFuncionarios} funcionário(s).";
    }
}
