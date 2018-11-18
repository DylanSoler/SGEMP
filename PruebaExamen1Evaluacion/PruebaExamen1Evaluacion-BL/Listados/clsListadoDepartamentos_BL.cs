
using PruebaExamen1Evaluacion_DAL.Listados;
using PruebaExamen1Evaluacion_Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaExamen1Evaluacion_BL.Listados
{
    public class clsListadoDepartamentos_BL
    {
        public List<clsDepartamento> listadoCompletoDepartamentos_BL()
        {

            List<clsDepartamento> listado = new List<clsDepartamento>();

            clsListadoDepartamentos listDeparDAL = new clsListadoDepartamentos();

            listado = listDeparDAL.listadoCompletoDepartamentos_DAL();

            return listado;
        }
    }
}
