
using PruebaExamen1Evaluacion_DAL.Manejadoras;
using PruebaExamen1Evaluacion_Entidades.Entidades;
using PruebaExamen1Evaluacion_Entidades.EntidadesComplejas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaExamen1Evaluacion_BL.Manejadoras
{
    public class clsManejadoraPersona_BL
    {
        public clsPersona personaPorID_BL(int id)
        {

            clsManejadoraPersona_DAL manejadora = new clsManejadoraPersona_DAL();
            clsPersona oPersona = new clsPersona();

            oPersona = manejadora.personaPorID_DAL(id);

            return oPersona;
        }

        public int borrarPersonaPorID_BL(int id)
        {
            int filas;
            clsManejadoraPersona_DAL manejadora = new clsManejadoraPersona_DAL();

            filas = manejadora.borrarPersonaPorID_DAL(id);

            return filas;
        }

        public int insertarPersona_BL(clsPersona oPersona)
        {
            int filas;
            clsManejadoraPersona_DAL manejadora = new clsManejadoraPersona_DAL();

            filas = manejadora.insertarPersona_DAL(oPersona);

            return filas;
        }

        public int editarPersona_BL(clsPersona oPersona)
        {
            int filas;
            clsManejadoraPersona_DAL manejadora = new clsManejadoraPersona_DAL();

            filas = manejadora.editarPersona_DAL(oPersona);

            return filas;
        }

        public clsPersonaConNombreDepartamento personaConNombreDepartamentoPorId_BL(int id) {

            clsPersonaConNombreDepartamento oPersonaConNombreDepart;
            clsManejadoraPersona_DAL manejadora = new clsManejadoraPersona_DAL();

            oPersonaConNombreDepart = manejadora.personaConNombreDepartamentoPorId_DAL(id);

            return oPersonaConNombreDepart;
        }

    }
}

