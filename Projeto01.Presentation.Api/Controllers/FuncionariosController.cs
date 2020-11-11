using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto01.Application.Contracts;
using Projeto01.Application.Models.Funcionarios;

namespace Projeto01.Presentation.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioApplicationService funcionarioApplicationService;

        public FuncionariosController(IFuncionarioApplicationService funcionarioApplicationService)
        {
            this.funcionarioApplicationService = funcionarioApplicationService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post(FuncionarioCadastroModel model)
        {
            try
            {
                var funcionarioDTO = funcionarioApplicationService.Create(model);

                return StatusCode(201, new
                {
                    Message = "Funcionário cadastrado com sucesso.",
                    Funcionario = funcionarioDTO
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

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Put(FuncionarioEdicaoModel model)
        {
            try
            {
                var funcionarioDTO = funcionarioApplicationService.Update(model);

                return StatusCode(200, new
                {
                    Message = "Funcionário atualizado com sucesso.",
                    Funcionario = funcionarioDTO
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                }); ;
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var funcionarioDTO = funcionarioApplicationService.Delete(id);

                return StatusCode(200, new
                {
                    Message = "Funcionário excluído com sucesso.",
                    Funcionario = funcionarioDTO
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                }); ;
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            try
            {
                var result = funcionarioApplicationService.GetAll();

                if (result == null || result.Count == 0)
                    return StatusCode(204);

                return StatusCode(200, result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                }); ;
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var funcionarioDTO = funcionarioApplicationService.GetById(id);

                if (funcionarioDTO == null)
                    return StatusCode(204);

                return StatusCode(200, funcionarioDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                }); ;
            }
        }
    }
}
