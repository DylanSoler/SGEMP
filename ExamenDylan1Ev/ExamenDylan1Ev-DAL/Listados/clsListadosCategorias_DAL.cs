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
    /// Clase que contiene funciones que devuelven listados de categorias
    /// </summary>
    public class clsListadosCategorias_DAL
    {
        /// <summary>
        /// Funcion que devuelve un listado completo de todos las categorias
        /// </summary>
        /// <returns>List de clsCategoria</returns>
        public List<clsCategoria> listadoCompletoCategorias_DAL()
        {

            List<clsCategoria> listado = new List<clsCategoria>();
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            clsCategoria oCategoria;
            clsMyConnection gestConexion = new clsMyConnection();

            try
            {
                miConexion = gestConexion.getConnection();
                miComando.CommandText = "SELECT * FROM Categorias";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                //si mi lector tiene filas, recorremos y añadimos al listado cada categoria
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oCategoria = new clsCategoria();
                        oCategoria.idCategoria = (int)miLector["idCategoria"];
                        oCategoria.nombreCategoria = (string)miLector["nombreCategoria"];
                        //añadir al listado
                        listado.Add(oCategoria);
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
