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
        public static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content/Alumno.json");

        public async Task<List<Alumno>> Get()
        {
            List<Alumno> alumnos;

            try
            {

                if (string.IsNullOrEmpty(filePath))
                {
                    throw new Exception("No se encontró ningún archivo con ese nombre");
                }

                string jsonString = await File.ReadAllTextAsync(filePath);

                alumnos = jsonString.Length > 0 ? JsonSerializer.Deserialize<List<Alumno>>(jsonString) : new List<Alumno>();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return alumnos;
        }

        public async Task<string> Post(Alumno nuevoAlumno, List<Alumno> alumnos)
        {
            string sResp = string.Empty;
            string jsonString = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    throw new Exception("No se encontró ningún archivo con ese nombre");
                }

                alumnos.Add(nuevoAlumno);
                jsonString = JsonSerializer.Serialize(alumnos);
                await File.WriteAllTextAsync(filePath, jsonString);
                sResp = "Alumno agregado correctamente - ID: " + nuevoAlumno.Id;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return sResp;
        }

        public async Task<string> Put(Alumno alumnoEditar, List<Alumno> alumnos)
        {

            string sResp = string.Empty;
            string jsonString = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    throw new Exception("No se encontró ningún archivo con ese nombre");
                }

                var alumnoPorActualizar = alumnos.Find(alumno => alumno.Id == alumnoEditar.Id);

                alumnoPorActualizar.Nombre = alumnoEditar.Nombre;
                alumnoPorActualizar.Matricula = alumnoEditar.Matricula;
                jsonString = JsonSerializer.Serialize(alumnos);

                await File.WriteAllTextAsync(filePath, jsonString);

                sResp = $"Estudiante con ID {alumnoPorActualizar.Id} actualizado correctamente";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return sResp;
        }

        public async Task<string> Delete(int id, List<Alumno> alumnos, Alumno alumnoEliminar)
        {
            string response = string.Empty;
            string jsonString = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    throw new Exception("No se encontró ningún archivo con ese nombre");
                }

                alumnos.Remove(alumnoEliminar);
                jsonString = JsonSerializer.Serialize(alumnos);
                await File.WriteAllTextAsync(filePath, jsonString);

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
