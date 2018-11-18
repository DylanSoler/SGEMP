using _07_CRUD_Personas_BL.Listados;
using _07_CRUD_Personas_BL.Manejadoras;
using _07_CRUD_Personas_DAL.Manejadoras;
using _07_CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _07_CRUD_Personas_UI.Controllers
{
    public class PersonasController : Controller
    {
        // GET: Personas
        public ActionResult listadoCompleto()
        {
            clsListadoPersonas_BL gestora = new clsListadoPersonas_BL();
            List<clsPersona> listado = new List<clsPersona>();

            try
            {
                listado = gestora.listadoCompletoPersonas_BL();
            }
            catch(Exception e) {

                ViewData["ErrorNoControlado"] = "Ha ocurrido un error";
            }

            return View(listado);
        }

        public ActionResult Delete(int id) {

            clsPersona oPersona = new clsPersona();

            clsManejadoraPersona_BL manejadora = new clsManejadoraPersona_BL();
            oPersona = manejadora.personaPorID_BL(id);

            return View(oPersona);
        }

        /// <summary>
        /// Action del post Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName ("Delete")]
        public ActionResult DeletePost(int id)
        {
            int filas = 0;
            clsManejadoraPersona_BL manejadora = new clsManejadoraPersona_BL();
            clsListadoPersonas_BL gestora = new clsListadoPersonas_BL();
            List<clsPersona> listado = new List<clsPersona>();

            try
            {
                filas = manejadora.borrarPersonaPorID_BL(id);
                ViewData["FilasAfectadas"] = $"Se ha borrado correctamente {filas} registro";
                listado = gestora.listadoCompletoPersonas_BL();
            }
            catch (Exception e) {

                ViewData["ErrorNoControlado"] = "Ha ocurrido un error borrando";
            }

            return View("listadoCompleto",listado);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create() {

            return View();
        }

        [HttpPost]
        public ActionResult Create(clsPersona oPersona)
        {
            int filas = 0;
            clsManejadoraPersona_BL manejadora = new clsManejadoraPersona_BL();
            clsListadoPersonas_BL gestora = new clsListadoPersonas_BL();
            List<clsPersona> listado = new List<clsPersona>();

            try{
                filas = manejadora.insertarPersona_BL(oPersona);
                ViewData["FilasAfectadas"] = $"Se ha insertado correctamente {filas} registro";
                listado = gestora.listadoCompletoPersonas_BL();
            } catch (Exception e) {
                ViewData["ErrorNoControlado"] = "Ha ocurrido un error en la insercion";
            }

            return View("listadoCompleto",listado);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id) {

            clsPersona oPersona = new clsPersona();

            clsManejadoraPersona_BL manejadora = new clsManejadoraPersona_BL();
            oPersona = manejadora.personaPorID_BL(id);

            return View(oPersona);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id) {

            clsPersona oPersona = new clsPersona();

            clsManejadoraPersona_BL manejadora = new clsManejadoraPersona_BL();
            oPersona = manejadora.personaPorID_BL(id);

            return View(oPersona);
        }

        [HttpPost]
        public ActionResult Edit(clsPersona oPersona)
        {
            int filas;
            clsManejadoraPersona_BL manejadora = new clsManejadoraPersona_BL();
            clsListadoPersonas_BL gestora = new clsListadoPersonas_BL();
            List<clsPersona> listado = new List<clsPersona>();

            try{
                filas = manejadora.editarPersona_BL(oPersona);
                ViewData["FilasAfectadas"] = $"Se ha actualizado correctamente {filas} registro";
                listado = gestora.listadoCompletoPersonas_BL();
            } catch (Exception e) {
                ViewData["ErrorNoControlado"] = "Ha ocurrido un error en la actualizacion";
            }

            return View("listadoCompleto",listado);
        }

    }
}