using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Dtos
{
    public class PacienteDTO
    {
        public int Id { get; set; }
        public string NomePaciente { get; set; }

        public string Cpf { get; set; }

    }
}