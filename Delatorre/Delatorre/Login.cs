using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Delatorre.Modulos;
using System.Threading;

namespace Delatorre
{
    public partial class Login : Form
    {

        private int sentinela = 0;
        private MySqlDataAdapter adapter;
        private DataSet ds;
        private string SQL = null;
        int Nintentos = 3;
        string[] generandocapcha = new string[4];

        Thread Hilo;

        public static bool SesionMuerta = false;

        private delegate void INICIANDO(int i);

        private delegate void Parametros();

        private delegate void Habiliart();

        private void HabilitarControl() { 
            cmdenviar.Enabled = true;
            picloading.Visible = false;
        }

        private delegate void DelegadoIntentos();

        private void Intentos()
        {

            if (Nintentos == 0)
            {
                generarCapcha();
                lblcontraseña.Text = "Contraseña";
                linksesion.Text = "Registrar Codigo ";
            }
            else
            {
                lblcontraseña.Text = "Contraseña (intentos " + Nintentos + ")";
                linksesion.Text = "Contraseña o usuario incorrectos";
                Nintentos--;
            }

        }

        private void generarCapcha()
        {
            this.Width = 475;
            this.Height = 441;
            Random rnd = new Random(DateTime.Now.Millisecond);
            string[] tokens = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "N", "O", "P", "Q", "R", "S", "X", "Y", "Z" , "@" , "1" , "%" , "$" , "6" };
            try
            {
                for (int i = 0; i < 4; i++)
                {
                    generandocapcha[i] = tokens[rnd.Next(0, 25)];
                }
            }
            catch { }
            CaptchaImage.CaptchaImage ImagenCapcha = new CaptchaImage.CaptchaImage(string.Join("", generandocapcha), this.piccapcha.Width, this.piccapcha.Height);
            piccapcha.Image = ImagenCapcha.Image;
            cmdenviar.Enabled = false;
        }

        private void verificarCapcha()
        {
            if (string.Join("", generandocapcha).ToUpper().Equals(txtcapcha.Text.ToUpper()))
            {
                this.cmdenviar.Enabled = true;
                this.Height = 358;
            }
            else
            {
                generarCapcha();
            }
        }

        private void parametros__()
        {
            lblcontraseña.Text = "Contraseña";
            SesionMuerta = false;
            Principal p = new Principal();
            System.Threading.Thread.Sleep(500);
            p.Show();
            this.Close();
        }

