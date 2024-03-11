using SICEI.DTOs;
using SICEI.Interfaces;
using SICEI.Models;
using SICEI.Services;
using Microsoft.AspNetCore.Mvc;

namespace SICEI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlumnoController: ControllerBase
    {
        private readonly IAlumnoService alumnoService;

        public AlumnoController(IAlumnoService alumnoService)
        {
            this.alumnoService = alumnoService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var alumnos = await alumnoService.Get();

                if (alumnos.Count == 0)
                {
                    return NotFound("No existen Alumnos registrados");
                }

                return Ok(alumnos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AlumnoDTO alumnoDTO)
        {
            try
            {
                var alumnos = await alumnoService.Post(alumnoDTO);

                if (alumnos == "")
                {
                    return StatusCode(500, "Ocurrió un error, vuelve a intentarlo");
                }

                if(alumnos == "Nombre")
                {
                    return BadRequest("Ya existe un alumno con el mismo nombre");
                }
                
                if (alumnos == "Matricula")
                {
                    return BadRequest("Ya existe un alumno con la misma matrícula");
                }

                return Ok(alumnos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Alumno alumno)
        {
            try
            {
                var alumnos = await alumnoService.Put(alumno);

                if (alumnos == "")
                {
                    return StatusCode(500, "Ocurrió un error, vuelve a intentarlo");
                }

                if (alumnos == "Id")
                {
                    return BadRequest($"No existe un alumno con el id {alumno.Id}");
                }

                return Ok(alumnos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int idAlumno)
        {
            try
            {
                var alumnos = await alumnoService.Delete(idAlumno);

                if (alumnos == "")
                {
                    return StatusCode(500, "Ocurrió un error, vuelve a intentarlo");
                }

                if (alumnos == "Id")
                {
                    return BadRequest($"No existe un alumno con el id {idAlumno}");
                }

                return Ok(alumnos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
        }
    }
}
