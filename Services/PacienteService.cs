using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Data;
using Consultorio.Dtos;
using Consultorio.Interfaces;
using Consultorio.Models;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Services
{
    public class PacienteService : IPacienteService
    {

        private readonly AppDbContext _context;
        public PacienteService(AppDbContext context)
        {
            _context=context;
        }
        public async Task<PacienteDTO> AddPacienteAsync(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
            return new PacienteDTO
            {
                Id = paciente.Id,
                NomePaciente = paciente.Nome,
                Cpf = paciente.Cpf
            };
        }

        public async Task<bool> AtualizarPacienteAsync(int id, Paciente pacienteupdate)
        {
            var paciente = await _context.Pacientes.FindAsync(id, pacienteupdate);
            if (paciente == null) return false;

            paciente.Nome = pacienteupdate.Nome;
            paciente.Cpf = pacienteupdate.Cpf;
            paciente.Telefone = paciente.Telefone;
            paciente.Idade = paciente.Idade;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<object> BuscarPacientePorIdAsync(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null) return false;
            return paciente;
            
        }

        public async Task<bool> DeletarPacienteAsync(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null) return false;

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Paciente>> ListarPacientesAsync()
        {
            return await _context.Pacientes.ToListAsync();
        }
    }
}