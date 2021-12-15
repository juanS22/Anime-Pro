using Anime_Pro.Helpes;
using Anime_Pro.Models;
using Anime_Pro.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anime_Pro.Controllers
{
    public class PersonajesController : Controller
    {
        private readonly IPersonajeRepositorio _repositorio;
        private readonly IAlmacenadorArchivos _almacenadorArchivos;
        private readonly string Carpeta = "img_personajes";

        public PersonajesController(IPersonajeRepositorio repositorio, IAlmacenadorArchivos almacenadorArchivos)
        {
            _repositorio = repositorio;
            _almacenadorArchivos = almacenadorArchivos;
        }
        public async Task<IActionResult> Index()
        {
            var lista = await _repositorio.ObtenerTodos();
            return View(lista);
        }

        public IActionResult NuevoPersonaje()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NuevoPersonaje(PersonajeCreacionModel model)
        {
            if (ModelState.IsValid)
            {
                var url = await _almacenadorArchivos.GuardarArchivo(model.Imagen, Carpeta);
                model.ImagenUrl = url;
                await _repositorio.GuardarPersonajes(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> EditarPersonaje([FromRoute] int id)
        {
            var modelo = await _repositorio.BuscarPersonajePorId(id);
            return View(modelo);
        }

        [HttpPost]

        public async Task<IActionResult> EditarPersonaje(PersonajeEdicionModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Imagen !=null)
                {
                    await _almacenadorArchivos.EliminarArchivo(model.ImagenUrl, Carpeta);
                    var nuevaUrl = await _almacenadorArchivos.GuardarArchivo(model.Imagen, Carpeta);
                    model.ImagenUrl = nuevaUrl;
                }
                await _repositorio.ActualizarPersonaje(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> EliminarPersonaje([FromRoute] int id)
        {
            var genero = await _repositorio.BuscarPersonajePorId(id);
            return View(genero);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarPersonaje(PersonajeEdicionModel model)
        {
            var entidad = await _repositorio.BuscarPersonajePorId(model.Id);
            await _almacenadorArchivos.EliminarArchivo(entidad.ImagenUrl, Carpeta);
            await _repositorio.EliminarPersonaje(model.Id);
            var list = await _repositorio.ObtenerTodos();
            return View("Index", list);
        }

        public async Task<IActionResult> ObtenerPorId([FromRoute] int id)
        {
            var modelo = await _repositorio.BuscarPersonajePorId(id);
            return View(modelo);
        }
    }
}
