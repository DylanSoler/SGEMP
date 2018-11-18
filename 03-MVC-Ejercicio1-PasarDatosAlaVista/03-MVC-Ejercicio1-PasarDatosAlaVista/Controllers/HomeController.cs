using _03_MVC_Ejercicio1_PasarDatosAlaVista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03_MVC_Ejercicio1_PasarDatosAlaVista.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Action Index HomeController
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //Declaracion de variables
            String saludo;
            clsPersona oPersona = new clsPersona();

            //Llamada a funcion saludo
            //ViewData
            saludo = Saludo();
            ViewData["Saludo"] = saludo;

            //Envio de la fecha acutal en formato largo por el ViewBag
            //ViewBag
            ViewBag.FechaCompleta = DateTime.Now.ToLongDateString();

            //Asignamos propiedades al objeto persona
            //Modelo
            oPersona.idPersona = 1;
            oPersona.nombre = "Fernando";
            oPersona.apellidos = "Galiana";
            oPersona.fechaNacimiento = new DateTime(1980,1,1);
            oPersona.direccion = "Mi calle mi casa teleeeeeefono";
            oPersona.telefono = "955696969";

            //retornamos una vista index enviandole un objeto de la clase persona
            return View(oPersona);
        }

        /// <summary>
        /// Funcion que devuelve un string con un saludo dependiendo de la hora del dia
        /// </summary>
        /// <returns>String asociado al nombre con el saludo</returns>
        String Saludo() {

            String s="";

            if (DateTime.Now.Hour >= 7 && DateTime.Now.Hour <= 13)
                s = "Buenos dias";
            else
                if (DateTime.Now.Hour >= 14 && DateTime.Now.Hour <= 21)
                s = "Buenas tardes";
            else
                s = "Buenas noches";

            return s;
        }

        public ActionResult ListadoPersonas() {

            clsListadoPersonas oListPersonas = new clsListadoPersonas();
            List<clsPersona> oListado = new List<clsPersona>();

            oListado = oListPersonas.listadoCompletoPersonas();

            return View(oListado);
        }
    }
}