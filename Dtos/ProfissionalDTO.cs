using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Dtos
{
    public class ProfissionalDTO
    {
        public int Id { get; set; }
        public string NomeMedico { get; set; }
        public int EspecialidadeId { get; set; }
    }
}