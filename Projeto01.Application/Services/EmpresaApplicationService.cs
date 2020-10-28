using Projeto01.Application.Contracts;
using Projeto01.Application.DTOs;
using Projeto01.Application.Models.Empresas;
using Projeto01.Domain.Contracts.Services;
using Projeto01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Application.Services
{
    public class EmpresaApplicationService : IEmpresaApplicationService
    {
        private readonly IEmpresaDomainService empresaDomainService;

        public EmpresaApplicationService(IEmpresaDomainService empresaDomainService)
        {
            this.empresaDomainService = empresaDomainService;
        }

        public EmpresaDTO Create(EmpresaCadastroModel model)
        {
            var empresaEntity = new EmpresaEntity
            {
                Id = Guid.NewGuid(),
                RazaoSocial = model.RazaoSocial,
                NomeFantasia = model.NomeFantasia,
                Cnpj = model.Cnpj
            };

            empresaDomainService.Create(empresaEntity);

            return new EmpresaDTO
            {
                Id = empresaEntity.Id,
                RazaoSocial = empresaEntity.RazaoSocial,
                NomeFantasia = empresaEntity.NomeFantasia,
                Cnpj = empresaEntity.Cnpj
            };
        }

        public EmpresaDTO Update(EmpresaEdicaoModel model)
        {
            var empresaEntity = empresaDomainService.GetById(model.Id);

            if (empresaEntity == null)
                throw new Exception("Empresa não encontrada.");

            empresaEntity.NomeFantasia = model.NomeFantasia;
            empresaDomainService.Update(empresaEntity);

            return new EmpresaDTO
            {
                Id = empresaEntity.Id,
                RazaoSocial = empresaEntity.RazaoSocial,
                NomeFantasia = empresaEntity.NomeFantasia,
                Cnpj = empresaEntity.Cnpj
            };
        }

        public EmpresaDTO Delete(Guid id)
        {
            var empresaEntity = empresaDomainService.GetById(id);

            if (empresaEntity == null)
                throw new Exception("Empresa não encontrada.");

            empresaDomainService.Delete(empresaEntity);

            return new EmpresaDTO
            {
                Id = empresaEntity.Id,
                RazaoSocial = empresaEntity.RazaoSocial,
                NomeFantasia = empresaEntity.NomeFantasia,
                Cnpj = empresaEntity.Cnpj
            };
        }

        public List<EmpresaDTO> GetAll()
        {
            var result = new List<EmpresaDTO>();

            foreach (var item in empresaDomainService.GetAll())
            {
                result.Add(new EmpresaDTO
                {
                    Id = item.Id,
                    RazaoSocial = item.RazaoSocial,
                    NomeFantasia = item.NomeFantasia,
                    Cnpj = item.Cnpj
                });
            }

            return result;
        }

        public EmpresaDTO GetById(Guid id)
        {
            var empresaEntity = empresaDomainService.GetById(id);

            if (empresaEntity == null)
                return null;

            return new EmpresaDTO
            {
                Id = empresaEntity.Id,
                RazaoSocial = empresaEntity.RazaoSocial,
                NomeFantasia = empresaEntity.NomeFantasia,
                Cnpj = empresaEntity.Cnpj
            };
        }

        public void Dispose()
        {
            empresaDomainService.Dispose();
        }
    }
}
