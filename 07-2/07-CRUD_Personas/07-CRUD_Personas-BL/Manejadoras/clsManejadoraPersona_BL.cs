using _07_CRUD_Personas_DAL.Manejadoras;
using _07_CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_CRUD_Personas_BL.Manejadoras
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



    }
}

