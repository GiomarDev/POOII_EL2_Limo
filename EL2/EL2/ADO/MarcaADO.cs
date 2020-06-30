using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EL2.Models;


namespace EL2.ADO
{
    public class MarcaADO
    {
        SqlConnection cn =
            new SqlConnection(ConfigurationManager.ConnectionStrings["CNX"].ConnectionString);

        public List<Marca> Listar()
        {
            List<Marca> lista = new List<Marca>();
            SqlCommand cmd = new SqlCommand("SP_MARCA_LISTAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Marca()
                {
                    idMarca = dr.GetInt32(0),
                    Nombre = dr.GetString(1)
                });
            }
            dr.Close();
            cn.Close();
            return lista;
        }
    }
}