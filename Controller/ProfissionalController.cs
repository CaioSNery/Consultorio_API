using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Dtos;
using Consultorio.Interfaces;
using Consultorio.Models;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfissionalController : ControllerBase
    {
        private readonly IProfissionalService _service;
        public ProfissionalController(IProfissionalService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddMedico([FromBody]ProfissionalDTO dto)
        {
            var profissional = new Profissional
        {
            Nome = dto.NomeMedico,
            EspecialidadeId = dto.EspecialidadeId
        };

        var result = await _service.AddProfissionalAsync(profissional);
        return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> ListarMedicos()
        {
            var medicos = await _service.ListarProfissionaisAtivosAsync();
            return Ok(medicos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarMedicoPorId(int id)
        {
            var medico = await _service.BuscarProfissionalPorIdAsync(id);
            if (medico == null) return NotFound();

            return Ok(medico);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarMedico(int id)
        {
            var medico = await _service.DeletarProfissionalAsync(id);
            if (!medico) return NotFound();

            return Ok(medico);
        }
    }
}