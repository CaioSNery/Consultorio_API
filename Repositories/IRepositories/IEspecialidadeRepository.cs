using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Dtos;
using Consultorio.Models;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Interfaces
{
    public interface IEspecialidadeRepository
    {
        Task<Especialidade> AddEspecialidade(Especialidade especialidade);
        Task<bool> DeletarEspecialidade(int id);
    }
}