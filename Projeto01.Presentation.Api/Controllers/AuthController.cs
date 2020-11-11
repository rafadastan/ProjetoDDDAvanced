using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto01.Application.Contracts;
using Projeto01.Application.Models.Usuarios;
using Projeto01.Presentation.Api.Security;

namespace Projeto01.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioApplicationService usuarioApplicationService;
        private readonly JwtToken jwtToken;

        public AuthController(IUsuarioApplicationService usuarioApplicationService, JwtToken jwtToken)
        {
            this.usuarioApplicationService = usuarioApplicationService;
            this.jwtToken = jwtToken;
        }

        [HttpPost]
        public IActionResult Post(UsuarioAcessoModel model)
        {
            try
            {
                var usuarioDTO = usuarioApplicationService.GetAccess(model);

                if (usuarioDTO != null)
                {
                    return StatusCode(200, new
                    {
                        Message = "Usuário autenticado com sucesso.",
                        Usuario = usuarioDTO,
                        AccessToken = new
                        {
                            BearerToken = jwtToken.GenerateToken(usuarioDTO.Email),
                            Expiration = DateTime.Now.AddDays(1)
                        }
                    });
                }

                throw new Exception("Acesso Negado. Usuário não encontrado.");
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
