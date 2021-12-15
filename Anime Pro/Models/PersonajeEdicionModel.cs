using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anime_Pro.Models
{
    public class PersonajeEdicionModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(255, ErrorMessage = "El campo {0} debe tener como maximo {1} caracteres")]
        [MinLength(3, ErrorMessage = "El campo {0} debe tener como minimo {1} caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime? FechaLanzamiento { get; set; }
        [MaxLength(1500, ErrorMessage = "El campo {0} debe tener como maximo {1} caracteres")]
        public string Biografia { get; set; }
        public string ImagenUrl { get; set; }

        public IFormFile Imagen { get; set; }
    }
}
