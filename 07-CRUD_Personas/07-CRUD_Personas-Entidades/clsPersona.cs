using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace _07_CRUD_Personas_Entidades
{
    /// <summary>
    /// Clase persona
    /// </summary>
    public class clsPersona
    {
        #region Constructor por defecto
        public clsPersona() {

        }

        #endregion

        #region Constructor por parametros
        public clsPersona(int idPersona, String nombre, String apellidos, DateTime fechaNacimiento, String direccion, String telefono, int idDepartamento)
        {
            this.idPersona = idPersona;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNacimiento = fechaNacimiento;
            this.telefono = telefono;
            this.direccion = direccion;
            this.idDepartamento = idDepartamento;
        }
        #endregion

        #region propiedadesYatributos

        [HiddenInput(DisplayValue = false)]
        public int idPersona { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(40)]
        public String nombre { get; set; }

        [MaxLength(40), Required]
        public String apellidos { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime fechaNacimiento { get; set; }

        [MaxLength(200)]
        public String direccion { get; set; }

        [RegularExpression(@"[679]{1}[0-9]{8}$", ErrorMessage = "Numero de telefono no valido")]
        public String telefono { get; set; }
        public int idDepartamento { get; set;}

        #endregion

    }
}