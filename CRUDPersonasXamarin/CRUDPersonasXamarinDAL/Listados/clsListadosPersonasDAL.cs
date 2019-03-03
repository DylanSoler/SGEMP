﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using CRUDPersonasXamarinEntidades;
using CRUDPersonasXamarinDAL.Conexion;

namespace CRUDPersonasXamarinDAL.Listados
{
    public class clsListadosPersonasDAL
    {

        /// <summary>
        /// Metodo que devuelve el listado completo de personas
        /// </summary>
        /// <returns>List de clsPersona</returns>
        public async Task<List<clsPersona>> listadoCompletoPersonasDAL()
        {
            clsUriBase uribase = new clsUriBase();
            String ruta = uribase.getUriBaseApi();

            List<clsPersona> listado = new List<clsPersona>();

            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(ruta);

            //try catch, throw ex 
            HttpResponseMessage response = await client.GetAsync($"{ruta}/Personas");

            if (response.IsSuccessStatusCode)
            {
                //                   client.GetStringAsync(miUri)
                string lista = await response.Content.ReadAsStringAsync();
                listado = JsonConvert.DeserializeObject<List<clsPersona>>(lista);

            }
            else
            {
                //TODO
            }

            return listado;
        }

    }
}
