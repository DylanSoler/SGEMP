using ExamenDylan1Ev_DAL.Conexion;
using ExamenDylan1Ev_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDylan1Ev_DAL.Listados
{
    /// <summary>
    /// Clase que contiene funciones que devuelven listados de personajes distintos
    /// </summary>
    public class clsListadosPersonajes_DAL
    {

        /// <summary>
        /// Funcion que devuelve un listado completo de todos los personajes
        /// </summary>
        /// <returns>List de clsPersonaje</returns>
        public List<clsPersonaje> listadoCompletoPersonajes_DAL() {

            List<clsPersonaje> listado = new List<clsPersonaje>();
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            clsPersonaje oPersonaje;
            clsMyConnection gestConexion = new clsMyConnection();

            try
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "SELECT * FROM Personajes";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                //si mi lector tiene filas, recorremos y añadimos al listado cada personaje
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPersonaje = new clsPersonaje();
                        oPersonaje.idPersonaje = (int)miLector["idPersonaje"];
                        oPersonaje.nombre = (string)miLector["nombre"];
                        oPersonaje.alias = (string)miLector["alias"];
                        oPersonaje.vida = (double)miLector["vida"];
                        oPersonaje.regeneracion = (double)miLector["regeneracion"];
                        oPersonaje.danno = (double)miLector["danno"];
                        oPersonaje.armadura = (double)miLector["armadura"];
                        oPersonaje.velAtaque = (double)miLector["velAtaque"];
                        oPersonaje.resistencia = (double)miLector["resistencia"];
                        oPersonaje.velMovimiento = (double)miLector["velMovimiento"];
                        oPersonaje.idCategoria = (int)miLector["idCategoria"];
                        //añadir al listado
                        listado.Add(oPersonaje);
                    }
                }
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            finally
            {
                miLector.Close();
                gestConexion.closeConnection(ref miConexion);
            }


            return listado;
        }

    }
}
