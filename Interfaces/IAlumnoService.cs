using SICEI.DTOs;
using SICEI.Models;

namespace SICEI.Interfaces
{
    public interface IAlumnoService
    {
        public Task<List<Alumno>> Get();
        public Task<string> Post(AlumnoDTO nuevoAlumno);
        public Task<string> Put(Alumno alumno);
        public Task<string> Delete(int idAlumno);
    }
}
