using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Dtos
{
    public class PacienteCreateDTO
    {
        public string NomePaciente { get; set; }
        public string Cpf { get; set; }

        public int Idade { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Telefone{ get; set; }
    }
}