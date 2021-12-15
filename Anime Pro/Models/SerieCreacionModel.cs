using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anime_Pro.Models
{
    public class SerieCreacionModel
    {
        [MaxLength(100, ErrorMessage ="El campo {0} debe tener como maximo {1} caracteres")]
        [Required(ErrorMessage ="El campo {0} es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int? Anio { get; set; }
        [MaxLength(1000, ErrorMessage = "El campo {0} debe tener como maximo {1} caracteres")]
        public string Sinopsis { get; set; }
        public string Trailer { get; set; }
        public IFormFile Afiche { get; set; }
        public string  AficheUrl { get; set; }
        public List<int> PersonajeId { get; set; }
        public int? EstudioId { get; set; }
        public List<int> GeneroId { get; set; }
        public SelectList Personajes { get; set; }
        public SelectList Estudios { get; set; }
        public SelectList Generos { get; set; }


    }
}
