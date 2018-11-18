using _07_CRUD_Personas_DAL.Manejadoras;
using _07_CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_CRUD_Personas_BL.Manejadoras
{
    public class clsManejadoraDepartamento_BL
    {

        public clsDepartamento departamentoPorID_BL(int id)
        {

            clsManejadoraDepartamento_DAL manejadora = new clsManejadoraDepartamento_DAL();
            clsDepartamento oDepart = new clsDepartamento();

            oDepart = manejadora.departamentoPorID_DAL(id);

            return oDepart;
        }

    }
}
