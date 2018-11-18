using PruebaExamen1Evaluacion_BL.Listados;
using PruebaExamen1Evaluacion_Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaExamen1Evaluacion_UI.Models.ViewModels
{
    /// <summary>
    /// viewmodel con listado departamentos, listado personas por departamento, departamento seleccionado
    /// </summary>
    public class clsListadoDepartamentosMasListadoPersonas
    {
        #region Propiedades privadas
        private List<clsDepartamento> _listadoDepartamentos;
        private List<clsPersona> _listadoPersonasPorDepart;
        private int _idDepartamentoSeleccionado;
        #endregion

        #region Propiedades publicas
        public List<clsDepartamento> listadoDepartamentos
        {

            get { return _listadoDepartamentos; }

            set { _listadoDepartamentos = value; }
        }

        public List<clsPersona> listadoPersonasPorDepart
        {

            get { return _listadoPersonasPorDepart; }

            set { _listadoPersonasPorDepart = value; }
        }

        public int idDepartamentoSeleccionado
        {
            get { return _idDepartamentoSeleccionado; }

            set { _idDepartamentoSeleccionado = value; }
        }
        #endregion

        #region Contructor por defecto
        public clsListadoDepartamentosMasListadoPersonas()
        {
            clsListadoDepartamentos_BL gestoraListados = new clsListadoDepartamentos_BL();
            //dejamos el listado de personas vacio y rellenamos el de departamentos
            _listadoPersonasPorDepart = new List<clsPersona>();
            _listadoDepartamentos = gestoraListados.listadoCompletoDepartamentos_BL();


        }

        #endregion

    }
}