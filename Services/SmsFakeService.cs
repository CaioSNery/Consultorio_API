using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Interfaces;

namespace Consultorio_API.Services
{
    public class SmsFakeService : ISmSService
    {
        
            public Task EnviarSMSAsync(string numero, string mensagem)
        {
            Console.WriteLine($"📩 [FAKE SMS] Para: {numero} | Mensagem: {mensagem}");
            return Task.CompletedTask;
        }
        
    }
}