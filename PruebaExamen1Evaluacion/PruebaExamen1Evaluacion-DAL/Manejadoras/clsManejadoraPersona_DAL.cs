
using PruebaExamen1Evaluacion_DAL.Conexion;
using PruebaExamen1Evaluacion_Entidades.Entidades;
using PruebaExamen1Evaluacion_Entidades.EntidadesComplejas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaExamen1Evaluacion_DAL.Manejadoras
{
    /// <summary>
    /// Clase que interactua con las personas de la base de datos
    /// </summary>
    public class clsManejadoraPersona_DAL
    {
        /// <summary>
        /// busca una persona por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsPersona personaPorID_DAL(int id)
        {
            clsPersona oPersona = new clsPersona();


            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            clsMyConnection gestConexion = new clsMyConnection();

            try //no obligatorio porque lo controlamos en la clase clsMyConnection
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "SELECT * FROM personas WHERE IDPersona = @id";


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

                    oPersona = new clsPersona();
                    oPersona.idPersona = (int)miLector["IDPersona"];
                    oPersona.nombre = (string)miLector["Nombre"];
                    oPersona.apellidos = (string)miLector["Apellidos"];
                    oPersona.fechaNacimiento = (DateTime)miLector["Fecha_Nacimiento"];
                    oPersona.direccion = (string)miLector["Direccion"];
                    oPersona.telefono = (string)miLector["Telefono"];
                    oPersona.idDepartamento = (int)miLector["IDDepartamento"];

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



            return oPersona;


        }

        public int borrarPersonaPorID_DAL(int id)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            int filas = 0;
            clsMyConnection gestConexion = new clsMyConnection();

            try //no obligatorio porque lo controlamos en la clase clsMyConnection
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "DELETE FROM personas WHERE IDPersona = @id";

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.SqlDbType = System.Data.SqlDbType.Int;
                param.Value = id;
                miComando.Parameters.Add(param);
                                //miComando.Parameters.Add("@id",System.Data.SqlDbType.Int).Value = id;
                miComando.Connection = miConexion;
                filas = miComando.ExecuteNonQuery();
                                //ExecuteScalar devuelve la primera fila (cuando hacemos count se usa)
                                //ExecuteNonQuery (update, delete, insert)
                                //ExecuteReader (consultas)
            } catch (SqlException exSql){
                throw exSql;
            }
            finally{
                gestConexion.closeConnection(ref miConexion);
            }

            return filas;
        }


        public int insertarPersona_DAL(clsPersona oPersona)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            int filas = 0;
            clsMyConnection gestConexion = new clsMyConnection();

            try //no obligatorio porque lo controlamos en la clase clsMyConnection
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "INSERT INTO Personas (Nombre,Apellidos,Fecha_nacimiento,Telefono,Direccion,IDDepartamento) VALUES(@nombre,@apell,@fecha,@tlf,@direccion,@idDepart)";

                miComando.Parameters.Add("@nombre",System.Data.SqlDbType.VarChar).Value = oPersona.nombre;
                miComando.Parameters.Add("@apell", System.Data.SqlDbType.VarChar).Value = oPersona.apellidos;
                miComando.Parameters.Add("@fecha", System.Data.SqlDbType.Date).Value = oPersona.fechaNacimiento;
                miComando.Parameters.Add("@tlf", System.Data.SqlDbType.VarChar).Value = oPersona.telefono;
                miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = oPersona.direccion;
                miComando.Parameters.Add("@idDepart", System.Data.SqlDbType.Int).Value = oPersona.idDepartamento;

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


        public int editarPersona_DAL(clsPersona oPersona)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            int filas = 0;
            clsMyConnection gestConexion = new clsMyConnection();

            try //no obligatorio porque lo controlamos en la clase clsMyConnection
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "UPDATE Personas SET Nombre=@nombre, Apellidos=@apell, Fecha_nacimiento=@fecha, Telefono=@tlf, Direccion=@direccion, IDDepartamento=@idDepart WHERE IDPersona=@id";

                miComando.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = oPersona.idPersona;
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = oPersona.nombre;
                miComando.Parameters.Add("@apell", System.Data.SqlDbType.VarChar).Value = oPersona.apellidos;
                miComando.Parameters.Add("@fecha", System.Data.SqlDbType.Date).Value = oPersona.fechaNacimiento;
                miComando.Parameters.Add("@tlf", System.Data.SqlDbType.VarChar).Value = oPersona.telefono;
                miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = oPersona.direccion;
                miComando.Parameters.Add("@idDepart", System.Data.SqlDbType.Int).Value = oPersona.idDepartamento;

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

        public clsPersonaConNombreDepartamento personaConNombreDepartamentoPorId_DAL(int id)
        {

            clsPersonaConNombreDepartamento oPersonaDepart = null;
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            clsMyConnection gestConexion = new clsMyConnection();

            try //no obligatorio porque lo controlamos en la clase clsMyConnection
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "SELECT P.*, D.Nombre_departamento FROM Personas AS P INNER JOIN DEPARTAMENTOS AS D ON P.IDDepartamento=D.IDDepartamento WHERE IDPersona = @id";
                miComando.Parameters.Add("@id",System.Data.SqlDbType.Int).Value = id;
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();
                //ExecuteScalar devuelve la primera fila (cuando hacemos count se usa)
                //ExecuteNonQuery (update, delete, insert)
                //ExecuteReader (consultas)

                //Comprobar si el lector tiene filas, y en caso afirmativo recorrer
                if (miLector.HasRows)
                {
                    miLector.Read();

                    oPersonaDepart = new clsPersonaConNombreDepartamento();
                    oPersonaDepart.idPersona = (int)miLector["IDPersona"];
                    oPersonaDepart.nombre = (string)miLector["Nombre"];
                    oPersonaDepart.apellidos = (string)miLector["Apellidos"];
                    oPersonaDepart.fechaNacimiento = (DateTime)miLector["Fecha_Nacimiento"];
                    oPersonaDepart.direccion = (string)miLector["Direccion"];
                    oPersonaDepart.telefono = (string)miLector["Telefono"];
                    oPersonaDepart.idDepartamento = (int)miLector["IDDepartamento"];
                    oPersonaDepart.nombreDepartamento = (String)miLector["Nombre_departamento"];
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

            return oPersonaDepart;
        }

    }
}
