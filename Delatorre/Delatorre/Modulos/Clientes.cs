using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;

namespace Delatorre.Modulos
{
    class Clientes
    {

        private string[] ValoresC = null;
        private MySqlConnection Conn;
        private MySqlDataAdapter Adapter;
        private MySqlCommand Cmd;
        private MySqlDataReader Reader;

        /// <summary>
        /// contructor de la clase
        /// </summary>
        public Clientes()
        {
            ValoresC = null;
            Conn = new MySqlConnection(Conexion.GetDireccion());
            Reader = null;
        }


        /// <summary>
        /// establece un arreglo de datos (strings) con el orden siguiente 
        /// idcliente , nombres , telefono, dui , direccion ,fecha 
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public  bool SetDatosClientes(string[] datos)
        {

            try
            {
                Conn.Open();
                string Sql = "INSERT INTO clientes (idcliente , nombre , telefono, dui, nit , direccion ,fecha) VALUES('"
                    + datos[0] + "','" 
                    + datos[1] + "','" 
                    + datos[2] + "','" 
                    + datos[3] + "','" 
                    + datos[4] + "','" 
                    + datos[5] + "','" + datos[6] +  "')" ;

                Cmd = new MySqlCommand(Sql , Conn);
                Reader = Cmd.ExecuteReader();
                if(Reader.RecordsAffected >=1)
                {
                    Conn.Close();
                    return true;
                }
                else 
                {
                    Conn.Close();
                    return false;
                }
            }
            catch {
                if(Conn.State == System.Data.ConnectionState.Open)Conn.Close();
                return false;
            }

        }

        /// <summary>
        /// obtiene un arreglo de clientes mediante parametros
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public List<object> GetdatosClientes(string parametros)
        {

            List<object> valores = new List<object>();
            try {

                Conn.Open();
                string sql = "select * from clientes where REPLACE(telefono, '-' , '')='" 
                    + parametros
                    + "' or REPLACE(dui, '-' , '')='" 
                    + parametros 
                    + "' or nombre like '%"
                    + parametros + "%' or dui='"
                    + parametros + "' or REPLACE(nit, '-' , '')='" 
                    + parametros + "'";

                Adapter = new MySqlDataAdapter(sql, Conn);
                DataSet ds = new DataSet();
                Adapter.Fill(ds);
                DataTable tabla = ds.Tables[0];
                foreach (DataRow R in tabla.Rows)
                {
                    object[] objeto = R.ItemArray;
                    valores.Add(objeto);
                }
                
                Conn.Close();
                return valores;
            }
            catch { Conn.Close(); }

            Conn.Close();
            return null;
        }

        /// <summary>
        /// obtiene una lista de todos los clientes 
        /// </summary>
        /// <returns></returns>
        public List<object> GetdatosClientes()
        {

            List<object> valores = new List<object>();
            try
            {

                Conn.Open();
                string sql = "select telefono as telefono , dui as dui, nombre as nombre, nit as nit  from clientes";
                Adapter = new MySqlDataAdapter(sql, Conn);
                DataSet ds = new DataSet();
                Adapter.Fill(ds);
                DataTable tabla = ds.Tables[0];
                foreach (DataRow R in tabla.Rows)
                {
                    object[] objeto = R.ItemArray;
                    valores.Add(objeto);
                }

                Conn.Close();
                return valores;
            }
            catch { Conn.Close(); }

            Conn.Close();
            return null;
        }


        public bool ExisteCliente(string[] parametros)
        {

            List<object> clientes = GetdatosClientes();
            for (int i = 0; i < clientes.Count; i++)
            {
                object[] ObjCliente = (object[])clientes[i];
                string[] Strcliente = Array.ConvertAll<object, string>(ObjCliente, Convert.ToString);

                for (int j = 0; j < Strcliente.Length; j++)
                {
                     Strcliente[j] = Strcliente[j].Trim();
                }

                for (int k = 0; k < parametros.Length; k++)
                {
                        bool Encontrado = Strcliente.Contains<string>(parametros[k]);
                        if (Encontrado)
                            return true;
                }
                
            }

            return false;
        }


      

    }
}
