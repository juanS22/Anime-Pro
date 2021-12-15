using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anime_Pro.Models.Entidades
{
    public class SeriePersonaje
    {
        public int PersonajeId { get; set; }
        public int SerieId { get; set; }
        public Personaje Personaje  { get; set; }
        public Serie Serie { get; set; }
    }
}
