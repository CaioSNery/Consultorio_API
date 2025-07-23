using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Data;
using Consultorio.Interfaces;
using Consultorio.Models;

namespace Consultorio.Services
{
    public class EspecialidadeService : IEspecialidadeService
    {
        private readonly AppDbContext _context;
        public EspecialidadeService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Especialidade> AddEspecialidade(Especialidade especialidade)
        {
            _context.Especialidades.Add(especialidade);
            await _context.SaveChangesAsync();
            return especialidade;
        }

        public async Task<bool> DeletarEspecialidade(int id)
        {
            var especialidade = await _context.Especialidades.FindAsync(id);
            if (especialidade == null) return false;

            _context.Especialidades.Remove(especialidade);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}