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
    public partial class RegistrarEmpleado : Form
    {
        public RegistrarEmpleado()
        {
            InitializeComponent();
        }

        public static int Secuencia = 0;
        private static List<string> EmpleadosEdit = new List<string>();

       // Thread Hilo0;
        int sentinela = 0;
        string SQL;
        string idsucursal = "";
        List<object> ListadoSucursal = new List<object>();
        Random rnd = new Random(DateTime.Now.Millisecond);

        MySqlCommand cmd;
       // MySqlDataAdapter adaptador;
        MySqlDataReader lectura;


        private void RegistrarEmpleado_Load(object sender, EventArgs e)
        {
            
            Modulos.Vinculos vinculo = new Modulos.Vinculos();
            ListadoSucursal = vinculo.VincularSucursal();
            foreach (var list in ListadoSucursal)
            {
               combosucursal.Items.Add(list.ToString());
            }

            switch (Secuencia)
            {
                case 0:
                    sentinela = 0;
                    lblreg.Text = "Registro de Empleados";
                    break;
                case 1:
                    sentinela = 1;
                    lblreg.Text = "Edicion de Empleados";
                    TiempoEdicion.Enabled = true;
                    break;
            }

   
        }

        private void TiempoEdicion_Tick(object sender, EventArgs e)
        {
            if (EmpleadosEdit != null)
            {
                
                TiempoEdicion.Enabled = false;
            }

        }

        private void cmdsave_Click(object sender, EventArgs e)
        {

            switch (sentinela)
            {
                case 0:
                    RegistrarEmpleado_();
                    break;
                case 1:
                    break;
            }

        }

        private void RegistrarEmpleado_()
        {

            if (txtnombre.Text == "" || txtapellido.Text == "" || txtdui.Text == "" || txtsalario.Text == "")
            {
                MessageBox.Show("Todos los campos son obligatorios, verifique si todos los campos estan correctos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SQL = "insert into empleados(idempleado , idusuario , Nombre , Apellido , Dui , Salario , idsucursal , Cargo , Estado) values ('"
                + lblcodigo.Text + "','"
                + "No" + "','" 
                + txtnombre.Text + "','"
                + txtapellido.Text + "','"
                + txtdui.Text + "','"
                + txtsalario.Text + "','"
                + idsucursal + "','"
                + combocargo.Text + "'," + 1  + ")";

            cmd = new MySqlCommand(SQL, Modulos.Conexion.GetConexion());
            lectura = cmd.ExecuteReader();
            if (lectura.RecordsAffected >= 1)
            {
                MessageBox.Show("Empleado Registrado Con exito");
                Modulos.Conexion.CerrarConexion();
                this.Close();
            }
            else
            {
                MessageBox.Show("Existe un problema al momento de crear el empleado ");
                return;
            }
            
        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Token = "EMP";
                string ID = txtnombre.Text[0].ToString() + txtnombre.Text[txtnombre.Text.Length - 1].ToString();
                string Valor =
                    rnd.Next(0, 9).ToString()
                    + rnd.Next(0, 9).ToString()
                    + rnd.Next(0, 9).ToString()
                    + rnd.Next(0, 9).ToString();
                lblcodigo.Text = (string)Token + ID.ToString().ToUpper() + Valor.ToString();
            }
            catch { }
        }

        private void combosucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] datossucursal = combosucursal.SelectedItem.ToString().Split(',');
                idsucursal = datossucursal[0];
            }
            catch { }
        }


    }
}
