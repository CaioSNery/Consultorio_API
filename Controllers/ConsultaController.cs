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
    [Route("api/[controller]")]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaService _service;
        public ConsultaController(IConsultaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddConsulta([FromBody] ConsultaDTO dto)
        {
            var consulta = new Consulta
            {
                PacienteId = dto.PacienteId,
                ProfissionalId = dto.ProfissionalId,
                EspecialidadeId = dto.EspecialidadeId,
                DataConsulta = dto.DataConsulta,
                
            };
           var resultado=await _service.RealizarAgendamentoAsync(consulta);
           return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ApagarConsulta(int id)
        {
            var consulta = await _service.DeletarConsultaAsync(id);
            if (!consulta) return NotFound("Consulta não encontrada");

            return Ok("Agendamento apagado");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarConsulta(int id, [FromBody] Consulta consultaupdate)
        {
            var consulta = await _service.AtualizarConsultaAsync(id, consultaupdate);
            if (consulta==null) return NotFound("Consulta nao encontrada");
            return Ok("Consulta atualizada com sucesso");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarConsulta(int id)
        {
            var consulta = await _service.BuscarConsultasPorId(id);
            if (consulta == null) return NotFound("Consulta não encontrada");

            return Ok(consulta);
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarDoDIa()
        {
            var consulta = await _service.ObterConsultarDoDiaAsyn();
            return Ok (consulta);
        }
    }
}