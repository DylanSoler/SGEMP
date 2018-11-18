using ExamenDylan1Ev_DAL.Conexion;
using ExamenDylan1Ev_DAL.Listados;
using ExamenDylan1Ev_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDylan1Ev_BL.Listados
{
    /// <summary>
    /// Clase que contiene funciones que llaman a la DAL y devuelven listados de personajes
    /// </summary>
    public class clsListadosPersonajes_BL
    {
        /// <summary>
        /// Funcion que devuelve un listado completo de todos los personajes
        /// </summary>
        /// <returns>List de clsPersonaje</returns>
        public List<clsPersonaje> listadoCompletoPersonajes_BL()
        {
            List<clsPersonaje> listado = new List<clsPersonaje>();
            clsListadosPersonajes_DAL gestora = new clsListadosPersonajes_DAL();

            listado = gestora.listadoCompletoPersonajes_DAL();

            return listado;
        }

    }
}
