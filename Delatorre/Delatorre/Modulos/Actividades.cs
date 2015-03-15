using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Delatorre.Modulos
{
    class Actividades
    {

        /*Sistema gestor de actividades aplicando semaforos o sincronizacion de procesos */

        private MySqlCommand Cmd;
        private Semaphore Semaforo;
        private Thread  H1;
        private int n1 =0; //contador de secuencias sincronas del hilo

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                this.Semaforo.Dispose();
        }

        private void ParamActividades(string[] act)
        {
            //
            Semaforo.WaitOne();
            MySqlConnection conn = new MySqlConnection(Modulos.Conexion.GetDireccion());
            string sql = "INSERT INTO actividades(actividad,fecha,hora,idempleado) values('"
                + act[0] + "','" + act[1] + "','" + act[2] + "','" + act[3] + "')";
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                Cmd = new MySqlCommand(sql, conn);
                MySqlDataReader Read;
                Read = Cmd.ExecuteReader();
                if (Read.RecordsAffected >= 1)
                    conn.Close();
                else
                    Errores.Add("Error al momento de agregar");
                Semaforo.Release();
            }
            catch (Exception ex) {
                Errores.Add(ex.Message);
                conn.Close();
                Semaforo.Release();
            }

        }

        /// <summary>
        /// Constructor para invocar los procesos 
        /// </summary>
        /// <param name="Formulario"> Establece el formulario donde se le invoco para aplicacion de delegados </param>
        public Actividades()
        {
            Semaforo = new Semaphore(1, 1);
        }

        /// <summary>
        /// destructor 
        /// </summary>
        ~Actividades()
        {
            Dispose(true);
        }

        /// <summary>
        /// Envia los datos de las actividades recientes
        /// </summary>
        /// <param name="Actividades"> las actividades (strings)
        ///  Orden de las actividades: Codigo:Actividad , Fecha , Hora , IdEmpleado
        /// </param>
        public void SetActividades(string[] Actividades)
        {

            H1 = new Thread(delegate()
                {
                    ParamActividades(Actividades);
                });
            H1.Name = "HiloSecuencia" + n1;
            H1.Start();
            n1++;
         
        }

        public List<string> Errores = new List<string>();

        
     
    }
}
