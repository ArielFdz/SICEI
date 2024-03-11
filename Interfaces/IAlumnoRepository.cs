using ExampleDockerAPI.DTOs;
using ExampleDockerAPI.Models;

namespace ExampleDockerAPI.Interfaces
{
    public interface IAlumnoRepository
    {
        public Task<List<Alumno>> Get();
        public Task<string> Post(Alumno nuevoAlumno, List<Alumno> alumnos);
        public Task<string> Put(Alumno alumnoEditar, List<Alumno> alumnos);
        public Task<string> Delete(int id, List<Alumno> alumnos, Alumno alumnoEliminar);
    }
}
