
using PruebaExamen1Evaluacion_DAL.Manejadoras;
using PruebaExamen1Evaluacion_Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaExamen1Evaluacion_BL.Manejadoras
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
