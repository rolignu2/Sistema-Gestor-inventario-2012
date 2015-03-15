using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Delatorre.Modulos
{
    class Vinculos
    {

        private List<object> Resultados;
        private MySqlDataAdapter Adaptador;
        private DataTable tabla = new DataTable();
            

        public List<object> VincularSucursal()
        {
            Resultados = new List<object>();
            Adaptador = new MySqlDataAdapter("Select * from sucursal", Conexion.GetConexion());
            DataSet ds = new DataSet();
            Adaptador.Fill(ds);
            tabla = ds.Tables[0];

            foreach (DataRow rows in tabla.Rows)
            {
                var datos =
                    rows.Field<string>("idsucursal", DataRowVersion.Default) 
                    + "," +
                    rows.Field<string>("Nombre", DataRowVersion.Default)
                    + "," + 
                    rows.Field<string>("Gerente", DataRowVersion.Default);
                Resultados.Add(datos);
            }

            return Resultados;
        }

        public List<object> VincularUsuario()
        {
            Resultados = new List<object>();
            Adaptador = new MySqlDataAdapter("Select * from User_login", Conexion.GetConexion());
            DataSet ds = new DataSet();
            Adaptador.Fill(ds);
            tabla = ds.Tables[0];

            foreach (DataRow rows in tabla.Rows)
            {
                var datos =
                    rows.Field<string>("iduser", DataRowVersion.Default)
                    + "," +
                    Modulos.Encriptador.desencriptar( rows.Field<string>("username", DataRowVersion.Default))
                    + "," +
                    rows.Field<string>("tipo", DataRowVersion.Default);
                Resultados.Add(datos);
            }

            return Resultados;

        }

    }
}
