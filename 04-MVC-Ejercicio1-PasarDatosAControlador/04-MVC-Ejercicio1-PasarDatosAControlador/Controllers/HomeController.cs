using _04_MVC_Ejercicio1_PasarDatosAControlador.Models;
using _04_MVC_Ejercicio1_PasarDatosAControlador.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _04_MVC_Ejercicio1_PasarDatosAControlador.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Editar()
        {

            clsListadoDepartamentos listDepartamentos = new clsListadoDepartamentos();
            
            //Creamos el objeto de clsPersonaConListadoDepartamentos y asignamos propiedades
            clsPersonaConListadoDepartamentos oPersonaListado = new clsPersonaConListadoDepartamentos();
            oPersonaListado.idPersona = 1;
            oPersonaListado.nombre = "Fernando";
            oPersonaListado.apellidos = "Galiana";
            oPersonaListado.fechaNacimiento = new DateTime(1980, 1, 1);
            oPersonaListado.direccion = "Calle cualquiera";
            oPersonaListado.telefono = "955696969";
            oPersonaListado.idDepartamento = 4;

            //retornamos una vista enviandole el objeto creado
            return View(oPersonaListado);
        }


        /// <summary>
        /// Envio del usuario mediante submit con los datos modificados
        /// </summary>
        /// <param name="oPersonaListado"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Editar(clsPersonaConListadoDepartamentos oPersonaListado)
        {
            //Creamos el objeto de clsPersonaConNombreDepartamento y asignamos propiedades a partir de oPersonaListado
            clsPersonaConNombreDepartamento oPersonaDep = new clsPersonaConNombreDepartamento();

            oPersonaDep.idPersona = oPersonaListado.idPersona;
            oPersonaDep.nombre = oPersonaListado.nombre;
            oPersonaDep.apellidos = oPersonaListado.apellidos;
            oPersonaDep.fechaNacimiento = oPersonaListado.fechaNacimiento;
            oPersonaDep.direccion = oPersonaListado.direccion;
            oPersonaDep.telefono = oPersonaListado.telefono;
            oPersonaDep.idDepartamento = oPersonaListado.idDepartamento;
            oPersonaDep.nombreDepartamento = oPersonaListado.departamentos[oPersonaListado.idDepartamento - 1].nombre;

            //retornamos la vista PersonaModificada enviandole el objeto creado
            return View("PersonaModificada", oPersonaDep);
        }
    }
}