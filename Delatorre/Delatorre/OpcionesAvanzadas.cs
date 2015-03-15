using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MySql.Data.MySqlClient;

namespace Delatorre
{
    public partial class OpcionesAvanzadas : Form
    {
        public OpcionesAvanzadas()
        {
            InitializeComponent();
        }

        Thread HiloSecuencia;
        List<string> ListaConectados = new List<string>();
        MySqlDataAdapter mysqlAdapter;
        MySqlConnection Conexion;
        DataTable Tabla;
        DataSet DS;


        private void OpcionesAvanzadas_Load(object sender, EventArgs e)
        {
            this.Text = "Opciones avanzadas Root";
            ListaConectados.Clear();
            ConectarUsuarios();
        }

        private delegate void Respuesta(List<string> Lista);

        private void EnvioRespuesta(List<string> Lista)
        {
            lista_usuarios.Items.Clear();
            foreach (string valor in Lista)
            {
                lista_usuarios.Items.Add(valor);
            }
            LblConectados.Text = "Usuarios conectados: " + lista_usuarios.Items.Count;
        }

        private void ConectarUsuarios()
        {

            HiloSecuencia = new Thread(delegate()
            {
                try
                {
                    ListaConectados.Clear();

                    Tabla = new DataTable();
                    DS = new DataSet();

                    string Sql = "select User_login.iduser , User_login.username , empleados.Nombre , empleados.Apellido "
                        + "From User_login Inner join empleados on User_login.iduser = empleados.idusuario Where User_login.sesion = 1";

                    Conexion = new MySqlConnection(Modulos.Conexion.GetDireccion());
                    Conexion.Open();
                    mysqlAdapter = new MySqlDataAdapter(Sql, Conexion);
                    mysqlAdapter.Fill(DS);
                    Tabla = DS.Tables[0];

                    foreach (DataRow Rows in Tabla.Rows)
                    {
                        var id = Rows.Field<string>("iduser", DataRowVersion.Default);
                        var username = Rows.Field<string>("username", DataRowVersion.Default);
                        var Nombre = Rows.Field<string>("Nombre", DataRowVersion.Default);
                        var Apellido = Rows.Field<string>("Apellido", DataRowVersion.Default);

                        ListaConectados.Add(id + " , " + username + " , " + Nombre + " , " + Apellido);
                    }
                    Respuesta Resp = new Respuesta(EnvioRespuesta);
                    this.Invoke(Resp, new object[] { ListaConectados });
                    Conexion.Close();
                }
                catch {
                    if (Conexion.State == ConnectionState.Open) Conexion.Close();
                }
            });
            HiloSecuencia.Start();

        }

        private bool MatarSesion( string Argumento)
        {
            try
            {

                string SQL = "update User_login set sesion = 0 where iduser ='" + Argumento + "'";
                MySqlCommand cmd;

                Conexion = new MySqlConnection(Modulos.Conexion.GetDireccion());

                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
                Conexion.Open();

                cmd = new MySqlCommand(SQL, Conexion);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.RecordsAffected >= 1)
                {
                    Conexion.Close();
                    return true;
                }
                else
                {
                    Conexion.Close();
                    return false;
                }

            }
            catch { Conexion.Close(); }

            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string[] args = lista_usuarios.SelectedItem.ToString().Split(',');

            Thread hilo = new Thread(delegate()
            {
                try
                {
                
                    bool Respuesta = MatarSesion(args[0]);
                    if (Respuesta == true)
                    {
                        MessageBox.Show("Sesion finalizada por el administrador");
                        ConectarUsuarios();
                        return;
                    }
                }
                catch { }
            });
            hilo.Start();
        }



    }
}
