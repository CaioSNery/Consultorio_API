using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Interfaces
{
    public interface ISmSService
    {
        Task EnviarSMSAsync(string numero,string mensagem);
    }
}