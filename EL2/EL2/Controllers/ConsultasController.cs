using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EL2.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EL2.Controllers
{
    public class ConsultasController : Controller
    {
        SqlConnection cn =
           new SqlConnection(ConfigurationManager.ConnectionStrings["CNX"].ConnectionString);

        //Metodo de acceso a datos
        List<Viaje> BuscarViajesXAño(DateTime fecha)
        {
            
            List<Viaje> resultado = new List<Viaje>();
            SqlCommand cmd = new SqlCommand("SP_VIAJES_X_AÑO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FechaPartida", fecha);

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Viaje v = new Viaje();
                v.idViaje = dr.GetInt32(0);
                v.Origen = dr.GetInt32(1);
                v.Destino = dr.GetInt32(2);
                v.VehiculoId = dr.GetInt32(3);
                v.ConductorId = dr.GetInt32(4);
                v.FechaPar = dr.GetDateTime(5);
                v.FechaLlega = dr.GetDateTime(6);
                resultado.Add(v);

            }
            dr.Close();
            cn.Close();
            return resultado;

        }


        public ActionResult BuscarViajesPorAño(DateTime fecha)
        {
            List<Viaje> lista = new List<Viaje>();
                lista = BuscarViajesXAño(fecha);
            return View(lista);

        }



        List<Conductor> BuscarViajesXConductor(string Nombre)
        {

            List<Conductor> resultado = new List<Conductor>();
            SqlCommand cmd = new SqlCommand("SP_LISTA_NOMBRE_CONDUCTOR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", Nombre);

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Conductor c = new Conductor();
                c.idConductor = dr.GetInt32(0);
                c.DNI = dr.GetString(1);
                c.Nombre = dr.GetString(2);
                c.ApellidoPaterno = dr.GetString(3);
                c.ApellidoMaterno = dr.GetString(4);
                c.Brevete = dr.GetString(5);
                c.Telefono = dr.GetString(6);
                c.Estado = dr.GetInt32(7);
                c.idTipoDocumento = dr.GetInt32(8);

                resultado.Add(c);



            }
            dr.Close();
            cn.Close();
            return resultado;

        }


        public ActionResult BuscarViajesPorConductor(string con= null)
        {
            List<Conductor> lista = new List<Conductor>();
            if(!string.IsNullOrEmpty(con))
            lista = BuscarViajesXConductor(con);
            return View(lista);

        }





    }
}