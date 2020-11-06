using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Domain.Entities
{
    public class UsuarioEntity
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
