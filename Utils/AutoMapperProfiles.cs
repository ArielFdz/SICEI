using AutoMapper;
using SICEI.DTOs;
using SICEI.Models;

namespace SICEI.Utils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AlumnoDTO, Alumno>();
            CreateMap<Alumno, AlumnoDTO>();
        }

    }
}
