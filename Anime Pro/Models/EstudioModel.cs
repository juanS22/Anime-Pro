using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anime_Pro.Models
{
    public class EstudioModel
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
