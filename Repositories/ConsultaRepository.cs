using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Consultorio.Data;
using Consultorio.Dtos;
using Consultorio.Interfaces;
using Consultorio.Models;
using Consultorio_API.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel.Resolution;

namespace Consultorio.Services
{
    public class ConsultaRepository : IConsultaRepository
    {

        private readonly AppDbContext _context;
        private readonly ISmSService _service;
        private readonly IMapper _mapper;

        private readonly IMensagemService _mensagemService;
        public ConsultaRepository(AppDbContext context,
        ISmSService service, IMapper mapper,
         IMensagemService mensagemService)
        {

            {
                _context = context;
                _service = service;
                _mapper = mapper;
                _mensagemService = mensagemService;

            }
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

            return _mapper.Map<ConsultaDTO>(consulta);
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

                await _mensagemService.EnviarMsgWhatsAsync(paciente.Telefone, msg);

            }


            return _mapper.Map<ConsultaDTO>(consulta);
        }



        public async Task<IEnumerable<Consulta>> ListarTodasConsultasAsync()
        {
            var consultas = await _context.Consultas
            .AsNoTracking()
            .ToListAsync();

            return _mapper.Map<IEnumerable<Consulta>>(consultas);
        }
    }
}