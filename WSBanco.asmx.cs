using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WSBanco
{
    /// <summary>
    /// Descripción breve de WSBanco
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSBanco : System.Web.Services.WebService
    {

        [WebMethod]
        public double  getCotizacion(string Fecha)
        {
            string sConnectionString;
            sConnectionString = "server=localhost;uid=root;pwd=;database=wsbanco";
            MySqlConnection objConn = new MySqlConnection(sConnectionString);
            objConn.Open();
            double cotizacion = 0;
            string consulta = "select * from cotizacion where fecha ='"+Fecha+"'";
            MySqlCommand myCmd = new MySqlCommand();
            myCmd.Connection = objConn;
            myCmd.CommandText = consulta;
            MySqlDataReader myReader = myCmd.ExecuteReader();
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    myReader.Read();
                    cotizacion = Convert.ToDouble(myReader["cotizacion"]);

                }
            }
            return cotizacion;

        }

        [WebMethod]
        public Boolean setCotizacion(string Fecha,double Valor)
        {
            try
            {
                string sConnectionString;
                sConnectionString = "server=localhost;uid=root;pwd=;database=wsbanco";
                MySqlConnection objConn = new MySqlConnection(sConnectionString);
                objConn.Open();
                string consulta = "insert into cotizacion (fecha,valor) values ('" + Fecha + "','" + Valor + "')";
                MySqlCommand myCmd = new MySqlCommand();
                myCmd.Connection = objConn;
                myCmd.CommandText = consulta;
                myCmd.ExecuteReader();
                return true;
            }
            catch {
                return false;
            }
            

        }
    }
}
