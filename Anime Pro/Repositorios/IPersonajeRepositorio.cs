using Anime_Pro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anime_Pro.Repositorios
{
    public interface IPersonajeRepositorio
    {
        Task ActualizarPersonaje(PersonajeEdicionModel model);
        Task<PersonajeEdicionModel> BuscarPersonajePorId(int id);
        Task EliminarPersonaje(int id);
        Task GuardarPersonajes(PersonajeCreacionModel model);
        Task<List<PersonajeModel>> ObtenerTodos();
    }
}
