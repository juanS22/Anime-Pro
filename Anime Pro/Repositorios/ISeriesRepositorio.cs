using Anime_Pro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anime_Pro.Repositorios
{
    public interface ISeriesRepositorio
    {
        Task<SerieEdicionModel> BuscarPorId(int id);
        Task GuardarSeries(SerieCreacionModel model);
        Task<SerieCreacionModel> NuevaSerieCreacionModel();
        Task<List<SerieModel>> ObtenerTodas();
        Task ActualizarSerie(SerieEdicionModel model);
    }
}
