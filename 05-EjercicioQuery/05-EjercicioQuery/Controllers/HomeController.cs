using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _05_EjercicioQuery.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(Boolean esMiPrimeraVez = true) //Boolean? esMiPrimeraVez (posibilidad de ser nulo)
        {
            //if (esMiPrimeraVez.HasValue && (Boolean)esMiPrimeraVez) si es nulleable
            if (esMiPrimeraVez == true)
            {
                ViewData["Frase"] = "Es mi primerita vez";
            }
            else
            {
                ViewData["Frase"] = "NO es mi primera vez";
            }


            return View();
        }
    }
}