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
    public partial class RegistrarSucursal : Form
    {
        public RegistrarSucursal()
        {
            InitializeComponent();
        }

        Thread HiloInicio;

        List<string[]> ListaSucursales = new List<string[]>();
        List<string> ListaNomSucursales = new List<string>();

        Random Rnd = new Random(DateTime.Now.Millisecond);

        MySqlCommand cmd;
        MySqlConnection conn;
        MySqlDataReader lector;

        private void RegistrarSucursal_Load(object sender, EventArgs e)
        {
            HiloInicio = new Thread(delegate() {
            ListaSucursales = Datos.GetAllSucursal();
            foreach (string[] dato in ListaSucursales)
                {
                    ListaNomSucursales.Add(dato[1]);
                }
            });
            HiloInicio.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Seguridad seguridad = new Seguridad();

                List<Control> ListaControles = new List<Control>();

                for (int k = 0; k < this.Controls.Count; k++)
                {
                    Type tipoC = this.Controls[k].GetType();
                    if (tipoC == typeof(TextBox))
                    {
                        ListaControles.Add(this.Controls[k]);
                    }
                }

                seguridad.SetControles(ListaControles);

                if (seguridad.GetControlisEmpty() == true)
                {
                    MessageBox.Show("Algunos campos estan en blanco , todos los campos son obligatorios");
                    return;
                }

                conn = new MySqlConnection(Conexion.GetDireccion());
                conn.Open();

                if (conn.State == ConnectionState.Open != true)
                {
                    MessageBox.Show("Error en la conexion; no se pudo conectar el servidor");
                    conn.Dispose();
                    return;
                }

                string nombre = txtnombre.Text.ToUpper();

                for (int i = 0; i < ListaNomSucursales.Count; i++)
                {
                    if (nombre == ListaNomSucursales[i].ToUpper())
                    {
                        MessageBox.Show("Esta sucursal ya se encuentra registrada en la base de datos con el nombre de: "
                            + ListaNomSucursales[i]);
                        return;
                    }
                }


                char[] caracteresInvalidos = { ',', '-', '_' , ' '};

                string id = "SUC" + nombre[0] + Rnd.Next(0, 100).ToString() + Rnd.Next(0, 99)+ Rnd.Next(0,400);

                string sql = "insert into sucursal (idsucursal , Nombre , Direccion , Telefono, Gerente) values('"
                    + id + "','" + txtnombre.Text + "','" + txtdir.Text + "','" + txttel.Text + "','" + txtgerente.Text + "')";

                cmd = new MySqlCommand(sql, conn);
                lector = cmd.ExecuteReader();
                if (lector.RecordsAffected >= 1)
                {
                    MessageBox.Show("Sucursal Registrada con Exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    this.Close();
                    return;
                }
                else
                {
                    conn.Close();
                    MessageBox.Show("No se pudo registrar; intente denuevo", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (MySqlException Mex)
            {
                MessageBox.Show(Mex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                try
                {
                    conn.Close();
                }
                catch { }
            }
                
        }

        private void txttel_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }
    }
}
