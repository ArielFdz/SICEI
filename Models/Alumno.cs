﻿using System.ComponentModel.DataAnnotations;

namespace SICEI.Models
{
    public class Alumno
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Matricula { get; set; }
    }
}
