using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public int Idade { get; set; }

        public string Cpf { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Telefone{ get; set; }
    }
}