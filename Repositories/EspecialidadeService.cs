using System.Threading.Tasks;
using AutoMapper;
using Consultorio.Data;
using Consultorio.Interfaces;
using Consultorio.Models;

namespace Consultorio.Services
{
    public class EspecialidadeService : IEspecialidadeService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public EspecialidadeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Especialidade> AddEspecialidade(Especialidade especialidade)
        {
            _context.Especialidades.Add(especialidade);
            await _context.SaveChangesAsync();
            return _mapper.Map<Especialidade>(especialidade);
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