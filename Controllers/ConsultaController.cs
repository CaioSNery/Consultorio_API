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

    [ApiController]
    [Route("v1")]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaRepository _service;
        public ConsultaController(IConsultaRepository service)
        {
            _service = service;
        }

        [HttpPost("consulta")]
        public async Task<IActionResult> AddConsulta([FromBody] ConsultaDTO dto)
        {
            var consulta = new Consulta
            {
                PacienteId = dto.PacienteId,
                ProfissionalId = dto.ProfissionalId,
                EspecialidadeId = dto.EspecialidadeId,
                DataConsulta = dto.DataConsulta,

            };
            var resultado = await _service.RealizarAgendamentoAsync(consulta);
            return Ok(resultado);
        }

        [HttpDelete("consulta/{id:int}")]
        public async Task<IActionResult> ApagarConsulta(int id)
        {
            var consulta = await _service.DeletarConsultaAsync(id);
            if (!consulta) return NotFound("Consulta não encontrada");

            return Ok("Agendamento apagado");
        }

        [HttpPut("consulta/{id:int}")]
        public async Task<IActionResult> AtualizarConsulta(int id, [FromBody] Consulta consultaupdate)
        {
            var consulta = await _service.AtualizarConsultaAsync(id, consultaupdate);
            if (consulta == null) return NotFound("Consulta nao encontrada");
            return Ok("Consulta atualizada com sucesso");
        }

        [HttpGet("consulta/{id:int}")]
        public async Task<IActionResult> BuscarConsulta(int id)
        {
            var consulta = await _service.BuscarConsultasPorId(id);
            if (consulta == null) return NotFound("Consulta não encontrada");

            return Ok(consulta);
        }

        [HttpGet("consultas/dia")]
        public async Task<IActionResult> ConsultarDoDIa()
        {
            var consulta = await _service.ObterConsultarDoDiaAsyn();
            return Ok(consulta);
        }

        [HttpGet("consultas")]
        public async Task<IActionResult> ListarConsultas()
        {
            var consultas = await _service.ListarTodasConsultasAsync();
            return Ok(consultas);
        }
    }
}