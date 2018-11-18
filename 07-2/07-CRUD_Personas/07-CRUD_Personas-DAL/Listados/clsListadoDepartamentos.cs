using _07_CRUD_Personas_DAL.Conexion;
using _07_CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_CRUD_Personas_DAL.Listados
{
    public class clsListadoDepartamentos
    {

        /// <summary>
        /// Función que devuelve el listado completo de departamentos, vacia si no hay datos o si ha habido un error
        /// </summary>
        /// <returns>List de clsDepartamento</returns>
        public List<clsDepartamento> listadoCompletoDepartamentos_DAL()
        {

            List<clsDepartamento> lista = new List<clsDepartamento>();

            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            clsDepartamento oDepartamento;
            clsMyConnection gestConexion = new clsMyConnection();

            try //no obligatorio porque lo controlamos en la clase clsMyConnection
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "SELECT * FROM departamentos";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();
                //ExecuteScalar devuelve la primera fila (cuando hacemos count se usa)
                //ExecuteNonQuery (update, delete, insert)
                //ExecuteReader (consultas)

                //Comprobar si el lector tiene filas, y en caso afirmativo recorrer
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oDepartamento = new clsDepartamento();
                        oDepartamento.id = (int)miLector["iddepartamento"];
                        oDepartamento.nombre = (String)miLector["nombre_departamento"];
                        lista.Add(oDepartamento);
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


            return lista;
        }
    }

}

