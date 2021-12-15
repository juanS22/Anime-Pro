using Anime_Pro.Models;
using Anime_Pro.Models.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anime_Pro.Repositorios
{
    public class SeriesRepositorio : ISeriesRepositorio
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPersonajeRepositorio _personajeRepositorio;
        private readonly IGenerosRepositorio _generosRepositorio;
        private readonly IEstudiosRepositorio _estudiosRepositorio;

        public SeriesRepositorio(ApplicationDbContext context, IMapper mapper, IPersonajeRepositorio personajeRepositorio, IGenerosRepositorio generosRepositorio, IEstudiosRepositorio estudiosRepositorio)
        {
            _context = context;
            _mapper = mapper;
            _personajeRepositorio = personajeRepositorio;
            _generosRepositorio = generosRepositorio;
            _estudiosRepositorio = estudiosRepositorio;
        }
        public async Task<SerieCreacionModel> NuevaSerieCreacionModel()
        {
            var resultado = new SerieCreacionModel();
            var listaPersonajes = await _personajeRepositorio.ObtenerTodos();
            var listaGeneros = await _generosRepositorio.ObtenerTodos();
            var listaEstudios = await _estudiosRepositorio.ObtenerTodos();

            var selectListPersonajes = new SelectList(listaPersonajes, "Id", "Nombre");
            var selectListGeneros = new SelectList(listaGeneros, "Id", "Nombre");
            var selectListEstudios = new SelectList(listaEstudios, "Id", "Nombre");
            resultado.Personajes = selectListPersonajes;
            resultado.Generos = selectListGeneros;
            resultado.Estudios = selectListEstudios;

            return resultado;
        }
        public async Task GuardarSeries(SerieCreacionModel model)
        {
            var entidad = _mapper.Map<Serie>(model);
            _context.Series.Add(entidad);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SerieModel>> ObtenerTodas()
        {
            var entidades = await _context.Series
                .Include(s => s.Estudio)
                .Include(s => s.SeriesPersonajes)
                .ThenInclude(sp => sp.Personaje)
                .Include(s => s.SeriesGeneros)
                .ThenInclude(sg => sg.Genero)
                .ToListAsync();
            var resultado = _mapper.Map<List<SerieModel>>(entidades);
            return resultado;
        }

        public async Task<SerieEdicionModel> BuscarPorId(int id)
        {
            var entidades = await _context.Series.FirstOrDefaultAsync(x => x.Id == id);
            var model = _mapper.Map<SerieEdicionModel>(entidades);
            return model;
        }

        public async Task ActualizarSerie(SerieEdicionModel model)
        {
            var entidad = await _context.Series.FirstOrDefaultAsync(x => x.Id == model.Id);
            entidad.Nombre = model.Nombre;
            entidad.Anio = Convert.ToInt32(model.Anio);
            entidad.Sinopsis = model.Sinopsis;
            entidad.AficheUrl = model.AficheUrl;
            entidad.Trailer = model.Trailer;
            await _context.SaveChangesAsync();
        }
    }
}
