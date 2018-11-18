using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _04_MVC_Ejercicio1_PasarDatosAControlador.Models.ViewModels
{
    public class clsPersonaConListadoDepartamentos:clsPersona
    {
        #region Contructor por defecto
        public clsPersonaConListadoDepartamentos():base() {
            clsListadoDepartamentos listadoDep = new clsListadoDepartamentos();
            this.departamentos = listadoDep.listadoCompletoDepartamentos();
        }

        #endregion


        #region Contructor con parametros
        public clsPersonaConListadoDepartamentos(int idPersona, String nombre, String apellidos, DateTime fechaNacimiento, String direccion, String telefono, int idDepartamento, List<clsDepartamento> listado): base( idPersona,  nombre,  apellidos,  fechaNacimiento,  direccion,  telefono,  idDepartamento)
        {
            this.departamentos = listado;
            clsListadoDepartamentos listadoDep = new clsListadoDepartamentos();
            departamentos = listadoDep.listadoCompletoDepartamentos();
        }
        #endregion

        #region Propiedades
        public List<clsDepartamento> departamentos { get; set; }
        #endregion


    }
}