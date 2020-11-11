using Projeto01.Application.Contracts;
using Projeto01.Application.DTOs;
using Projeto01.Application.Models.Funcionarios;
using Projeto01.Domain.Contracts.Services;
using Projeto01.Domain.Entities;
using Projeto01.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Application.Services
{
    public class FuncionarioApplicationService : IFuncionarioApplicationService
    {
        //atributos
        private readonly IFuncionarioDomainService funcionarioDomainService;
        private readonly IEmpresaDomainService empresaDomainService;

        //construtor para injeção de dependência
        public FuncionarioApplicationService(IFuncionarioDomainService funcionarioDomainService, IEmpresaDomainService empresaDomainService)
        {
            this.funcionarioDomainService = funcionarioDomainService;
            this.empresaDomainService = empresaDomainService;
        }

        public FuncionarioDTO Create(FuncionarioCadastroModel model)
        {
            var funcionarioEntity = new FuncionarioEntity
            {
                Id = Guid.NewGuid(),
                Nome = model.Nome,
                Cpf = model.Cpf,
                DataAdmissao = DateTime.Parse(model.DataAdmissao),
                DataNascimento = DateTime.Parse(model.DataNascimento),
                Sexo = (SexoEnum)char.Parse(model.Sexo),
                Situacao = (SituacaoFuncionarioEnum)int.Parse(model.Situacao),
                EmpresaId = model.EmpresaId
            };

            funcionarioDomainService.Create(funcionarioEntity);

            var empresa = empresaDomainService.GetById(funcionarioEntity.EmpresaId);
            return new FuncionarioDTO
            {
                Id = funcionarioEntity.Id,
                Nome = funcionarioEntity.Nome,
                Cpf = funcionarioEntity.Cpf,
                DataAdmissao = funcionarioEntity.DataAdmissao,
                DataNascimento = funcionarioEntity.DataNascimento,
                Sexo = funcionarioEntity.Sexo.ToString(),
                Situacao = funcionarioEntity.Situacao.ToString(),
                Empresa = new EmpresaDTO
                {
                    Id = empresa.Id,
                    RazaoSocial = empresa.RazaoSocial,
                    NomeFantasia = empresa.NomeFantasia,
                    Cnpj = empresa.Cnpj
                }
            };
        }

        public FuncionarioDTO Update(FuncionarioEdicaoModel model)
        {
            var funcionarioEntity = funcionarioDomainService.GetById(model.Id);

            if (funcionarioEntity == null)
                throw new Exception("Funcionário não encontrado.");

            funcionarioEntity.Nome = model.Nome;
            funcionarioEntity.DataNascimento = DateTime.Parse(model.DataNascimento);
            funcionarioEntity.Sexo = (SexoEnum)char.Parse(model.Sexo);
            funcionarioEntity.Situacao = (SituacaoFuncionarioEnum)int.Parse(model.Situacao);

            funcionarioDomainService.Update(funcionarioEntity);

            var empresa = empresaDomainService.GetById(funcionarioEntity.EmpresaId);
            return new FuncionarioDTO
            {
                Id = funcionarioEntity.Id,
                Nome = funcionarioEntity.Nome,
                Cpf = funcionarioEntity.Cpf,
                DataAdmissao = funcionarioEntity.DataAdmissao,
                DataNascimento = funcionarioEntity.DataNascimento,
                Sexo = funcionarioEntity.Sexo.ToString(),
                Situacao = funcionarioEntity.Situacao.ToString(),
                Empresa = new EmpresaDTO
                {
                    Id = empresa.Id,
                    RazaoSocial = empresa.RazaoSocial,
                    NomeFantasia = empresa.NomeFantasia,
                    Cnpj = empresa.Cnpj
                }
            };
        }

        public FuncionarioDTO Delete(Guid id)
        {
            var funcionarioEntity = funcionarioDomainService.GetById(id);

            if (funcionarioEntity == null)
                throw new Exception("Funcionário não encontrado.");

            funcionarioDomainService.Delete(funcionarioEntity);

            var empresa = empresaDomainService.GetById(funcionarioEntity.EmpresaId);
            return new FuncionarioDTO
            {
                Id = funcionarioEntity.Id,
                Nome = funcionarioEntity.Nome,
                Cpf = funcionarioEntity.Cpf,
                DataAdmissao = funcionarioEntity.DataAdmissao,
                DataNascimento = funcionarioEntity.DataNascimento,
                Sexo = funcionarioEntity.Sexo.ToString(),
                Situacao = funcionarioEntity.Situacao.ToString(),
                Empresa = new EmpresaDTO
                {
                    Id = empresa.Id,
                    RazaoSocial = empresa.RazaoSocial,
                    NomeFantasia = empresa.NomeFantasia,
                    Cnpj = empresa.Cnpj
                }
            };
        }

        public List<FuncionarioDTO> GetAll()
        {
            var result = new List<FuncionarioDTO>();

            foreach (var item in funcionarioDomainService.GetAll())
            {
                result.Add(new FuncionarioDTO
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Cpf = item.Cpf,
                    DataAdmissao = item.DataAdmissao,
                    DataNascimento = item.DataNascimento,
                    Sexo = item.Sexo.ToString(),
                    Situacao = item.Situacao.ToString(),
                    Empresa = new EmpresaDTO
                    {
                        Id = item.Empresa.Id,
                        RazaoSocial = item.Empresa.RazaoSocial,
                        NomeFantasia = item.Empresa.NomeFantasia,
                        Cnpj = item.Empresa.Cnpj
                    }
                });
            }

            return result;
        }

        public FuncionarioDTO GetById(Guid id)
        {
            var funcionarioEntity = funcionarioDomainService.GetById(id);

            if (funcionarioEntity == null)
                return null;

            return new FuncionarioDTO
            {
                Id = funcionarioEntity.Id,
                Nome = funcionarioEntity.Nome,
                Cpf = funcionarioEntity.Cpf,
                DataAdmissao = funcionarioEntity.DataAdmissao,
                DataNascimento = funcionarioEntity.DataNascimento,
                Sexo = funcionarioEntity.Sexo.ToString(),
                Situacao = funcionarioEntity.Situacao.ToString(),
                Empresa = new EmpresaDTO
                {
                    Id = funcionarioEntity.Empresa.Id,
                    RazaoSocial = funcionarioEntity.Empresa.RazaoSocial,
                    NomeFantasia = funcionarioEntity.Empresa.NomeFantasia,
                    Cnpj = funcionarioEntity.Empresa.Cnpj
                }
            };
        }

        public void Dispose()
        {
            funcionarioDomainService.Dispose();
            empresaDomainService.Dispose();
        }
    }
}
