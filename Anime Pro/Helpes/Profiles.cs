using Anime_Pro.Models;
using Anime_Pro.Models.Entidades;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anime_Pro.Helpes
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Genero, GeneroModel>();
            CreateMap<GeneroCreacionModel, Genero>();
            CreateMap<Genero, GeneroEdicionModel>();
            CreateMap<Estudio, EstudioModel>();
            CreateMap<EstudioCreacionModel, Estudio>();
            CreateMap<Estudio, EstudioEdicionModel>();
            CreateMap<Personaje, PersonajeModel>();
            CreateMap<PersonajeCreacionModel, Personaje>();
            CreateMap<Personaje, PersonajeEdicionModel>();
            CreateMap<Personaje, PersonajeListaModel>();
            CreateMap<Serie, SerieEdicionModel>();
            CreateMap<SerieEdicionModel, Serie>();
            CreateMap<SerieCreacionModel, Serie>()
                .ForMember(serie=>serie.SeriesPersonajes, opciones=>opciones.MapFrom(MapSeriePersonaje))
                .ForMember(serie => serie.SeriesGeneros, opciones => opciones.MapFrom(MapSerieGenero))
                ;
            CreateMap<Serie, SerieModel>()
                .ForMember(serieModel => serieModel.PersonajeNombre, opciones => opciones.MapFrom(serie => serie.SeriesPersonajes.FirstOrDefault().Personaje.Nombre))
                .ForMember(serieModel => serieModel.GeneroNombre, opciones => opciones.MapFrom(serie => serie.SeriesGeneros.FirstOrDefault().Genero.Nombre))
                .ForMember(serieModel => serieModel.Personajes, opciones => opciones.MapFrom(serie => serie.SeriesPersonajes.Select(x=>x.Personaje)))
                .ForMember(serieModel => serieModel.Generos, opciones => opciones.MapFrom(serie => serie.SeriesGeneros.Select(x => x.Genero.Nombre)))
            ;
        }

        private List<SeriePersonaje> MapSeriePersonaje(SerieCreacionModel serieCreacionModel, Serie serie)
        {
            var resultado = new List<SeriePersonaje>();
            if (serieCreacionModel.PersonajeId == null)
            {
                return resultado;
            }

            foreach (var id in serieCreacionModel.PersonajeId)
            {
            resultado.Add(new SeriePersonaje { PersonajeId = id });
            }
            return resultado;
        }

        private List<SerieGenero> MapSerieGenero(SerieCreacionModel serieCreacionModel, Serie serie)
        {
            var resultado = new List<SerieGenero>();
            if (serieCreacionModel.GeneroId == null)
            {
                return resultado;
            }

            foreach (var id in serieCreacionModel.GeneroId)
            {
                resultado.Add(new SerieGenero { GeneroId = id });
            }           
            return resultado;
        }
    }
}
