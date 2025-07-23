using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Dtos;
using Consultorio.Models;

namespace Consultorio.Interfaces
{
    public interface IProfissionalService
    {
        Task<ProfissionalDTO> AddProfissionalAsync(Profissional profissional);
        Task<object> BuscarProfissionalPorIdAsync(int id);

        Task<bool> DeletarProfissionalAsync(int id);

        Task<IEnumerable<Profissional>> ListarProfissionaisAtivosAsync();
    }
}