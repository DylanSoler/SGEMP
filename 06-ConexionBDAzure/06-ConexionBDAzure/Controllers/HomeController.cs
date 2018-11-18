using _06_ConexionBDAzure.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _06_ConexionBDAzure.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost,ActionName ("Index")]
        public ActionResult IndexPost()
        {
            SqlConnection miConexion = new SqlConnection();

            try{

                miConexion.ConnectionString = "server=serverpersonasdasp.database.windows.net;database=personasDB;uid=Prueba;pwd=123qwerty.;";
                miConexion.Open();
                ViewData["Estado"] = miConexion.State;

            } catch (SqlException){

                ViewData["Estado"] = "Ha ocurrido un error al intentar conectarte con la base de datos"; 
                //para nosotros e.Message; (SqlException e)
            }
            finally {

                miConexion.Close();
            }

            return View();

        }

        public ActionResult listadoPersonas() {

            SqlConnection miConexion = new SqlConnection();
            miConexion.ConnectionString = "server=serverpersonasdasp.database.windows.net;database=personasDB;uid=dasoler;pwd=redesdylan.29;";

            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            List<clsPersona> listadoPersonas = new List<clsPersona>();
            clsPersona oPersona;

            try
            {
                miConexion.Open();
                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos)
                miComando.CommandText = "SELECT * FROM personas";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();
                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPersona = new clsPersona();
                        oPersona.idPersona = (int)miLector["IDPersona"];
                        oPersona.nombre = (string)miLector["Nombre"];
                        oPersona.apellidos = (string)miLector["Apellidos"];
                        oPersona.fechaNacimiento = (DateTime)miLector["Fecha_nacimiento"];
                        oPersona.direccion = (string)miLector["Direccion"];
                        oPersona.telefono = (string)miLector["Telefono"];
                        oPersona.idDepartamento = (int)miLector["IDDepartamento"];
                        listadoPersonas.Add(oPersona);
                    }
                }
                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }


            return View(listadoPersonas);
        }
    }
}