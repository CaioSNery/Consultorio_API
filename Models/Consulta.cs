using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Models
{
    public class Consulta
    {
        public int Id { get; set; }
       
        public DateTime DataConsulta { get; set; }

        

        public decimal PrecoConsulta { get; set; }

        public int ProfissionalId { get; set; }
        public Profissional Profissional;

         public int PacienteId { get; set; }
        public Paciente Paciente;
        
        public int EspecialidadeId { get; set; }
        public Especialidade Especialidade;

        

        
        
        
    }
}