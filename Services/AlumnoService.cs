using AutoMapper;
using ExampleDockerAPI.DTOs;
using ExampleDockerAPI.Interfaces;
using ExampleDockerAPI.Models;
using System.Text.Json;

namespace ExampleDockerAPI.Services
{
    public class AlumnoService : IAlumnoService
    {
        private readonly IAlumnoRepository alumnoRepository;
        private readonly IMapper mapper;

        public AlumnoService(IAlumnoRepository alumnoRepository, IMapper mapper) {
            this.alumnoRepository = alumnoRepository;
            this.mapper = mapper;
        }

        public async Task<List<Alumno>> Get()
        {
            List<Alumno> alumnos = new List<Alumno>();
            
            try
            {
                alumnos = await alumnoRepository.Get();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar recuperar los datos: " + ex.Message.ToString());
            }

            return alumnos;
        }

        public async Task<string> Post(AlumnoDTO nuevoAlumno)
        {
            List<Alumno> alumnos;
            string sResp = string.Empty;

            try
            {
                var alumno = mapper.Map<Alumno>(nuevoAlumno);
                alumnos = await alumnoRepository.Get();

                int ultimoId = alumnos.Max(alumno => alumno.Id);
                var existeNombre = alumnos.Find(alumno => alumno.Nombre == nuevoAlumno.Nombre);
                var existeMatricula = alumnos.Find(alumno => alumno.Matricula == nuevoAlumno.Matricula);

                if (existeMatricula != null)
                {
                    sResp = "Matricula";
                }

                if (existeNombre != null)
                {
                    sResp = "Nombre";
                }

                if (existeMatricula == null && existeNombre == null)
                {
                    alumno.Id = ultimoId + 1 ;
                    sResp = await alumnoRepository.Post(alumno, alumnos);
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return sResp;
        }

        public async Task<string> Put(Alumno alumnoEditar)
        {
            List<Alumno> alumnos;
            string sResp = string.Empty;

            try
            {
                alumnos = await alumnoRepository.Get();
                var alumnoPorActualizar = alumnos.Find(alumno => alumno.Id == alumnoEditar.Id);

                if (alumnoPorActualizar == null)
                {
                    sResp = "Id";
                }
                else
                {
                    sResp = await alumnoRepository.Put(alumnoEditar, alumnos);
                }       
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return sResp;
        }

        public async Task<string> Delete(int idAlumno)
        {
            List<Alumno> alumnos;
            string sResp = string.Empty;

            try
            {
                alumnos = await alumnoRepository.Get();
                var alumnoAEliminar = alumnos.Find(alumno => alumno.Id == idAlumno);

                if (alumnoAEliminar == null)
                {
                    sResp = "Id";
                }
                else
                {
                    sResp = await alumnoRepository.Delete(idAlumno, alumnos, alumnoAEliminar);
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return sResp;
        }
    }
}
