using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Domain.Exceptions.Empresas
{
    public class RazaoSocialDeveSerUnicoException : Exception
    {
        private readonly string razaoSocial;

        public RazaoSocialDeveSerUnicoException(string razaoSocial)
        {
            this.razaoSocial = razaoSocial;
        }

        public override string Message
            => $"A Razão Social informada '{razaoSocial}' já encontra-se cadastrado. Tente outro.";
    }
}
