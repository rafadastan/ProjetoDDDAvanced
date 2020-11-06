using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto01.Application.Contracts;
using Projeto01.Application.Models.Empresas;

namespace Projeto01.Presentation.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaApplicationService empresaApplicationService;

        public EmpresasController(IEmpresaApplicationService empresaApplicationService)
        {
            this.empresaApplicationService = empresaApplicationService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post(EmpresaCadastroModel model)
        {
            try
            {
                var empresaDTO = empresaApplicationService.Create(model);

                return StatusCode(201, new
                {
                    Message = "Empresa cadastrada com sucesso.",
                    Empresa = empresaDTO
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

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Put(EmpresaEdicaoModel model)
        {
            try
            {
                var empresaDTO = empresaApplicationService.Update(model);

                return StatusCode(200, new
                {
                    Message = "Empresa atualizada com sucesso.",
                    Empresa = empresaDTO
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
                var empresaDTO = empresaApplicationService.Delete(id);

                return StatusCode(200, new
                {
                    Message = "Empresa excluída com sucesso.",
                    Empresa = empresaDTO
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
                var result = empresaApplicationService.GetAll();

                //se o resultado é vazio
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
                var empresaDTO = empresaApplicationService.GetById(id);

                //se o resultado é vazio
                if (empresaDTO == null)
                    return StatusCode(204);

                return StatusCode(200, empresaDTO);
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
