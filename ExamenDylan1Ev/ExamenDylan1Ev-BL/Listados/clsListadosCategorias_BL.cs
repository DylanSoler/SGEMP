using ExamenDylan1Ev_DAL.Listados;
using ExamenDylan1Ev_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDylan1Ev_BL.Listados
{
    /// <summary>
    /// Clase que contiene funciones que llaman a la DAL y devuelven listados de categorias
    /// </summary>
    public class clsListadosCategorias_BL
    {
        /// <summary>
        /// Funcion que devuelve un listado completo de todas las categorias
        /// </summary>
        /// <returns>List de clsCategoria</returns>
        public List<clsCategoria> listadoCompletoCategorias_BL()
        {
            List<clsCategoria> listado = new List<clsCategoria>();
            clsListadosCategorias_DAL gestora = new clsListadosCategorias_DAL();

            listado = gestora.listadoCompletoCategorias_DAL();

            return listado;
        }

    }
}
