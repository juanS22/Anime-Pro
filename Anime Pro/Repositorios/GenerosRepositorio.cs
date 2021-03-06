using Anime_Pro.Models;
using Anime_Pro.Models.Entidades;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anime_Pro.Repositorios
{
    public class GenerosRepositorio : IGenerosRepositorio
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GenerosRepositorio(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GeneroModel>> ObtenerTodos()
        {
            var entities = await _context.Generos.ToListAsync();
            var models = _mapper.Map<List<GeneroModel>>(entities);
            return models;
        }
        public async Task GuardarGeneros(GeneroCreacionModel model)
        {
            var entidad = _mapper.Map<Genero>(model);
            _context.Generos.Add(entidad);
            await _context.SaveChangesAsync();
        }

        public async Task<GeneroEdicionModel> BuscarGeneroPorId(int id)
        {
            var entidad = await _context.Generos.FirstOrDefaultAsync(x => x.Id == id);
            var model = _mapper.Map<GeneroEdicionModel>(entidad);
            return model;
        }

        public async Task ActualizarGenero(GeneroEdicionModel model)
        { 
            var entidad = await _context.Generos.FirstOrDefaultAsync(x => x.Id == model.Id);
            entidad.Nombre = model.Nombre;
            await _context.SaveChangesAsync();
        }

        public async Task EliminarGenero(int id)
        {
            var entidad = await _context.Generos.FirstOrDefaultAsync(x => x.Id == id);
            _context.Generos.Remove(entidad);
            await _context.SaveChangesAsync();
        }
    }
}
