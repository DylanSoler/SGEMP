using _08_ApiRestPersonas_BL.Listados;
using _08_ApiRestPersonas_BL.Manejadoras;
using _08_ApiRestPersonas_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _08_ApiRestPersonas_API.Controllers
{
    public class PersonasController : ApiController
    {

        /// <summary>
        /// Verbo get para peticiones de un listado completo de personas
        /// </summary>
        /// <returns>List de personas completo</returns>
        public List<clsPersona> Get()
        {
            clsListadoPersonas_BL oListado = new clsListadoPersonas_BL();
            return oListado.listadoCompletoPersonas_BL();
        }

        /// <summary>
        /// Verbo get para peticiones de una sola persona segun id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>clsPersona de un id</returns>
        public clsPersona Get(int id)
        {
            clsManejadoraPersona_BL manejadora = new clsManejadoraPersona_BL();
            return manejadora.personaPorID_BL(id);
        }


        /// <summary>
        /// Verbo delete para peticiones de borrar una persona por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>int con el numero de filas afectadas</returns>
        public int Delete(int id)
        {
            clsManejadoraPersona_BL manejadora = new clsManejadoraPersona_BL();
            int filas = manejadora.borrarPersonaPorID_BL(id);
            return filas;
        }


        /// <summary>
        /// Verbo Put para peticiones de ACTUALIZAR una persona
        /// </summary>
        /// <param name="oPersona"></param>
        /// <returns>int con el numero de filas afectadas</returns>
        public int Put(clsPersona oPersona) {

            clsManejadoraPersona_BL manejadora = new clsManejadoraPersona_BL();
            int filas = manejadora.editarPersona_BL(oPersona);

            return filas;
        }


        /// <summary>
        /// Verbo Post para peticiones de insertar una persona 
        /// </summary>
        /// <param name="oPersona"></param>
        /// <returns>int con el numero de filas afectadas</returns>
        public int Post([FromBody]clsPersona oPersona)
        {

            clsManejadoraPersona_BL manejadora = new clsManejadoraPersona_BL();
            int filas = manejadora.insertarPersona_BL(oPersona);

            return filas;
        }

    }
}
