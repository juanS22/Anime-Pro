using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anime_Pro.Models
{
    public class GeneroEdicionModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo genero es requerido")]
        public string Nombre { get; set; }
    }
}
