using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using EL2.Models;

namespace EL2.ADO
{
    
    public class VehiculoADO
    {
        SqlConnection cn =
            new SqlConnection(ConfigurationManager.ConnectionStrings["CNX"].ConnectionString);

        public int Insertar(Vehiculo v)
        {
            int resultado = -1;

            SqlCommand cmd = new SqlCommand("SP_VEHICULO_INSERTAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@placa", v.Placa);
            cmd.Parameters.AddWithValue("@año", v.Año);
            cmd.Parameters.AddWithValue("@modelo", v.Modelo);
            cmd.Parameters.AddWithValue("@idmarca", v.idMarca);

            cn.Open();
            resultado = cmd.ExecuteNonQuery();
            cn.Close();
            return resultado;
        }

        public List<Vehiculo> Listar()
        {
            List<Vehiculo> lista = new List<Vehiculo>();
            SqlCommand cmd = new SqlCommand("SP_VEHICULO_LISTAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Vehiculo()
                {
                    idVehiculo = dr.GetInt32(0),
                    Placa = dr.GetString(1),
                    Año = dr.GetInt32(2),
                    Modelo = dr.GetString(3),
                    idMarca = dr.GetInt32(4),
                    Marca = dr.GetString(5)
                });
            }
            dr.Close();
            cn.Close();
            return lista;
        }
        public int Actualizar(Vehiculo v)
        {
            int resultado = -1;
            SqlCommand cmd = new SqlCommand("SP_VEHICULO_ACTUALIZAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@placa", v.Placa);
            cmd.Parameters.AddWithValue("@año", v.Año);
            cmd.Parameters.AddWithValue("@modelo", v.Modelo);
            cmd.Parameters.AddWithValue("@idmarca", v.idMarca);
            cmd.Parameters.AddWithValue("@idvehiculo", v.idVehiculo);
            cn.Open();
            resultado = cmd.ExecuteNonQuery();
            cn.Close();
            return resultado;

        }
        public int Eliminar(int id)
        {
            int resultado = -1;

            SqlCommand cmd = new SqlCommand("SP_VEHICULO_ELIMINAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idvehiculo", id);

            cn.Open();
            resultado = cmd.ExecuteNonQuery();
            cn.Close();

            return resultado;
        }

        public Vehiculo Obtener(int id)
        {
            Vehiculo obj = new Vehiculo();
            SqlCommand cmd = new SqlCommand("SP_CLIENTE_OBTENER", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idvehiculo", id);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                obj.idVehiculo = dr.GetInt32(0);
                obj.Placa = dr.GetString(1);
                obj.Año = dr.GetInt32(2);
                obj.Modelo = dr.GetString(3);
                obj.idMarca = dr.GetInt32(4);
            }
            dr.Close();
            cn.Close();
            return obj;


        }


    }
}