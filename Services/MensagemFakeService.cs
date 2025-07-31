using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio_API.Interfaces;

namespace Consultorio_API.Services
{
    public class MensagemFakeService : IMensagemService
    {
        
             public Task EnviarMsgWhatsAsync(string numero, string mensagem)
        {
            Console.WriteLine($"📱 [FAKE WhatsApp] Para: {numero} | Mensagem: {mensagem}");
            return Task.CompletedTask;
        }

    
        }
    }
