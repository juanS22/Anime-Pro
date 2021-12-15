using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anime_Pro.Models.Entidades
{
    public class Personaje
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Nombre { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        [MaxLength(1500)]
        public string Biografia { get; set; }
        [MaxLength(255)]
        public string ImagenUrl { get; set; }

        public List<SeriePersonaje> SeriesPersonajes { get; set; }
    }
}
