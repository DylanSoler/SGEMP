using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _04_MVC_Ejercicio1_PasarDatosAControlador.Models.ViewModels
{
    public class clsPersonaConNombreDepartamento:clsPersona
    {
        #region Contructor por defecto
        public clsPersonaConNombreDepartamento() : base() {
            this.nombreDepartamento = " ";
        }
        #endregion

        #region Contructor con parametros
        public clsPersonaConNombreDepartamento(int idPersona, String nombre, String apellidos, DateTime fechaNacimiento, String direccion, String telefono, int idDepartamento, String nombreDepartamento):base(idPersona, nombre, apellidos, fechaNacimiento, direccion, telefono, idDepartamento)
        {
            this.nombreDepartamento = nombreDepartamento;
        }
        #endregion


        #region Propiedades
        public String nombreDepartamento { get; set; }
        #endregion

    }
}