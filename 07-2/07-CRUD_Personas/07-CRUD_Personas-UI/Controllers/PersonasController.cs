using _07_CRUD_Personas_BL.Listados;
using _07_CRUD_Personas_BL.Manejadoras;
using _07_CRUD_Personas_DAL.Manejadoras;
using _07_CRUD_Personas_Entidades;
using _07_CRUD_Personas_UI.ViewModels;
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
            clsManejadoraDepartamento_BL manejadora = new clsManejadoraDepartamento_BL();

            List<clsPersona> listado = new List<clsPersona>();
            List<clsPersonaConNombreDepartamento> listConDepart = new List<clsPersonaConNombreDepartamento>();

            clsPersonaConNombreDepartamento oPconNombreDepart = new clsPersonaConNombreDepartamento();

            try
            {
                listado = gestora.listadoCompletoPersonas_BL();
                foreach (clsPersona oP in listado)
                {
                    oPconNombreDepart = new clsPersonaConNombreDepartamento();
                    oPconNombreDepart.idPersona = oP.idPersona;
                    oPconNombreDepart.nombre = oP.nombre;
                    oPconNombreDepart.apellidos = oP.apellidos;
                    oPconNombreDepart.fechaNacimiento = oP.fechaNacimiento;
                    oPconNombreDepart.direccion = oP.direccion;
                    oPconNombreDepart.telefono = oP.telefono;
                    oPconNombreDepart.idDepartamento = oP.idDepartamento;
                    oPconNombreDepart.nombreDepartamento = manejadora.departamentoPorID_BL(oP.idDepartamento).nombre;
                    listConDepart.Add(oPconNombreDepart);
                }
            }
            catch(Exception e) {

                ViewData["ErrorNoControlado"] = "Ha ocurrido un error";
            }

            return View(listConDepart);
        }

        public ActionResult Delete(int id) {

            clsPersona oPersona = new clsPersona();
            clsPersonaConNombreDepartamento oPconNombreDepartamento = new clsPersonaConNombreDepartamento();
            clsManejadoraPersona_BL manejadoraP = new clsManejadoraPersona_BL();
            clsManejadoraDepartamento_BL manejadoraD = new clsManejadoraDepartamento_BL();

            oPersona = manejadoraP.personaPorID_BL(id);

            oPconNombreDepartamento.idPersona = oPersona.idPersona;
            oPconNombreDepartamento.nombre = oPersona.nombre;
            oPconNombreDepartamento.apellidos = oPersona.apellidos;
            oPconNombreDepartamento.fechaNacimiento = oPersona.fechaNacimiento;
            oPconNombreDepartamento.direccion = oPersona.direccion;
            oPconNombreDepartamento.telefono = oPersona.telefono;
            oPconNombreDepartamento.idDepartamento = oPersona.idDepartamento;
            oPconNombreDepartamento.nombreDepartamento = manejadoraD.departamentoPorID_BL(oPersona.idDepartamento).nombre;


            return View(oPconNombreDepartamento);
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

            clsManejadoraPersona_BL manejadoraP = new clsManejadoraPersona_BL();
            clsManejadoraDepartamento_BL manejadoraD = new clsManejadoraDepartamento_BL();

            clsListadoPersonas_BL gestora = new clsListadoPersonas_BL();
            List<clsPersona> listado = new List<clsPersona>();
            List<clsPersonaConNombreDepartamento> listConDepart = new List<clsPersonaConNombreDepartamento>();
            clsPersonaConNombreDepartamento oPconNombreDepart = new clsPersonaConNombreDepartamento();

            try
            {
                filas = manejadoraP.borrarPersonaPorID_BL(id);
                ViewData["FilasAfectadas"] = $"Se ha borrado correctamente {filas} registro";
                listado = gestora.listadoCompletoPersonas_BL();
                foreach (clsPersona oP in listado)
                {
                    oPconNombreDepart = new clsPersonaConNombreDepartamento();
                    oPconNombreDepart.idPersona = oP.idPersona;
                    oPconNombreDepart.nombre = oP.nombre;
                    oPconNombreDepart.apellidos = oP.apellidos;
                    oPconNombreDepart.fechaNacimiento = oP.fechaNacimiento;
                    oPconNombreDepart.direccion = oP.direccion;
                    oPconNombreDepart.telefono = oP.telefono;
                    oPconNombreDepart.idDepartamento = oP.idDepartamento;
                    oPconNombreDepart.nombreDepartamento = manejadoraD.departamentoPorID_BL(oP.idDepartamento).nombre;
                    listConDepart.Add(oPconNombreDepart);
                }
            }
            catch (Exception e) {

                ViewData["ErrorNoControlado"] = "Ha ocurrido un error borrando";
            }

            return View("listadoCompleto", listConDepart);
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
            clsPersonaConNombreDepartamento oPconNombreDepartamento = new clsPersonaConNombreDepartamento();
            clsManejadoraPersona_BL manejadoraP = new clsManejadoraPersona_BL();
            clsManejadoraDepartamento_BL manejadoraD = new clsManejadoraDepartamento_BL();

            oPersona = manejadoraP.personaPorID_BL(id);

            oPconNombreDepartamento.idPersona = oPersona.idPersona;
            oPconNombreDepartamento.nombre = oPersona.nombre;
            oPconNombreDepartamento.apellidos = oPersona.apellidos;
            oPconNombreDepartamento.fechaNacimiento = oPersona.fechaNacimiento;
            oPconNombreDepartamento.direccion = oPersona.direccion;
            oPconNombreDepartamento.telefono = oPersona.telefono;
            oPconNombreDepartamento.idDepartamento = oPersona.idDepartamento;
            oPconNombreDepartamento.nombreDepartamento = manejadoraD.departamentoPorID_BL(oPersona.idDepartamento).nombre;


            return View(oPconNombreDepartamento);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id) {

            clsPersona oPersona = new clsPersona();
            clsPersonaConListadoDepartamentos oPconListDepartamento = new clsPersonaConListadoDepartamentos();
            clsManejadoraPersona_BL manejadoraP = new clsManejadoraPersona_BL();
            clsManejadoraDepartamento_BL manejadoraD = new clsManejadoraDepartamento_BL();

            oPersona = manejadoraP.personaPorID_BL(id);

            oPconListDepartamento.idPersona = oPersona.idPersona;
            oPconListDepartamento.nombre = oPersona.nombre;
            oPconListDepartamento.apellidos = oPersona.apellidos;
            oPconListDepartamento.fechaNacimiento = oPersona.fechaNacimiento;
            oPconListDepartamento.direccion = oPersona.direccion;
            oPconListDepartamento.telefono = oPersona.telefono;
            oPconListDepartamento.idDepartamento = oPersona.idDepartamento;

            return View(oPconListDepartamento);
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