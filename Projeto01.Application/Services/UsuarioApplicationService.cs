using Projeto01.Application.Contracts;
using Projeto01.Application.DTOs;
using Projeto01.Application.Models.Usuarios;
using Projeto01.Domain.Contracts.Services;
using Projeto01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Application.Services
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private readonly IUsuarioDomainService usuarioDomainService;

        public UsuarioApplicationService(IUsuarioDomainService usuarioDomainService)
        {
            this.usuarioDomainService = usuarioDomainService;
        }

        public UsuarioDTO Create(UsuarioCadastroModel model)
        {
            var usuario = new UsuarioEntity
            {
                Id = Guid.NewGuid(),
                Nome = model.Nome,
                Email = model.Email,
                Senha = model.Senha,
                DataCriacao = DateTime.Now
            };

            usuarioDomainService.Create(usuario);

            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataCriacao = usuario.DataCriacao
            };
        }

        public UsuarioDTO GetAccess(UsuarioAcessoModel model)
        {
            var usuario = usuarioDomainService.Get(model.Email, model.Senha);

            if (usuario == null)
                return null;

            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataCriacao = usuario.DataCriacao
            };
        }

        public void Dispose()
        {
            usuarioDomainService.Dispose();
        }
    }
}
