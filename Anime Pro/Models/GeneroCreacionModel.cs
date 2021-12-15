using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anime_Pro.Models
{
    public class GeneroCreacionModel
    {
        [Required(ErrorMessage ="El campo nombre es requerido")]
        public string Nombre { get; set; }
    }
}
