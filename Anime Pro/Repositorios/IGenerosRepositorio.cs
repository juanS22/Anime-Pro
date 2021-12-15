using Anime_Pro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anime_Pro.Repositorios
{
    public interface IGenerosRepositorio
    {
        Task ActualizarGenero(GeneroEdicionModel model);
        Task<GeneroEdicionModel> BuscarGeneroPorId(int id);
        Task EliminarGenero(int id);
        Task GuardarGeneros(GeneroCreacionModel model);
        Task<List<GeneroModel>> ObtenerTodos();
    }
}
