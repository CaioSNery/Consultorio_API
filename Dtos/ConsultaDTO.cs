using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Dtos
{
    public class ConsultaDTO
    {
        public int Id { get; set; }
        public int EspecialidadeId { get; set; }

        public int ProfissionalId { get; set; }

        public int PacienteId { get; set; }

        public DateTime DataConsulta { get; set; }
    }
}