using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Dtos;
using Consultorio.Models;

namespace Consultorio.Interfaces
{
    public interface IPacienteService
    {
        Task<PacienteDTO> AddPacienteAsync(PacienteCreateDTO dto);

        Task<bool> DeletarPacienteAsync(int id);

        Task<bool> AtualizarPacienteAsync(int id, Paciente pacienteupdate);

        Task<IEnumerable<Paciente>> ListarPacientesAsync();

        Task<object> BuscarPacientePorIdAsync(int id);
    }
}