using ExamenDylan1Ev_BL.Listados;
using ExamenDylan1Ev_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenDylan1Ev_UI.Models.ViewModels
{
    /// <summary>
    /// Clase viewmodel para la vista principal Index
    /// </summary>
    public class clsViewModel
    {
        #region Propiedades
        public List<clsPersonaje> listadoPersonajes { get; set; }
        public clsPersonaje personajeSeleccionado { get; set; }
        public List<clsCategoria> listadoCategorias { get; set; }
        public int idPersonajeSeleccionado { get; set; }
        #endregion

        #region Contructor por defecto
        public clsViewModel() {
            personajeSeleccionado = new clsPersonaje();
            clsListadosPersonajes_BL gestoraPer = new clsListadosPersonajes_BL();
            clsListadosCategorias_BL gestoraCat = new clsListadosCategorias_BL();
            //rellenamos el listado de personajes y el de categorias
            listadoPersonajes = gestoraPer.listadoCompletoPersonajes_BL();
            listadoCategorias = gestoraCat.listadoCompletoCategorias_BL();
        }
        #endregion
    }
}