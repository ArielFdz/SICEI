using System.ComponentModel.DataAnnotations;

namespace ExampleDockerAPI.Models
{
    public class Alumno
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Matricula { get; set; }
    }
}
