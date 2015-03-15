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
    public partial class RegistrarProveedor : Form
    {
        public RegistrarProveedor()
        {
            InitializeComponent();
        }

        private void RegistrarProveedor_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.Text = "Registrar un Proveedor";
        }

      

        private void Cmdregistrar_Click(object sender, EventArgs e)
        {


            if (txtnombre.Text == "" || txttelefono.Text == "")
            {
                MessageBox.Show("Campos nombre y telefono son obligatorios", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Random Rnd = new Random(DateTime.Now.Millisecond);
            string ID = "PROV" + Rnd.Next(100, 500).ToString() + Rnd.Next(100, 900).ToString() + Rnd.Next(200,300) ;
            string sql = "INSERT INTO Proveedores (idproveedor , nombre , direccion , telefono , sitioweb) " +
                " VALUES('"
                + ID
                + "','"
                + txtnombre.Text
                + "','"
                + txtdireccion.Text
                + "','"
                + txttelefono.Text
                + "','"
                + txtwebdir.Text + "')";

            System.Threading.Thread Hilo = new System.Threading.Thread(delegate(){

                try
                {
                    MySqlConnection conn = new MySqlConnection(Delatorre.Modulos.Conexion.GetDireccion());
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.RecordsAffected >= 1)
                    {
                        MessageBox.Show("Proveedor registrado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        conn.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Hubo un Error al registrar proveedor", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        conn.Close();
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Hubo un Error al registrar proveedor", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            });
            if (Hilo.ThreadState == System.Threading.ThreadState.Running) return;
            else Hilo.Start();

        }

        private void cmdexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
