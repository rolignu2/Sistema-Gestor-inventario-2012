using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Delatorre.Modulos
{
    class Conexion
    {


        private static string Direccion_Primaria = "Server=localhost;Database=delatorrebdd;User=root;Password=;";

        private static string Direccion_Secundaria = "Server=sql2.freesqldatabase.com;Database=sql27853;pwd=qwerty;User=sql27853;Password=fC6*uR8%;";

        private static string Direccion = "";

        public static bool Uso_Direccion_secundaria = false;

        private static MySqlConnection Conn = null;
        
        /// <summary>
        /// Inicia una nueva conexion SQL en un objeto estatico
        /// </summary>
        /// <returns></returns>
        public static MySqlConnection IniciarConexion()
        {
            try
            {
                Direccion = Direccion_Primaria;
                Uso_Direccion_secundaria = false;
                CerrarConexion();
                Conn = new MySqlConnection(Direccion);
                Conn.Open();
            }
            catch (MySqlException ex)
            {
                Direccion = Direccion_Secundaria;
                try
                {
                    Uso_Direccion_secundaria = true;
                    CerrarConexion();
                    Conn = new MySqlConnection(Direccion);
                    Conn.Open();
                }
                catch
                {
                    Errores.SetErrores(ex.Message);
                    return null;
                }
            }

            return Conn;
        }

        /// <summary>
        /// envia la conexion a otro objecto
        /// </summary>
        /// <returns></returns>
        public static MySqlConnection GetConexion()
        {
            if (Conn != null)
            {
                if (Conn.State == System.Data.ConnectionState.Open)
                    return Conn;
                else
                {
                    IniciarConexion();
                    return Conn;
                }
            }

            return Conn;
           
        }

        /// <summary>
        /// cierra la conexion , libera datos
        /// </summary>
        public static void CerrarConexion(){
            if (Conn != null)
            {
                if (Conn.State == System.Data.ConnectionState.Open)
                    Conn.Close();
            }
        }

        /// <summary>
        ///  obtiene la direccion de la conexion
        /// </summary>
        /// <returns></returns>
        public static string GetDireccion() { 
             return Direccion ;
        }

        


   

    }
}
