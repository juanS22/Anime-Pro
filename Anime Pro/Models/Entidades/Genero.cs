using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anime_Pro.Models.Entidades
{
    public class Genero
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        public List<SerieGenero> SeriesGeneros { get; set; }
    }
}
