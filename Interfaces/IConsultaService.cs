using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Dtos;
using Consultorio.Models;

namespace Consultorio.Interfaces
{
    public interface IConsultaService
    {
        Task<ConsultaDTO> RealizarAgendamentoAsync(Consulta consulta);

        Task<object> BuscarConsultasPorId(int id);

        Task<IEnumerable<Consulta>> ObterConsultarDoDiaAsyn();

        Task<bool> DeletarConsultaAsync(int id);

        Task<ConsultaDTO> AtualizarConsultaAsync(int id, Consulta consultaupdate);


    }
}