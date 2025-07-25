using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Data;
using Consultorio.Dtos;
using Consultorio.Interfaces;
using Consultorio.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel.Resolution;

namespace Consultorio.Services
{
    public class ConsultaService : IConsultaService
    {

        private readonly AppDbContext _context;
        private readonly ISmSService _service;
        public ConsultaService(AppDbContext context, ISmSService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<ConsultaDTO> AtualizarConsultaAsync(int id, Consulta consultaupdate)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta == null) throw new Exception("Consulta não encontrada");

            var paciente = await _context.Pacientes.FirstOrDefaultAsync(p => p.Id == consultaupdate.PacienteId);
            if (paciente == null) throw new Exception("Paciente não encontrado");

            

            consulta.PacienteId = consultaupdate.PacienteId;
            consulta.ProfissionalId = consultaupdate.ProfissionalId;
            consulta.DataConsulta = consultaupdate.DataConsulta;
            consulta.EspecialidadeId = consultaupdate.EspecialidadeId;

            await _context.SaveChangesAsync();

            if (!string.IsNullOrWhiteSpace(paciente.Telefone))
            {
                string msg = $"Olá {paciente.Nome},sua consulta foi remarcada para {consulta.DataConsulta:dd/MM/yyyy 'às' HH:mm} , por favor compareça com  15 minutos de antecedencia.";
                await _service.EnviarSMSAsync(paciente.Telefone, msg);
            }

            return new ConsultaDTO
            {
                PacienteId = consultaupdate.PacienteId,
                ProfissionalId = consultaupdate.ProfissionalId,
                EspecialidadeId = consultaupdate.EspecialidadeId,
                DataConsulta=consultaupdate.DataConsulta
            };
        }

        public async Task<object> BuscarConsultasPorId(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta == null) return false;

            return consulta;
        }

        public async Task<bool> DeletarConsultaAsync(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta == null) return false;

            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Consulta>> ObterConsultarDoDiaAsyn()
        {
            DateTime hoje = DateTime.Today;
            DateTime amanha = hoje.AddDays(1);

            return await _context.Consultas
            .Where(c => c.DataConsulta >= hoje && c.DataConsulta < amanha)
            .Include(c => c.Paciente)
            .Include(c => c.Profissional)
            .ToListAsync();
        }

        public async Task<ConsultaDTO> RealizarAgendamentoAsync(Consulta consulta)
        {
            bool existeagendamento = await _context.Consultas
            .AnyAsync(c => c.DataConsulta == consulta.DataConsulta && c.ProfissionalId == consulta.ProfissionalId);

            if (existeagendamento) throw new Exception("Ja Existe agendamento para essa horario");

            var paciente = await _context.Pacientes.FirstOrDefaultAsync(p => p.Id == consulta.PacienteId);

            if (paciente == null) throw new Exception("Paciente não encontrado");

            _context.Consultas.Add(consulta);
            await _context.SaveChangesAsync();

            if (!string.IsNullOrWhiteSpace(paciente.Telefone))
            {
                 string msg = $"Olá {paciente.Nome}, o dia da sua consulta esta agendada para {consulta.DataConsulta:dd/MM/yyyy 'às' HH:mm} , por favor compareça com  15 minutos de antecedencia.";
                await _service.EnviarSMSAsync(paciente.Telefone, msg);
            }
            

            return new ConsultaDTO
            {
                Id = consulta.Id,
                PacienteId = consulta.PacienteId,
                EspecialidadeId = consulta.EspecialidadeId,
                ProfissionalId = consulta.ProfissionalId

            };
        }
    }
}