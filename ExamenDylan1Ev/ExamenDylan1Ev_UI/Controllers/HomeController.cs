using ExamenDylan1Ev_BL.Listados;
using ExamenDylan1Ev_BL.Manejadora;
using ExamenDylan1Ev_Entidades.Persistencia;
using ExamenDylan1Ev_UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamenDylan1Ev_UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //Poner try catch

            //instanciamos objeto del viewmodel y lo mandamos a la vista
            clsViewModel viewModel = new clsViewModel();
            //clsListadosPersonajes_BL gestora = new clsListadosPersonajes_BL();

            //try
            //{
                   // generar listado de nuevo
            //}
            //catch (Exception)
            //{

            //}

            return View(viewModel);
        }

        /// <summary>
        /// Action de Index tas submit
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(clsViewModel viewModel, String seleccionPersonaje)
        {

         clsPersonaje oPersonaje = new clsPersonaje();
         clsManejadoraPersonajes_BL manejadora = new clsManejadoraPersonajes_BL();
         int filas;

            if (seleccionPersonaje == "Editar")
            {
                try
                {
                    oPersonaje = manejadora.personaje_porID_BL(viewModel.idPersonajeSeleccionado);
                    viewModel.personajeSeleccionado = oPersonaje;
                }
                catch (Exception)
                {
                    //TODO
                }
            }

            if (seleccionPersonaje == "Guardar")
            {
                try {
                    oPersonaje = viewModel.personajeSeleccionado;
                    filas = manejadora.editarPersonaje_BL(oPersonaje);
                    ViewData["mensaje"] = "Guardado correctamente";
                } catch(Exception) {
                    ViewData["mensaje"] = "Error";
                }
            }



            return View(viewModel);
        }
    }
}