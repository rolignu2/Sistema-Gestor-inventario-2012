using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Delatorre
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        Permisos p;
        ToolTip tooltipemp ;

        MySqlCommand cmd;
        MySqlDataReader lectura;
        string SQL = "";

        Random rnd = new Random(DateTime.Now.Millisecond);

        private void Registro_Load(object sender, EventArgs e)
        {
            tooltipemp = new ToolTip();
            Empleados();
            lblmensaje.Visible = false;

            txtpass.PasswordChar = '*';
            txtreppass.PasswordChar = '*';
         
        }

        private void TaccesoPermisos_Tick(object sender, EventArgs e)
        {
            if (Permisos.Acceso == true)
            {
                this.Show();
                p.Close();
                TaccesoPermisos.Enabled = false;
            }
        }

        private void Registro_Activated(object sender, EventArgs e)
        {
            if (Permisos.Acceso == false)
            {
                this.Hide();
                p = new Permisos();
                p.Show();
                TaccesoPermisos.Enabled = true;
            }
            else
            {
                this.Show();
            }
        }

        private void Empleados()
        {
            DataTable tabla = new DataTable();
            tabla = Modulos.Datos.GetEmpleados(true);
            foreach (DataRow rows in tabla.Rows)
            {
                var id = rows.Field<string>("idempleado", DataRowVersion.Current);
                var nombre = rows.Field<string>("Nombre", DataRowVersion.Default);
                var apellido = rows.Field<string>("Apellido", DataRowVersion.Default);
                var Dui = rows.Field<string>("Dui", DataRowVersion.Default);
                comboempleados.Items.Add(id + "," + nombre + "," + apellido + "," + Dui);
            }
        }

        private string Iduser()
        {
            return rnd.Next(0,9) + "" + rnd.Next(0, 9) + "" + rnd.Next(0,99) + "" + rnd.Next(0,9); 
        }

        private void comboempleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            tooltipemp.SetToolTip(comboempleados, comboempleados.SelectedItem.ToString());
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrarEmpleado emp = new RegistrarEmpleado();
            emp.Show();
        }

        private void cmdingresar_Click(object sender, EventArgs e)
        {
           
                if (txtuser.Text == "" || txtpass.Text == "")
                {
                    MessageBox.Show("Todos los campos son obligatorios, verifique si todos los campos estan correctos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (comboempleados.Text == "")
                {
                    MessageBox.Show("Necesita registrar una cuenta de empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (opt1.Checked == false && opt2.Checked == false)
                {
                    MessageBox.Show("Seleccione un estado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (combocuenta.Text == "")
                {
                    MessageBox.Show("Seleccione un privilegio para esta cuenta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                

                int estado = 0;
                if (opt1.Checked) estado = 1;
                else estado = 0;

                string id = txtuser.Text + Iduser();

                string user = Modulos.Encriptador.encriptar(txtuser.Text);
                string pass = Modulos.Encriptador.encriptar(txtpass.Text);

                SQL = "insert into User_login(iduser , username , email , password , estado , tipo , sesion ) values ('"
                    + id + "','"
                    + user + "','"
                    + txtmail.Text + "','"
                    + pass + "',"
                    + estado + ",'"
                    + combocuenta.Text + "',"
                    + 0 + ")";

                string[] Empleado = comboempleados.SelectedItem.ToString().Split(',');

                System.Threading.Thread hilo = new System.Threading.Thread(delegate()
               {

                   try
                   {
                       cmd = new MySqlCommand(SQL, Modulos.Conexion.GetConexion());
                       lectura = cmd.ExecuteReader();
                       if (lectura.RecordsAffected >= 1)
                       {
                           MessageBox.Show("Registrado Con exito");
                           Modulos.Conexion.CerrarConexion();

                           try
                           {
                              
                               SQL = "update empleados set idusuario ='" + id + "' where idempleado ='" + Empleado[0] + "'";
                               cmd = new MySqlCommand(SQL, Modulos.Conexion.GetConexion());
                               cmd.ExecuteReader();
                               Modulos.Conexion.CerrarConexion();
                           }
                           catch { }
                       }
                       else
                       {
                           MessageBox.Show("Existe un problema al momento de crear el registro ");
                           return;
                       }
                   }
                   catch { }
                   this.UseWaitCursor = false;
        });
                hilo.Start();
                this.UseWaitCursor = true;

        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {
     
        }

        private void txtreppass_TextChanged(object sender, EventArgs e)
        {
            lblmensaje.Visible = true;
            if (txtpass.Text != txtreppass.Text)
            {
                lblmensaje.ForeColor = Color.Red;
                lblmensaje.Text = "Passwords no coinciden";
                cmdingresar.Enabled = false;
            }
            else
            {
                lblmensaje.ForeColor = Color.White;
                lblmensaje.Text = "Passwords Ok";
                cmdingresar.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Empleados();
        }


    }
}
