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
    public class PersonajeRepositorio : IPersonajeRepositorio
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PersonajeRepositorio(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<PersonajeModel>> ObtenerTodos()
        {
            var entities = await _context.Personajes.ToListAsync();
            var models = _mapper.Map<List<PersonajeModel>>(entities);
            return models;
        }

        public async Task GuardarPersonajes(PersonajeCreacionModel model)
        {
            var entidad = _mapper.Map<Personaje>(model);
            _context.Personajes.Add(entidad);
            await _context.SaveChangesAsync();
        }

        public async Task<PersonajeEdicionModel> BuscarPersonajePorId(int id)
        {
            var entidad = await _context.Personajes.FirstOrDefaultAsync(x => x.Id == id);
            var model = _mapper.Map<PersonajeEdicionModel>(entidad);
            return model;
        }

        public async Task ActualizarPersonaje(PersonajeEdicionModel model)
        {
            var entidad = await _context.Personajes.FirstOrDefaultAsync(x => x.Id == model.Id);
            entidad.Nombre = model.Nombre;
            entidad.FechaLanzamiento = Convert.ToDateTime(model.FechaLanzamiento);
            entidad.Biografia = model.Biografia;
            entidad.ImagenUrl = model.ImagenUrl;
            await _context.SaveChangesAsync();
        }

        public async Task EliminarPersonaje(int id)
        {
            var entidad = await _context.Personajes.FirstOrDefaultAsync(x => x.Id == id);
            _context.Personajes.Remove(entidad);
            await _context.SaveChangesAsync();
        }
    }
}
