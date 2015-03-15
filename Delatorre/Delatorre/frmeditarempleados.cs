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
    public partial class frmeditarempleados : Form
    {
        public frmeditarempleados()
        {
            InitializeComponent();
        }

        List<object> ListDatosEmpleados = new List<object>();
        List<object> ListadoSucursal = new List<object>();
        List<object> ListaUsuarios = new List<object>();
        Thread Hilo;

        string IdEmpleado;
        string IdUsuario;

        private delegate void DatosEmpleadosDelegado(bool Y = true);

        private void DatosEmpleados(bool Y = true) 
        {
            if (Y == true)
            {
                comboempleado.Text = "Obteniendo datos ... ";
            }
            else
            {
                for (int i = 0; i < ListDatosEmpleados.Count; i++)
                {
                    object[] ObjDatos = (object[]) ListDatosEmpleados[i];
                    string[] Datos = Array.ConvertAll(ObjDatos , p => (p ?? String.Empty).ToString());
                    string Union = string.Join("," , Datos );
                    comboempleado.Items.Add(Union);
                }
                foreach (var list in ListadoSucursal)
                {
                    combosucursal.Items.Add(list.ToString());
                }
                foreach (var list in ListaUsuarios)
                {
                    combousuario.Items.Add(list.ToString());
                }
                comboempleado.Text = "Empleado no seleccionado";
            }

        }

        private void frmeditarempleados_Load(object sender, EventArgs e)
        {
            this.Text = "Edicion de empleados ";
            this.Width = 555;
            this.Height = 143;

            DatosEmpleadosDelegado DE = new DatosEmpleadosDelegado(DatosEmpleados);
            this.Invoke(DE, new object[] { true });

            Hilo = new Thread(delegate()
            {
                DataTable tabla = Delatorre.Modulos.Datos.GetEmpleados(false);
                ListDatosEmpleados.Clear();
                foreach (DataRow Rows in tabla.Rows)
                {
                    object Valor = Rows.ItemArray;
                    ListDatosEmpleados.Add(Valor);
                }
                Modulos.Vinculos vinculo = new Modulos.Vinculos();
                ListadoSucursal = vinculo.VincularSucursal();
                ListaUsuarios = vinculo.VincularUsuario();
                this.Invoke(DE, new object[] { false });
            });
            Hilo.Start();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        }


        private void comboempleado_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.Width = 555;
            this.Height = 342;
            DescomprimirDatos(comboempleado.SelectedIndex);
           
        }

        private void DescomprimirDatos(int i)
        {
            string[] datos =  comboempleado.Items[i].ToString().Split(',');
            
            try
            {
                IdEmpleado = datos[0];
                IdUsuario = datos[1];
                txtnombre.Text = datos[2];
                txtapellido.Text = datos[3];
                txtdui.Text = datos[4];
                txtsalario.Text = datos[5];

                for (int j = 0; j < combosucursal.Items.Count; j++)
                {
                    string[] sucursal = combosucursal.Items[j].ToString().Split(',');
                    if (datos[6].Equals(sucursal[0]))
                    {
                        combosucursal.Text = combosucursal.Items[j].ToString();
                        break;
                    }
                    combosucursal.Text = "No vinculado";
                }

                combocargo.Text = datos[7];

                if (Convert.ToInt32(datos[8]) == 1)
                    checkactivo.Checked = true;
                else
                    checkactivo.Checked = false;

                for (int k = 0; k < combousuario.Items.Count; k++)
                {
                    string[] usuario = combousuario.Items[k].ToString().Split(',');
                    if ( IdUsuario.Equals(usuario[0]))
                    {
                        combousuario.Text = combousuario.Items[k].ToString();
                        break;
                    }
                    combousuario.Text = "Usuario No vinculado";
                }
            }
            catch { }
        }

        private void GuardarEdicionRegistroEmpleado()
        {

            bool isuauario = combousuario.Text.Contains(",");
            string estado = "";
            if (checkactivo.Checked == true)
                estado = "1";
            else
                estado = "0";
            string[] id = combousuario.Text.Split(',');


            string sql = "";
            string[] idsucursal = combosucursal.Text.Split(',');


            if (isuauario == true)
            {

                sql = "update empleados set idusuario='"
                    + id[0]
                    + "', Nombre='"
                    + txtnombre.Text
                    + "', Apellido='"
                    + txtapellido.Text
                    + "',Dui='"
                    + txtdui.Text
                    + "',Salario='"
                    + txtsalario.Text
                    + "', idsucursal='"
                    + idsucursal[0]
                    + "',Cargo='"
                    + combocargo.Text
                    + "',Estado='"
                    + estado
                    + "' Where idempleado ='" + IdEmpleado + "'"
                    ;
            }
            else
            {
                sql = "update empleados set idusuario='"
                  + ""
                  + "', Nombre='"
                  + txtnombre.Text
                  + "', Apellido='"
                  + txtapellido.Text
                  + "',Dui='"
                  + txtdui.Text
                  + "',Salario='"
                  + txtsalario.Text
                  + "', idsucursal='"
                  + idsucursal[0]
                  + "',Cargo='"
                  + combocargo.Text
                  + "',Estado='"
                  + estado
                  + "' Where idempleado ='" + IdEmpleado + "'"
                  ;
            }
                         

            Hilo = new Thread(delegate()
                {
                    MySqlConnection conn = new MySqlConnection(Delatorre.Modulos.Conexion.GetDireccion());
                    conn.Open();
                    try
                    {
                        if(conn.State != ConnectionState.Open)
                            conn.Open();
  
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.RecordsAffected >= 1)
                        {
                            MessageBox.Show("Empleado editado con exito", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                    }
                    catch {
                        conn.Close();
                        MessageBox.Show("Problemas al momento de enviar solicitud");
                    }
                });
            if (Hilo.ThreadState != ThreadState.Running
                || Hilo.ThreadState != ThreadState.WaitSleepJoin)
                Hilo.Start();


        }

        private void cmdguardar_Click(object sender, EventArgs e)
        {
            GuardarEdicionRegistroEmpleado();
        }

        private void cmdeliminar_Click(object sender, EventArgs e)
        {
            Hilo = new Thread(delegate()
            {
                string sql = "DELETE FROM empleados Where idempleado='" + IdEmpleado + "'";
                MySqlConnection conn = new MySqlConnection(Delatorre.Modulos.Conexion.GetDireccion());
                conn.Open();
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.RecordsAffected >= 1)
                    {
                        MessageBox.Show("Empleado eliminado con exito", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                catch
                {
                    conn.Close();
                    MessageBox.Show("Problemas al momento de enviar solicitud");
                }
            });
            if (Hilo.ThreadState != ThreadState.Running)
                Hilo.Start();
        }
    }
}