        private void MensajeInicio(int i)
        {
            switch (i)
            {
                case 1:
                    cmdenviar.Enabled = false;
                    linksesion.Text = "Iniciando sesion Espere";
                    this.picloading.Visible = true;
                    break;
                case 2:
                    linksesion.Text = "Sesion iniciada ..." + "  " + txtnombre.Text;
                    cmdenviar.Enabled = true;
                    this.picloading.Visible = false;
                    break;
            }
        }

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.Text = "Login Repuestos delatorre ";
            this.MaximizeBox = false;
            this.Height = 358;
            this.picloading.Visible = false;
            txtpass.PasswordChar = '*';
            if (SesionMuerta == true)
            {
               
                try
                {
                    var empleado = Datos.DatosEmpleados.Split(',');
                    linksesion.Text = "Sesion de " + empleado[1] + " " + empleado[2] +  " Finalizada";
                }
                catch { linksesion.Text = "Sesion Finalizada "; }
            }
        }

        private void cmdenviar_Click(object sender, EventArgs e)
        {
            try { if (Hilo.IsAlive) Hilo.Abort(); }
            catch { }

            string Contra = "";
            string Alias = "";

            Alias = Modulos.Encriptador.encriptar(txtnombre.Text);
            Contra =Modulos.Encriptador.encriptar(txtpass.Text);

            Hilo = new Thread(delegate()
            {
                Parametros params_ = new Parametros(parametros__);
                switch (sentinela)
                {
                    case 0:
                        switch (VerificarUsuario(Alias , Contra))
                        {
                            case 0:
                                try
                                {
                                    this.Invoke(params_);
                                    Nintentos = 3;
                          
                                }
                                catch { }
                                break;
                            case 1:
                                try
                                {
                                    MessageBox.Show("Error al momento de entrar , favor verifique password o usuario");
                                    Habiliart H = new Habiliart(HabilitarControl);
                                    this.Invoke(H);
                                    DelegadoIntentos Dint = new DelegadoIntentos(Intentos);
                                    this.Invoke(Dint);
                                }
                                catch { }
                                break;
                            case 3:
                                try
                                {
                                    MessageBox.Show("Cuenta desactivada");
                                    Habiliart HD = new Habiliart(HabilitarControl);
                                    this.Invoke(HD);
                                }
                                catch { }
                                break;
                            default:
                                break;
                        }
                        break;
                    case 1:
                        break;

                }
            });
            Hilo.Start();


        }

        private int VerificarUsuario(string alias , string contra)
        {
             INICIANDO INIT = new INICIANDO(MensajeInicio);
            try
            {
                this.Invoke(INIT, new object[] { 1 });
                SQL = "Select * from User_login where username='" + alias + "' and password ='" + contra + "'";
                adapter = new MySqlDataAdapter(SQL, Modulos.Conexion.GetConexion());
                ds = new DataSet();
                adapter.Fill(ds);
                DataTable tabla = new DataTable();
                tabla = ds.Tables[0];
                if (tabla.Rows.Count >= 1)
                {
                    foreach (DataRow filas in tabla.Rows)
                    {
                        var id =  filas.Field<string>("iduser", DataRowVersion.Default);
                        var usuario = Modulos.Encriptador.desencriptar(filas.Field<string>("username", DataRowVersion.Default));
                        var estado = filas.Field<string>("estado", DataRowVersion.Default);
                        var tipo = filas.Field<string>("tipo", DataRowVersion.Default);
                        var sesion = filas.Field<int>("sesion", DataRowVersion.Default);
                        
                        Datos.DatosUsuario = usuario + "," + estado + "," + tipo;
                        Datos.Idusuario = id;
                        Datos.sesion = (int)sesion;

                        GetSucursalFromUser(id);

                        if (int.Parse(estado) == 1)
                        {
                            this.Invoke(INIT, new object[] { 2 });
                            return 0;
                        }
                        else
                        {
                            this.Invoke(INIT, new object[] { 2 });
                            return 2;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Modulos.Errores.SetErrores(ex.Message);
                List<object> errores = Modulos.Errores.GetErrores();
                if (errores.Count >= 1)
                {
                    Modulos.Errores.MostrarNumeroErrores();
                }
            }

            return 1;
        }

        private void GetSucursalFromUser(string idusuario)
        {
            try
            {
                string Psql = "select sucursal.idsucursal as id , sucursal.Nombre as nombre, sucursal.Gerente as gerente from empleados inner join sucursal on empleados.idsucursal = "
                + "sucursal.idsucursal inner join User_login on empleados.idusuario = User_login.iduser where User_login.iduser = '" + idusuario + "'";

                adapter = new MySqlDataAdapter(Psql, Modulos.Conexion.GetConexion());
                ds = new DataSet();
                adapter.Fill(ds);
                DataTable tabla = new DataTable();
                tabla = ds.Tables[0];
                foreach (DataRow filas in tabla.Rows)
                {
                    var idsucursal = filas.Field<string>("id", DataRowVersion.Default);
                    var nombresucu = filas.Field<string>("Nombre", DataRowVersion.Default);
                    var gerente = filas.Field<string>("Gerente", DataRowVersion.Default);
                    Datos.DatosSucursal = nombresucu + "," + idsucursal + "," + gerente;
                }
            }
            catch
            {
                //no encuentra alguna variable de la sucursal pedida
            }
        }

        private void cmdadd_Click(object sender, EventArgs e)
        {
            Registro reg = new Registro();
            reg.Show();
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar) == 13)
            {
                txtpass.Focus();
            }
        }

        private void txtnombre_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtpass.Focus();
            }
        }

        private void txtnombre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdenviarCapcha_Click(object sender, EventArgs e)
        {
            verificarCapcha();
        }

        private void txtnombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtpass.Focus();
            }
        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar) == 13)
            {
                cmdenviar.Focus();
            }
        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
