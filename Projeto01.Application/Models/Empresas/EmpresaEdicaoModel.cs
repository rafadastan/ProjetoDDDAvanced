using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projeto01.Application.Models.Empresas
{
    public class EmpresaEdicaoModel
    {
        [Required(ErrorMessage = "Por favor, informe o id da empresa")]
        public Guid Id { get; set; }

        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome fantasia da empresa.")]
        public string NomeFantasia { get; set; }
    }
}
