using AutoMapper;
using ExampleDockerAPI.DTOs;
using ExampleDockerAPI.Models;

namespace ExampleDockerAPI.Utils
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
