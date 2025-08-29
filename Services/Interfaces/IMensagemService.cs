using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio_API.Interfaces
{
    public interface IMensagemService
    {
        Task EnviarMsgWhatsAsync(string numero, string mensagem);
    }
}