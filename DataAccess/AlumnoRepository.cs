using SICEI.DTOs;
using SICEI.Interfaces;
using SICEI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace SICEI.DataAccess
{
    public class AlumnoRepository : IAlumnoRepository
    {
        //public static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content/Alumno.json");
        public static List<Alumno> listaAlumnos = new List<Alumno>()
        {
            new Alumno { Id = 1, Nombre = "Juan", Matricula = "A12345" },
            new Alumno { Id = 2, Nombre = "María", Matricula = "B67890" },
            new Alumno { Id = 3, Nombre = "Pedro", Matricula = "C24680" }
        };

        public async Task<List<Alumno>> Get()
        {
            List<Alumno> alumnos;

            try
            {
                alumnos = listaAlumnos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return alumnos;
        }

        public async Task<string> Post(Alumno nuevoAlumno)
        {
            string sResp = string.Empty;

            try
            {

                listaAlumnos.Add(nuevoAlumno);
                sResp = "Alumno agregado correctamente - ID: " + nuevoAlumno.Id;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return sResp;
        }

        public async Task<string> Put(Alumno alumnoEditar)
        {
            string sResp = string.Empty;

            try
            {
                var alumnoPorActualizar = listaAlumnos.Find(alumno => alumno.Id == alumnoEditar.Id);
                alumnoPorActualizar.Nombre = alumnoEditar.Nombre;
                alumnoPorActualizar.Matricula = alumnoEditar.Matricula;

                sResp = $"Estudiante con ID {alumnoPorActualizar.Id} actualizado correctamente";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return sResp;
        }

        public async Task<string> Delete(int id, Alumno alumnoEliminar)
        {
            string response = string.Empty;
            string jsonString = string.Empty;

            try
            {
                listaAlumnos.Remove(alumnoEliminar);
                response = $"Estudiante con ID {id} eliminado correctamente";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return response;
        }


    }
}
