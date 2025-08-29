

using AutoMapper;
using Consultorio.Dtos;
using Consultorio.Models;

namespace Consultorio.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Paciente, PacienteDTO>()
            .ForMember(dest => dest.NomePaciente, opt => opt.MapFrom(src => src.Nome));

            CreateMap<PacienteDTO, Paciente>()
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.NomePaciente));

            CreateMap<PacienteCreateDTO, Paciente>()
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.NomePaciente));


            CreateMap<Profissional, ProfissionalDTO>()
            .ForMember(dest => dest.NomeMedico, opt => opt.MapFrom(src => src.Nome));

            CreateMap<ProfissionalDTO, Profissional>()
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.NomeMedico));

            CreateMap<ProfissionalCreateDTO, Profissional>()
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.NomeMedico))
            .ForMember(dest => dest.EspecialidadeId, opt => opt.MapFrom(src => src.EspecialidadeId));


            CreateMap<ConsultaDTO, Consulta>().ReverseMap();

            CreateMap<EspecialidadeDTO, Especialidade>().ReverseMap();


        }
    }
}