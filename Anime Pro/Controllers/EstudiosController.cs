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
    public class EstudiosController : Controller

        {
        private readonly IEstudiosRepositorio _repositorio;
        private readonly IAlmacenadorArchivos _almacenadorArchivos;

        public EstudiosController(IEstudiosRepositorio repositorio, IAlmacenadorArchivos almacenadorArchivos)
            {
                _repositorio = repositorio;
            _almacenadorArchivos = almacenadorArchivos;
        }
            public async Task<IActionResult> Index()
            {
                var estudios = await _repositorio.ObtenerTodos();
                return View(estudios);
            }

            public IActionResult NuevoEstudio()
            {
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> NuevoEstudio(EstudioCreacionModel model)
            {
                if (ModelState.IsValid)
                {
                if (model.Imagen !=null)
                {
                    var urlImagen = await _almacenadorArchivos.GuardarArchivo(model.Imagen,"imagenes_anime");
                    model.ImageUrl = urlImagen;

                }
                    
                    await _repositorio.GuardarEstudio(model);
                    var list = await _repositorio.ObtenerTodos();
                    return View("Index", list);
                }
                return View("NuevoEstudio", model);
            }

            public async Task<IActionResult> EditarEstudio([FromRoute] int id)
            {
                var genero = await _repositorio.BuscarEstudioPorId(id);
                return View(genero);
            }

            [HttpPost]

            public async Task<IActionResult> EditarEstudio(EstudioEdicionModel model)
            {
                if (ModelState.IsValid)
                {
                    await _repositorio.ActualizarEstudio(model);
                    var list = await _repositorio.ObtenerTodos();
                    return View("Index", list);
                }

                return View("EditarEstudio", model);
            }
            public async Task<IActionResult> EliminarEstudio([FromRoute] int id)
            {
                var estudio = await _repositorio.BuscarEstudioPorId(id);
                return View(estudio);
            }

            [HttpPost]
            public async Task<IActionResult> EliminarEstudio(EstudioEdicionModel model)
            {
                await _repositorio.EliminarEstudio(model.Id);
                var list = await _repositorio.ObtenerTodos();
                return View("Index", list);
            }
        }
    }
