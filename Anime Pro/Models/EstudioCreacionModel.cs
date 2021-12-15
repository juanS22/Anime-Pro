using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anime_Pro.Models
{
    public class EstudioCreacionModel
    {
        [Required(ErrorMessage ="El nombre es requerido")]
        public string Nombre { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Imagen { get; set; }
    }
}
