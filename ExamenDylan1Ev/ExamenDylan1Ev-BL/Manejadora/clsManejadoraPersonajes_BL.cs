using ExamenDylan1Ev_DAL.Manejadora;
using ExamenDylan1Ev_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDylan1Ev_BL.Manejadora
{
    /// <summary>
    /// Clase que contiene funciones sobre los personajes de la base de datos utilizando la capa DAL
    /// </summary>
    public class clsManejadoraPersonajes_BL
    {
        /// <summary>
        /// Apartir de un id dado como parametro, devuelve el personaje de la base de datos asociado a este
        /// </summary>
        /// <param name="id"></param>
        /// <returns>clsPersonaje</returns>
        public clsPersonaje personaje_porID_BL(int id)
        {
            clsPersonaje oPersonaje = new clsPersonaje();
            clsManejadoraPersonajes_DAL manejadora = new clsManejadoraPersonajes_DAL();

            oPersonaje = manejadora.personaje_porID_DAL(id);

            return oPersonaje;
        }

        /// <summary>
        /// Metodo que hace un update en la base de datos del personaje enviado
        /// </summary>
        /// <param name="oPersonaje"></param>
        /// <returns></returns>
        public int editarPersonaje_BL(clsPersonaje oPersonaje) {

            int filas;
            clsManejadoraPersonajes_DAL manejadora = new clsManejadoraPersonajes_DAL();

            filas = manejadora.editarPersonaje_DAL(oPersonaje);

            return filas;
        }
    }
}
