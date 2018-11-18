using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_MVC_Ejercicio1_PasarDatosAlaVista.Models
{
    public class clsListadoPersonas
    {

        /// <summary>
        /// Funcion que nos devuelve un listado completo de personas
        /// </summary>
        /// <returns></returns>
        public List<clsPersona> listadoCompletoPersonas() {

            List<clsPersona> personas = new List<clsPersona>();

            personas.Add(new clsPersona(1,"Dylan","Soler", new DateTime(1993,4,12),"666666666","calle Sevilla"));
            personas.Add(new clsPersona(1, "Pepe", "Pepon", new DateTime(1991, 6, 1), "666666666", "calle Pepepe"));
            personas.Add(new clsPersona(1, "Paco", "Perez", new DateTime(1993, 4, 12), "666666666", "calle Sevilla"));
            personas.Add(new clsPersona(1, "Jose Fernanda", "Escombro", new DateTime(1993, 4, 12), "666666666", "calle Sevilla"));
            personas.Add(new clsPersona(1, "Manuela", "Muela", new DateTime(1993, 4, 12), "666666666", "calle Sevilla"));


            return personas;
        } 

    }
}