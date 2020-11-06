using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Domain.Exceptions.Usuarios
{
    public class EmailDeveSerUnicoException : Exception
    {
        private readonly string email;

        public EmailDeveSerUnicoException(string email)
        {
            this.email = email;
        }

        public override string Message
             => $"O Email informado '{email}' já encontra-se cadastrado. Tente outro.";
    }
}
