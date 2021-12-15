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
    public class SeriesController : Controller
    {
        private readonly ISeriesRepositorio _repositorio;
        private readonly IAlmacenadorArchivos _almacenadorArchivos;
        private readonly string Carpeta = "imagenes_afiches";

        public SeriesController(ISeriesRepositorio repositorio, IAlmacenadorArchivos almacenadorArchivos)
        {
            _repositorio = repositorio;
            _almacenadorArchivos = almacenadorArchivos;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _repositorio.ObtenerTodas();
            return View(model);
        }

        public async Task<IActionResult> Nuevo()
        {
            var model = await _repositorio.NuevaSerieCreacionModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(SerieCreacionModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Afiche != null)
                {
                    var urlAfiche = await _almacenadorArchivos.GuardarArchivo(model.Afiche, Carpeta);
                    model.AficheUrl = urlAfiche;
                }

                await _repositorio.GuardarSeries(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> EditarSerie([FromRoute] int id)
        {    
            var modelo = await _repositorio.BuscarPorId(id);
            return View(modelo);
        }

        [HttpPost]

        public async Task<IActionResult> EditarSerie(SerieEdicionModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Afiche != null)
                {
                    await _almacenadorArchivos.EliminarArchivo(model.AficheUrl, Carpeta);
                    var nuevaUrl = await _almacenadorArchivos.GuardarArchivo(model.Afiche, Carpeta);
                    model.AficheUrl = nuevaUrl;
                }
                await _repositorio.ActualizarSerie(model);
                return RedirectToAction("Index");
            }
            return View(model);

        }

       }
}
