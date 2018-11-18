using _07_CRUD_Personas_DAL.Conexion;
using _07_CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_CRUD_Personas_DAL.Manejadoras
{
    public class clsManejadoraDepartamento_DAL
    {

        public clsDepartamento departamentoPorID_DAL(int id)
        {
            clsDepartamento oDepartamento = new clsDepartamento();


            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            clsMyConnection gestConexion = new clsMyConnection();

            try //no obligatorio porque lo controlamos en la clase clsMyConnection
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "SELECT * FROM departamentos WHERE iddepartamento = @id";


                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.SqlDbType = System.Data.SqlDbType.Int;
                param.Value = id;

                miComando.Parameters.Add(param);
                //miComando.Parameters.Add("@id",System.Data.SqlDbType.Int).Value = id;
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();
                //ExecuteScalar devuelve la primera fila (cuando hacemos count se usa)
                //ExecuteNonQuery (update, delete, insert)
                //ExecuteReader (consultas)

                //Comprobar si el lector tiene filas, y en caso afirmativo recorrer
                if (miLector.HasRows)
                {
                    miLector.Read();

                    oDepartamento = new clsDepartamento();
                    oDepartamento.id = (int)miLector["iddepartamento"];
                    oDepartamento.nombre = (string)miLector["nombre_departamento"];
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



            return oDepartamento;


        }

    }
}
