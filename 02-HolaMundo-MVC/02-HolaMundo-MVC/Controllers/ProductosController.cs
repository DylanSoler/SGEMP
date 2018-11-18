using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02_HolaMundo_MVC.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos

        /// <summary>
        /// Accion de mi controlador productos que devuelve la vista Listado
        /// </summary>
        /// <returns></returns>
        public ActionResult Listado()
        {
            return View();
        }

    }
}