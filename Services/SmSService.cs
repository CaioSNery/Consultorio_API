using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Interfaces;
using Consultorio.Settings;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Consultorio.Services
{
    public class SmSService:ISmSService
    {
        private readonly TwilioSettings _settings;
        public SmSService(IOptions<TwilioSettings> options)
        {
            _settings = options.Value;
            TwilioClient.Init(_settings.AccountSID, _settings.AuthToken);
        }

        public async Task EnviarSMSAsync(string numero, string mensagem)
        {
            await MessageResource.CreateAsync(
                to: new PhoneNumber(numero),
                from: new PhoneNumber(_settings.From),
                body: mensagem
            );
        }
    }
}