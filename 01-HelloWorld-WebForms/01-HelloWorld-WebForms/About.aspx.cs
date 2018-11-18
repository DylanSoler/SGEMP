using _01_HelloWorld_WebForms.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_HelloWorld_WebForms
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSaludar_Click(object sender, EventArgs e)
        {
            String nombre = "";

            nombre = txtNombre.Text;
            //nombre = Request.Form["txtNombre"];name en codigo fuente html(pierdo el control del html)
            //debido a que cambia el nombre
            lblResultado.Text = $"Hola {nombre}";
        }

        protected void btnPersona_Click(object sender, EventArgs e)
        {
            clsPersona oPersona = new clsPersona();

            oPersona.Nombre = "Dylan";
            oPersona.Apellidos = "Soler";

            lblResultado.Text = $"Soy el objeto: {oPersona.Nombre} {oPersona.Apellidos}";
        }
    }
}