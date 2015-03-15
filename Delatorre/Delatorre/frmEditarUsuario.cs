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
using System.Data;

namespace Delatorre
{
    public partial class frmEditarUsuario : Form
    {
        public frmEditarUsuario()
        {
            InitializeComponent();
        }

        private void frmEditarUsuario_Load(object sender, EventArgs e)
        {
            this.Text = "Edicion de usuarios";
            piccargandoCliente.Visible = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        }

        private List<object> ListaDatosUsuario = new List<object>();
        private ImageList ListaImagenesUsuario = new ImageList();
        private Thread Hilo;

        private MySqlConnection Conn;
        private MySqlDataAdapter Adapter;
        private MySqlCommand cmd;

        private delegate void WaitOne(int EstadoTipo);
        private string CurrentId = null;

        private void WaitOne_(int EstadoTipo)
        {
            switch (EstadoTipo)
            {
                case 0:
                    piccargandoCliente.Visible = true;
                    cmdguardar.Enabled = false;
                    cmdlista.Enabled = false;
                    break;
                case 1:
                     piccargandoCliente.Visible = false;
                    cmdguardar.Enabled = true;
                    cmdlista.Enabled = true;
                    break;
                case 2:
                    piccargandoCliente.Visible = false;
                    cmdguardar.Enabled = true;
                    cmdlista.Enabled = true;
                    break;
            }
        }

        private delegate void EnviarDatos();

        private void enviardatos_()
        {
            ListaImagenesUsuario = new ImageList();
            liscontenido.Clear();
            for (int i = 0; i < ListaDatosUsuario.Count; i++)
            {
                object[] datos = (object[]) ListaDatosUsuario[i];
                string[] valores = Array.ConvertAll<object, string>(datos, Convert.ToString);
                switch (valores[5])
                {
                    case "admin":
                        ListaImagenesUsuario.Images.Add(Delatorre.Properties.Resources.icon_Admin_black);
                        break;
                    case "root":
                        ListaImagenesUsuario.Images.Add(Delatorre.Properties.Resources.icon_Admin_black);
                        break;
                    case "user\t":
                        ListaImagenesUsuario.Images.Add(Delatorre.Properties.Resources.user_male_olive_blue_black);
                        break;
                }
                valores[1] = Delatorre.Modulos.Encriptador.desencriptar(valores[1]);
                valores[3] = Delatorre.Modulos.Encriptador.desencriptar(valores[3]);
                string conversion = string.Join(",", valores);
                liscontenido.Items.Add(conversion, i);

            }

            ListaImagenesUsuario.ImageSize = new System.Drawing.Size(24, 24);
            liscontenido.View = View.LargeIcon;
            liscontenido.LargeImageList = ListaImagenesUsuario;
            liscontenido.StateImageList = ListaImagenesUsuario;
            liscontenido.SmallImageList = ListaImagenesUsuario;
            liscontenido.Alignment = ListViewAlignment.SnapToGrid;
        }

        private void GetdatosUsuarios()
        {
            Hilo = new Thread(delegate()
                {
                    Conn = new MySqlConnection(Modulos.Conexion.GetDireccion());
                    if (Conn.State != ConnectionState.Open) Conn.Open();
                    try
                    {
                        WaitOne w = new WaitOne(WaitOne_);
                        this.Invoke(w, new object[] { 0 });
                        string sql = "Select * from User_login";
                        Adapter = new MySqlDataAdapter(sql, Conn);
                        DataSet ds = new System.Data.DataSet();
                        Adapter.Fill(ds);
                        DataTable Dt = new System.Data.DataTable();
                        Dt = ds.Tables[0];
                        ListaDatosUsuario = new List<object>();
                        foreach (DataRow rows in Dt.Rows)
                            ListaDatosUsuario.Add(rows.ItemArray);
                        
                        this.Invoke(w, new object[] { 1 });
                        EnviarDatos envio = new EnviarDatos(enviardatos_);
                        this.Invoke(envio);
                        Conn.Close();
                    }
                    catch {
                        try
                        {
                            Conn.Close();
                        }
                        catch { }
                    }
                });
            if (Hilo.ThreadState != ThreadState.Running 
                || Hilo.ThreadState != ThreadState.WaitSleepJoin)
                Hilo.Start();
        }

        private void cmdlista_Click(object sender, EventArgs e)
        {
            GetdatosUsuarios();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void liscontenido_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < liscontenido.Items.Count; i++)
            {
                try
                {
                    string[] valoresArray = liscontenido.SelectedItems[i].ToString().Split(',');
                    CurrentId = valoresArray[0];
                    txtuser.Text = valoresArray[1];
                    txtmail.Text = valoresArray[2];
                    txtpass.Text = valoresArray[3];
                    if (int.Parse(valoresArray[4]) == 1)
                        chceckestado.Checked = true;
                    else
                        chceckestado.Checked = false;
                    combocuenta.Text = valoresArray[5];
                    break;
                }
                catch { }
            }
        }


        private void cmdguardar_Click(object sender, EventArgs e)
        {
            DialogResult Diag = MessageBox.Show("¿Desea continuar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Diag == DialogResult.No)
                return;

            var user = Modulos.Encriptador.encriptar(txtuser.Text);
            var pass = Modulos.Encriptador.encriptar(txtpass.Text);
            var correo = txtmail.Text;
            var estado = 0;
            var tipo = combocuenta.Text;

            if (chceckestado.Checked) estado = 1;
            else estado = 0;

            List<string> Listacadenas = new List<string>();
            for (int k = 0; k < CurrentId.Length; k++)
            {
                if (CurrentId[k].ToString() == "{")
                {
                    for (int j = (k + 1); j < CurrentId.Length; j++)
                    {
                        Listacadenas.Add(CurrentId[j].ToString());
                    }

                    break;
                }
            }

            CurrentId = string.Join("", Listacadenas);


            string sql = "update User_login set username='"
                + user + "', email='" 
                + correo + "', password='" 
                + pass  + "', estado=" 
                + estado + ", tipo='"
                + tipo + "' where iduser='" 
                + CurrentId + "'" ;

            Hilo = new Thread(delegate()
            {
                Conn = new MySqlConnection(Modulos.Conexion.GetDireccion());
                if (Conn.State != ConnectionState.Open) Conn.Open();
                try
                {
                    WaitOne w = new WaitOne(WaitOne_);
                    this.Invoke(w, new object[] { 0 });
                    cmd = new MySqlCommand(sql, Conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.RecordsAffected >= 1)
                    {
                        MessageBox.Show("Datos alterados con exito");
                        Conn.Close();
                    }
                    this.Invoke(w, new object[] { 2 });
                }
                catch
                {
                    try { Conn.Close(); }
                    catch { }
                }
            });
            if (Hilo.ThreadState != ThreadState.Running
               || Hilo.ThreadState != ThreadState.WaitSleepJoin)
                Hilo.Start();
        }
    }
}
