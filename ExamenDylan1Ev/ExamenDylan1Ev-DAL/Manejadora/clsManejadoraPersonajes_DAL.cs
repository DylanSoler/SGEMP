using ExamenDylan1Ev_DAL.Conexion;
using ExamenDylan1Ev_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDylan1Ev_DAL.Manejadora
{
    /// <summary>
    /// Clase que contiene funciones sobre los personajes de la base de datos
    /// </summary>
    public class clsManejadoraPersonajes_DAL
    {
        /// <summary>
        /// Apartir de un id dado como parametro, devuelve el personaje de la base de datos asociado a este
        /// </summary>
        /// <param name="id"></param>
        /// <returns>clsPersonaje</returns>
        public clsPersonaje personaje_porID_DAL(int id) {

            clsPersonaje oPersonaje = new clsPersonaje();

            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            clsMyConnection gestConexion = new clsMyConnection();

            try //no obligatorio porque lo controlamos en la clase clsMyConnection
            {
                miConexion = gestConexion.getConnection();

                miComando.CommandText = "SELECT * FROM Personajes WHERE idPersonaje = @id";
                miComando.Parameters.Add("@id",System.Data.SqlDbType.Int).Value = id;
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                //Comprobar si el lector tiene filas, y en caso afirmativo recorrer
                if (miLector.HasRows)
                {
                    miLector.Read();

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

            return oPersonaje;
        }

        /// <summary>
        /// Metodo que hace un update en la base de datos del personaje enviado
        /// </summary>
        /// <param name="oPersonaje"></param>
        /// <returns></returns>
        public int editarPersonaje_DAL(clsPersonaje oPersonaje) {

            int filas = 0;

            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestConexion = new clsMyConnection();

            try //no obligatorio porque lo controlamos en la clase clsMyConnection
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "UPDATE Personajes SET nombre=@nombre, alias=@alias, vida=@vida, regeneracion=@regeneracion, danno=@danno, armadura=@armadura, velAtaque=@velAtaque, resistencia=@resistencia, velMovimiento=@velMovimiento, idCategoria=@idCategoria WHERE idPersonaje=@idPersonaje";

                miComando.Parameters.Add("@idPersonaje", System.Data.SqlDbType.Int).Value = oPersonaje.idPersonaje;
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = oPersonaje.nombre;
                miComando.Parameters.Add("@alias", System.Data.SqlDbType.VarChar).Value = oPersonaje.alias;
                miComando.Parameters.Add("@vida", System.Data.SqlDbType.Float).Value = oPersonaje.vida;
                miComando.Parameters.Add("@regeneracion", System.Data.SqlDbType.Float).Value = oPersonaje.regeneracion;
                miComando.Parameters.Add("@danno", System.Data.SqlDbType.Float).Value = oPersonaje.danno;
                miComando.Parameters.Add("@armadura", System.Data.SqlDbType.Float).Value = oPersonaje.armadura;
                miComando.Parameters.Add("@velAtaque", System.Data.SqlDbType.Float).Value = oPersonaje.velAtaque;
                miComando.Parameters.Add("@resistencia", System.Data.SqlDbType.Float).Value = oPersonaje.resistencia;
                miComando.Parameters.Add("@velMovimiento", System.Data.SqlDbType.Float).Value = oPersonaje.velMovimiento;
                miComando.Parameters.Add("@idCategoria", System.Data.SqlDbType.Int).Value = oPersonaje.idCategoria;

                miComando.Connection = miConexion;
                filas = miComando.ExecuteNonQuery();

            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            finally
            {
                gestConexion.closeConnection(ref miConexion);
            }

            return filas;
        }
    }
}
