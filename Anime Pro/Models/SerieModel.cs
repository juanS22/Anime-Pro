using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anime_Pro.Models
{
    public class SerieModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Anio { get; set; }
        public string Sinopsis { get; set; }
        public string Trailer { get; set; }
        public string AficheUrl { get; set; }
        public string EstudioNombre { get; set; }
        public string PersonajeNombre { get; set; }
        public string GeneroNombre { get; set; }
        public List<PersonajeListaModel> Personajes { get; set; }
        public List<string> Generos { get; set; }
    }
}
