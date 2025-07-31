using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Settings;
using Consultorio_API.Interfaces;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Consultorio_API.Services
{
    public class MensagemService : IMensagemService
    {
        private readonly TwilioSettings _settings;
        public MensagemService(IOptions<TwilioSettings> options)
        {
            _settings = options.Value;
            TwilioClient.Init(_settings.AccountSID, _settings.AuthToken);
        }
        public async Task EnviarMsgWhatsAsync(string numero, string mensagem)
        {
            if (string.IsNullOrWhiteSpace(numero))
            {
                Console.WriteLine("⚠️ Número de telefone vazio para envio de WhatsApp.");
                return;
            }

            try
            {
                // Adiciona o prefixo "whatsapp:" automaticamente
                var message = await MessageResource.CreateAsync(
                    to: new PhoneNumber($"whatsapp:{numero}"),
                    from: new PhoneNumber(_settings.FromWhatsApp),
                    body: mensagem
                );

                Console.WriteLine($"✅ WhatsApp enviado para {numero}. SID: {message.Sid}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Erro ao enviar WhatsApp para {numero}: {ex.Message}");
                Console.WriteLine("ℹ️ Verifique se o número está habilitado no Sandbox do Twilio.");
                throw;
            }
        }
    }
    
}