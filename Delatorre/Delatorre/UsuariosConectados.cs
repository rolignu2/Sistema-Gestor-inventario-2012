using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Delatorre.Modulos;
using MySql.Data.MySqlClient;

namespace Delatorre
{
    public partial class UsuariosConectados : Form
    {
        public UsuariosConectados()
        {
            InitializeComponent();
        }

        private void UsuariosConectados_Load(object sender, EventArgs e)
        {
            this.Text = "Usuarios conectados";
            Hilo = new Thread(delegate()
                {
                    ConectarUsuarios();
                });
            Hilo.Start();
            TcargaDatos.Enabled = true;
        }

        Thread Hilo;
        MySqlDataAdapter mysqlAdapter;
        MySqlConnection Conexion;
        DataTable Tabla;
        DataSet DS;
        ImageList ListaImagen = new ImageList();
        List<string[]> Lista_datos = new List<string[]>();

        private void ConectarUsuarios()
        {
            try
            {

                Tabla = new DataTable();
                DS = new DataSet();

                string Sql = "select User_login.sesion , User_login.username , empleados.Nombre , empleados.Apellido "
                    + "From User_login Inner join empleados on User_login.iduser = empleados.idusuario";
                Conexion = new MySqlConnection(Modulos.Conexion.GetDireccion());
                Conexion.Open();
                mysqlAdapter = new MySqlDataAdapter(Sql, Conexion);
                mysqlAdapter.Fill(DS);
                Tabla = DS.Tables[0];

                foreach (DataRow Rows in Tabla.Rows)
                {
                    int Sesion = Rows.Field<int>("sesion", DataRowVersion.Default);
                    var username = Modulos.Encriptador.desencriptar(Rows.Field<string>("username", DataRowVersion.Default));
                    var Nombre = Rows.Field<string>("Nombre", DataRowVersion.Default);
                    var Apellido = Rows.Field<string>("Apellido", DataRowVersion.Default);

                    if (Sesion == 1)
                    {
                        ListaImagen.Images.Add(Delatorre.Properties.Resources.Conexion);
                    }
                    else
                    {
                        ListaImagen.Images.Add(Delatorre.Properties.Resources.Noconected);
                    }

                    string[] Carga = { username, Nombre, Apellido };
                    Lista_datos.Add(Carga);

                }


                Conexion.Close();
            }
            catch {
                if (Conexion.State == ConnectionState.Open) Conexion.Close();
            }
   
        }

        private void TcargaDatos_Tick(object sender, EventArgs e)
        {
            
            try
            {
                if (Hilo.IsAlive != true)
                {
                    ListaImagen.ImageSize = new System.Drawing.Size(24, 24);
                    ListaUsuarios.View = View.SmallIcon;
                    ListaUsuarios.LargeImageList = ListaImagen;
                    ListaUsuarios.StateImageList = ListaImagen;
                    ListaUsuarios.SmallImageList = ListaImagen;
                    ListaUsuarios.Alignment = ListViewAlignment.SnapToGrid;

                    for (int i = 0; i < Lista_datos.Count; i++)
                    {
                        string[] MostrarDato = Lista_datos[i];
                        ListaUsuarios.Items.Add(MostrarDato[0] + ", " + MostrarDato[1] + ", " + MostrarDato[2] + ", " , i);
                    }

                    TcargaDatos.Enabled = false;
                }
            }
            catch { }
        }


        
    }
}
