using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Consultorio.Data;
using Consultorio.Dtos;
using Consultorio.Interfaces;
using Consultorio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Services
{
    public class ProfissionalRepository : IProfissionalRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public ProfissionalRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProfissionalDTO> AddProfissionalAsync(ProfissionalCreateDTO dto)
        {

            var profissional = _mapper.Map<Profissional>(dto);
            _context.Profissionais.Add(profissional);

            await _context.SaveChangesAsync();

            return _mapper.Map<ProfissionalDTO>(profissional);
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