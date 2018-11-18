
using PruebaExamen1Evaluacion_DAL.Listados;
using PruebaExamen1Evaluacion_Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaExamen1Evaluacion_BL.Listados
{
    public class clsListadoPersonas_BL
    {
        public List<clsPersona> listadoCompletoPersonas_BL()
        {

            List<clsPersona> listado = new List<clsPersona>();

            clsListadoPersonas listPersonasDAL = new clsListadoPersonas();

            listado = listPersonasDAL.listadoCompletoPersonas_DAL();

            return listado;
        }


        public List<clsPersona> listadoPersonasPorDeparamento_BL(int idDepartamento)
        {
            List<clsPersona> listado = new List<clsPersona>();

            clsListadoPersonas listPersonasDAL = new clsListadoPersonas();

            listado = listPersonasDAL.listadoPersonasPorDeparamento_DAL(idDepartamento);

            return listado;
        }
    }
}
