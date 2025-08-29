using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Dtos;
using Consultorio.Interfaces;
using Consultorio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Controllers
{
    [Authorize]
    [ApiController]
    [Route("v1")]
    public class ProfissionalController : ControllerBase
    {
        private readonly IProfissionalRepository _service;
        public ProfissionalController(IProfissionalRepository service)
        {
            _service = service;
        }

        [HttpPost("profissional")]
        public async Task<IActionResult> AddMedico([FromBody] ProfissionalCreateDTO dto)
        {

            var result = await _service.AddProfissionalAsync(dto);
            return Ok(result);
        }

        [HttpGet("profissionais")]
        public async Task<IActionResult> ListarMedicos()
        {
            var medicos = await _service.ListarProfissionaisAtivosAsync();
            return Ok(medicos);
        }

        [HttpGet("profissional/{id:int}")]
        public async Task<IActionResult> BuscarMedicoPorId(int id)
        {
            var medico = await _service.BuscarProfissionalPorIdAsync(id);
            if (medico == null) return NotFound();

            return Ok(medico);
        }

        [HttpDelete("profissionao/{id:int}")]
        public async Task<IActionResult> DeletarMedico(int id)
        {
            var medico = await _service.DeletarProfissionalAsync(id);
            if (!medico) return NotFound();

            return Ok(medico);
        }
    }
}