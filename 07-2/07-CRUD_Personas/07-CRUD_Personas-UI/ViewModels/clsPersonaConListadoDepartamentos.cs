using _07_CRUD_Personas_BL.Listados;
using _07_CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _07_CRUD_Personas_UI.ViewModels
{
    public class clsPersonaConListadoDepartamentos:clsPersona
    {
        #region Contructor por defecto
        public clsPersonaConListadoDepartamentos():base() {
            clsListadoDepartamentos_BL listado = new clsListadoDepartamentos_BL();
            this.departamentos = listado.listadoCompletoDepartamentos_BL();
        }

        #endregion


        #region Contructor con parametros
        public clsPersonaConListadoDepartamentos(int idPersona, String nombre, String apellidos, DateTime fechaNacimiento, String direccion, String telefono, int idDepartamento, List<clsDepartamento> listado): base( idPersona,  nombre,  apellidos,  fechaNacimiento,  direccion,  telefono,  idDepartamento)
        {
            this.departamentos = listado;
            clsListadoDepartamentos_BL listDepar = new clsListadoDepartamentos_BL();
            this.departamentos = listDepar.listadoCompletoDepartamentos_BL();
        }
        #endregion

        #region Propiedades
        public List<clsDepartamento> departamentos { get; set; }
        #endregion


    }
}