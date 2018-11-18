using _07_CRUD_Personas_DAL.Listados;
using _07_CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_CRUD_Personas_BL.Listados
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
