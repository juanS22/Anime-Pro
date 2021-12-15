using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anime_Pro.Models.Entidades
{
    public class SerieGenero
    {
        public int SerieId { get; set; }
        public int GeneroId { get; set; }
        public Serie Serie { get; set; }
        public Genero Genero { get; set; }
    }
}
