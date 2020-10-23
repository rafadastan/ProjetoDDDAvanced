using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Domain.Exceptions.Funcionarios
{
    public class CpfDeveSerUnicoException : Exception
    {
        private readonly string cpf;

        public CpfDeveSerUnicoException(string cpf)
        {
            this.cpf = cpf;
        }

        public override string Message
            => $"O CPF informado '{cpf}' já encontra-se cadastrado. Tente outro.";
    }
}
