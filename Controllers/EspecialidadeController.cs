using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Dtos;
using Consultorio.Interfaces;
using Consultorio.Models;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeService _service;
        public EspecialidadeController(IEspecialidadeService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddEspecialidade([FromBody]EspecialidadeDTO dto)
        {
             var especialidade = new Especialidade
        {
            Tipo = dto.Tipo,
            PrecoConsulta = dto.PrecoConsulta
        };

              var result = await _service.AddEspecialidade(especialidade);
             return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarEspecialidade(int id)
        {
            var especialidade = await _service.DeletarEspecialidade(id);
            if (!especialidade) return NotFound();

            return Ok("Apagado com sucesso");
        }
    }
}