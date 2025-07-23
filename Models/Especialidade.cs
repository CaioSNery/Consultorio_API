using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Models
{
    public class Especialidade
    {
        public int Id { get; set; }
        public string Tipo { get; set; }

        public decimal PrecoConsulta{ get; set; }

        public ICollection<Profissional> Profissionais { get; set; }
        
        

    }
}