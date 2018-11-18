using PruebaExamen1Evaluacion_BL.Listados;
using PruebaExamen1Evaluacion_BL.Manejadoras;
using PruebaExamen1Evaluacion_Entidades.Entidades;
using PruebaExamen1Evaluacion_Entidades.EntidadesComplejas;
using PruebaExamen1Evaluacion_UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaExamen1Evaluacion_UI.Controllers
{
    /// <summary>
    /// Controller Personas
    /// </summary>
    public class PersonasController : Controller
    {

        /// <summary>
        /// Action Index, recibe como parametro nullable un id y envia a la vista un objeto como model clsListadoDepartamentosMasListadoPersonas 
        /// con un listado de departamentos a seleccionar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Index(int? id)
        {
            clsListadoDepartamentosMasListadoPersonas oListados = new clsListadoDepartamentosMasListadoPersonas();
            clsListadoPersonas_BL gestoraListado;

            if (id != null) {

                gestoraListado = new clsListadoPersonas_BL();
                oListados.idDepartamentoSeleccionado = (int) id; 
                try{
                    oListados.listadoPersonasPorDepart = gestoraListado.listadoPersonasPorDeparamento_BL((int)id);
                } catch (Exception) {
                    //TODO
                }
            }
                return View(oListados);
        }

        /// <summary>
        /// Action de Index tras submit con el departamento seleccionado, rellena el listado de personas segun el departamento seleccionado y
        /// lo manda a la vista
        /// </summary>
        /// <param name="oListadoPersonasPorDepart"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(clsListadoDepartamentosMasListadoPersonas oListadoPersonasPorDepart)
        {

            clsListadoPersonas_BL gestoraListado = new clsListadoPersonas_BL();

            try
            {
                oListadoPersonasPorDepart.listadoPersonasPorDepart = gestoraListado.listadoPersonasPorDeparamento_BL(oListadoPersonasPorDepart.idDepartamentoSeleccionado);
            }
            catch (Exception)
            {
                //TODO
            }

            return View(oListadoPersonasPorDepart);
        }

        /// <summary>
        /// Action para editar el telefono de una persona, recibe el id de la persona, y la manda a la vista
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {

            clsPersonaConNombreDepartamento oPersonaConDepart = null;
            clsManejadoraPersona_BL manejadora = new clsManejadoraPersona_BL();

            try
            {
                oPersonaConDepart = manejadora.personaConNombreDepartamentoPorId_BL(id);
            }
            catch (Exception)
            {
                //TODO
            }

            return View(oPersonaConDepart);
        }

        /// <summary>
        /// Action tras submit de Edit, recibe la persona con los datos modificados, la actualiza, y envia un mensaje de confirmacion si todo
        /// ha ido bien
        /// </summary>
        /// <param name="opersonaConNombreDepart"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(clsPersonaConNombreDepartamento opersonaConNombreDepart)
        {
            clsManejadoraPersona_BL manejadora = new clsManejadoraPersona_BL();
            clsPersona oPersona = new clsPersona();

            oPersona.idPersona = opersonaConNombreDepart.idPersona;
            oPersona.nombre = opersonaConNombreDepart.nombre;
            oPersona.apellidos = opersonaConNombreDepart.apellidos;
            oPersona.fechaNacimiento = opersonaConNombreDepart.fechaNacimiento;
            oPersona.direccion = opersonaConNombreDepart.direccion;
            oPersona.telefono = opersonaConNombreDepart.telefono;
            oPersona.idDepartamento = opersonaConNombreDepart.idDepartamento;

            int filas;

            try {
                filas = manejadora.editarPersona_BL(oPersona);

                if (filas != 0) {
                    ViewData["guardado"] = "GuardadoCorrectamente";
                }
            } catch (Exception) {
                //TODO
            }

            return View(opersonaConNombreDepart);
        }
    }
}