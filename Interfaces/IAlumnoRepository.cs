using SICEI.DTOs;
using SICEI.Models;

namespace SICEI.Interfaces
{
    public interface IAlumnoRepository
    {
        public Task<List<Alumno>> Get();
        public Task<string> Post(Alumno nuevoAlumno);
        public Task<string> Put(Alumno alumnoEditar);
        public Task<string> Delete(int id, Alumno alumnoEliminar);
    }
}
