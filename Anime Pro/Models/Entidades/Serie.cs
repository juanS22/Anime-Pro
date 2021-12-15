using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anime_Pro.Models.Entidades
{
    public class Serie
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        public int Anio { get; set; }
        public string Sinopsis { get; set; }
        [MaxLength(1000)]
        public string Trailer { get; set; }
        public string AficheUrl { get; set; }

        public int EstudioId { get; set; }
        public Estudio Estudio { get; set; }
        public List<SerieGenero> SeriesGeneros { get; set; }
        public List<SeriePersonaje> SeriesPersonajes { get; set; }
    }
}
