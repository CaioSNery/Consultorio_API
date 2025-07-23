using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Models
{
    public class Profissional
    {

        public int Id { get; set; }
        public string Nome { get; set; }

        public int EspecialidadeId { get; set; }
        public Especialidade Especialidade { get; set; }
    }
}