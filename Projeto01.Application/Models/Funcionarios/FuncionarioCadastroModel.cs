using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projeto01.Application.Models.Funcionarios
{
    public class FuncionarioCadastroModel
    {
        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do funcionário.")]
        public string Nome { get; set; }

        [RegularExpression("^[MF]{1}$", ErrorMessage = "Por favor informe apenas 'F' ou 'M'.")]
        [Required(ErrorMessage = "Por favor, informe o sexo do funcionário.")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de nascimento do funcionário.")]
        public string DataNascimento { get; set; }

        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Por favor informe um CPF válido.")]
        [Required(ErrorMessage = "Por favor, informe o cpf do funcionário.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de admissão do funcionário.")]
        public string DataAdmissao { get; set; }

        [RegularExpression("^[1234]{1}$", ErrorMessage = "Por favor informe '1' Admitido ou '2' Demitido ou '3' Férias ou '4' Afastado.")]
        [Required(ErrorMessage = "Por favor, informe a situação do funcionário.")]
        public string Situacao { get; set; }

        [Required(ErrorMessage = "Por favor, informe o id da empresa.")]
        public Guid EmpresaId { get; set; }
    }
}
