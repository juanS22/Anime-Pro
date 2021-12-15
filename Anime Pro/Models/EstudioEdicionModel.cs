using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anime_Pro.Models
{
    public class EstudioEdicionModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo nombre es requerido")]
        public string Nombre { get; set; }
        public string ImagenUrl { get; set; }
    }
}
