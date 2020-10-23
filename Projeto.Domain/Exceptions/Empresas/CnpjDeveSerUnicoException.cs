using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Domain.Exceptions.Empresas
{
    public class CnpjDeveSerUnicoException : Exception
    {
        private readonly string cnpj;

        public CnpjDeveSerUnicoException(string cnpj)
        {
            this.cnpj = cnpj;
        }

        public override string Message
            => $"O CNPJ informado '{cnpj}' já encontra-se cadastrado. Tente outro";
    }
}
