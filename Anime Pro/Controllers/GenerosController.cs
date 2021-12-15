using Anime_Pro.Models;
using Anime_Pro.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anime_Pro.Controllers
{
    public class GenerosController : Controller
    {
        private readonly IGenerosRepositorio _repositorio;

        public GenerosController(IGenerosRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public async Task<IActionResult> Index()
        {
            var generos = await _repositorio.ObtenerTodos();
            return View(generos);
        }

        public IActionResult NuevoGenero()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NuevoGenero(GeneroCreacionModel model)
        {
            if (ModelState.IsValid)
            {
                await _repositorio.GuardarGeneros(model);
                var list = await _repositorio.ObtenerTodos();
                return View("Index", list);
            }
            return View("NuevoGenero", model);
        }

        public async Task<IActionResult> EditarGenero([FromRoute] int id)
        {
            var genero = await _repositorio.BuscarGeneroPorId(id);
            return View(genero);
        }

        [HttpPost]

        public async Task<IActionResult> EditarGenero(GeneroEdicionModel model)
        {
            if (ModelState.IsValid)
            {
                await _repositorio.ActualizarGenero(model);
                var list = await _repositorio.ObtenerTodos();
                return View("Index", list);
            }

            return View("EditarGenero", model);
        }
        public async Task<IActionResult> EliminarGenero([FromRoute] int id)
        {
            var genero = await _repositorio.BuscarGeneroPorId(id);
            return View(genero);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarGenero(GeneroEdicionModel model)
        {
            await _repositorio.EliminarGenero(model.Id);
            var list = await _repositorio.ObtenerTodos();
            return View("Index", list);
        }
    }
}
