using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Data;
using Consultorio.Dtos;
using Consultorio.Interfaces;
using Consultorio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Services
{
    public class ProfissionalService : IProfissionalService
    {
        private readonly AppDbContext _context;
        public ProfissionalService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ProfissionalDTO> AddProfissionalAsync(Profissional profissional)
        {
            _context.Profissionais.Add(profissional);
            await _context.SaveChangesAsync();
            
            var especialidade = await _context.Especialidades
            .FirstOrDefaultAsync(e => e.Id == profissional.EspecialidadeId);
            return new ProfissionalDTO
            {
                Id = profissional.Id,
                NomeMedico = profissional.Nome,
                EspecialidadeId=profissional.Id
            };
        }

        public async Task<object> BuscarProfissionalPorIdAsync(int id)
        {
            var medico = await _context.Profissionais.FindAsync(id);
            if (medico == null) return false;
            return medico;
        }

        public async Task<bool> DeletarProfissionalAsync(int id)
        {
            var medico = await _context.Profissionais.FindAsync(id);
            if (medico == null) return false;
            _context.Profissionais.Remove(medico);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Profissional>> ListarProfissionaisAtivosAsync()
        {
            return await _context.Profissionais.ToListAsync();
        }
    }
}