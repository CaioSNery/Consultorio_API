using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Data;
using Consultorio.Interfaces;
using Consultorio.Services;
using Consultorio_API.Interfaces;
using Consultorio_API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Consultorio_API.Extensions
{
    public static class ExtensionMethods
    {
        public static void AddServices(this IServiceCollection service)
        {
            service.AddScoped<IAuthService, AuthService>();
            service.AddScoped<IMensagemService, MensagemFakeService>();
            service.AddScoped<ISmSService, SmsFakeService>();

            // service.AddScoped<ISmSService, SmSService>();
            // service.AddScoped<IMensagemService, MensagemService>();

            // RETIRAR O COMENTARIO PARA TESTE COM TWILIO

        }

        public static void AddRepositories(this IServiceCollection service)
        {
            service.AddScoped<IConsultaService, ConsultaService>();
            service.AddScoped<IEspecialidadeService, EspecialidadeService>();
            service.AddScoped<IPacienteService, PacienteService>();
            service.AddScoped<IProfissionalService, ProfissionalService>();

        }

        public static void AddSqlConnection(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<AppDbContext>(options =>
                  options.UseSqlServer(configuration.GetConnectionString("Default")));

        }

    }
}