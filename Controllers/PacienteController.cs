using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Dtos;
using Consultorio.Interfaces;
using Consultorio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Controllers
{
    [Authorize]
    [ApiController]
    [Route("v1")]

    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _service;
        public PacienteController(IPacienteService service)
        {
            _service = service;
        }

        [HttpPost("paciente")]
        public async Task<IActionResult> AddPaciente([FromBody] PacienteCreateDTO dto)
        {
            var resultado = await _service.AddPacienteAsync(dto);
            return Ok(resultado);
        }

        [HttpGet("pacientes")]
        public async Task<IActionResult> ListarPacientes()
        {
            var pacientes = await _service.ListarPacientesAsync();
            return Ok(pacientes);
        }

        [HttpGet("paciente/{id:int}")]
        public async Task<IActionResult> BuscarPaciente(int id)
        {
            var paciente = await _service.BuscarPacientePorIdAsync(id);
            if (paciente == null) return NotFound();

            return Ok(paciente);
        }

        [HttpPut("paciente/{id:int}")]
        public async Task<IActionResult> AtualizarPaciente(int id, Paciente pacienteupdate)
        {
            var paciente = await _service.AtualizarPacienteAsync(id, pacienteupdate);
            if (!paciente) return NotFound();

            return Ok(paciente);
        }

        [HttpDelete("paciente/{id:int}")]
        public async Task<IActionResult> DeletarPaciente(int id)
        {
            var paciente = await _service.DeletarPacienteAsync(id);
            if (!paciente) return NotFound();

            return Ok(paciente);
        }
    }
}