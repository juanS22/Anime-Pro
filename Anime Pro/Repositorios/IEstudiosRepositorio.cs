using Anime_Pro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anime_Pro.Repositorios
{
    public interface IEstudiosRepositorio
    {
        Task ActualizarEstudio(EstudioEdicionModel model);
        Task<EstudioEdicionModel> BuscarEstudioPorId(int id);
        Task EliminarEstudio(int id);
        Task GuardarEstudio(EstudioCreacionModel model);
        Task<List<EstudioModel>> ObtenerTodos();
    }
}
