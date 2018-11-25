
using _08_ApiRestPersonas_DAL.Listados;
using _08_ApiRestPersonas_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_ApiRestPersonas_BL.Listados
{
    public class clsListadoPersonas_BL
    {
        public List<clsPersona> listadoCompletoPersonas_BL() {

            List<clsPersona> listado = new List<clsPersona>();

            clsListadoPersonas listPersonasDAL = new clsListadoPersonas();

            listado = listPersonasDAL.listadoCompletoPersonas_DAL();

            return listado;
        }
    }
}
