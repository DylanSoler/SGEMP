using PruebaExamen1Evaluacion_Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaExamen1Evaluacion_Entidades.EntidadesComplejas
{
    /// <summary>
    /// clase que hereda de persona y se le añade el nombre de su departamento
    /// </summary>
    public class clsPersonaConNombreDepartamento:clsPersona
    {
        #region Propiedades
        public String nombreDepartamento { get; set; }
        #endregion

    }
}
