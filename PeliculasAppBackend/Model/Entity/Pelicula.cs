using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Pelicula
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        [MaxLength(4000)]
        public string Sinopsis { get; set; }

        [Required]
        public string Genero { get; set; }

        [Required]
        public string Duracion { get; set; }

        [Required]
        public string HorarioInicio { get; set; }

        [Required]
        public string HorarioFin { get; set; }

        public string Imagen { get; set; }

        [Required]
        public string SalasDisponibles { get; set; }

        [Required]
        public string EntradasDisponibles { get; set; }
    }
}
