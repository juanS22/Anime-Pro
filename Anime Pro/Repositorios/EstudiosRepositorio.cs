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
    public class EstudiosRepositorio : IEstudiosRepositorio
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EstudiosRepositorio(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<EstudioModel>> ObtenerTodos()
        {
            var entities = await _context.Estudios.ToListAsync();
            var models = _mapper.Map<List<EstudioModel>>(entities);
            return models;
        }

        public async Task GuardarEstudio(EstudioCreacionModel model)
        {
            var entidad = _mapper.Map<Estudio>(model);
            _context.Estudios.Add(entidad);
            await _context.SaveChangesAsync();
        }

        public async Task<EstudioEdicionModel> BuscarEstudioPorId(int id)
        {
            var entidad = await _context.Estudios.FirstOrDefaultAsync(x => x.Id == id);
            var model = _mapper.Map<EstudioEdicionModel>(entidad);
            return model;
        }

        public async Task ActualizarEstudio(EstudioEdicionModel model)
        {
            var entidad = await _context.Estudios.FirstOrDefaultAsync(x => x.Id == model.Id);
            entidad.Nombre = model.Nombre;
            await _context.SaveChangesAsync();
        }

        public async Task EliminarEstudio(int id)
        {
            var entidad = await _context.Estudios.FirstOrDefaultAsync(x => x.Id == id);
            _context.Estudios.Remove(entidad);
            await _context.SaveChangesAsync();
        }
    }
}
