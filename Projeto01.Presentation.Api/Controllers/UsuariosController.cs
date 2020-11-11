using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto01.Application.Contracts;
using Projeto01.Application.Models.Usuarios;

namespace Projeto01.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioApplicationService usuarioApplicationService;

        public UsuariosController(IUsuarioApplicationService usuarioApplicationService)
        {
            this.usuarioApplicationService = usuarioApplicationService;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post(UsuarioCadastroModel model)
        {
            try
            {
                var usuarioDTO = usuarioApplicationService.Create(model);

                return StatusCode(201, new
                {
                    Message = "Usuário cadastrado com sucesso.",
                    Usuario = usuarioDTO
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                });
            }
        }
    }
}
