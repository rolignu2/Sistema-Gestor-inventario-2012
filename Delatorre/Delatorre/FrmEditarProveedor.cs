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
using Delatorre.Modulos;

namespace Delatorre
{
    public partial class FrmEditarProveedor : Form
    {
        public FrmEditarProveedor()
        {
            InitializeComponent();
        }

        private void AjustarGrilla(bool T)
        {
            switch (T)
            {
                case true:
                    grillaProv.Size = new Size(439 , 58);
                    break;
                case false:
                    grillaProv.Size = new Size(439 , 168);
                    break;
            }
        }

        private delegate void GuardandoDelegate(int Estado);

        private delegate void GetdatosgrillaDelegado();

        private void Getdatosgrilla()
        {
            try {
                grillaProv.DataSource = null;
                grillaProv.DataSource = Dt;
                MotorBusqueda.Datagrid = grillaProv;
            }
            catch { }
        }

        private void GuardandoD(int Estado)
        {
            switch (Estado)
            {
                case 0:
                    lblguardando.Text = "Guardando Datos Proveedor ";
                    break;
                case 1:
                    lblguardando.Text = "";
                    AjustarGrilla(false);
                    break;
                case 2:
                    lblguardando.Text = "Cargando datos de los Proveedores";
                    break;
            }

        }

        private Thread H1, H2;

        private MySqlConnection conn;

        private MySqlDataAdapter Adapter;

        private DataSet Ds;

        private DataTable Dt;

        private string IDprov = "";

        private void ConectarGrilla()
        {
            H1 = new Thread(delegate()
                {
                    conn = new MySqlConnection(Delatorre.Modulos.Conexion.GetDireccion());
                    if (conn.State != ConnectionState.Open) conn.Open();
                    GuardandoDelegate guardar = new GuardandoDelegate(GuardandoD);
                    this.Invoke(guardar, new object[] { 2 });
                    try
                    {
                        string sql = "select * from Proveedores";
                        Adapter = new MySqlDataAdapter(sql, conn);
                        Ds = new DataSet();
                        Adapter.Fill(Ds);
                        Dt = new DataTable();
                        Dt = Ds.Tables[0];
                        GetdatosgrillaDelegado dgrilla = new GetdatosgrillaDelegado(Getdatosgrilla);
                        this.Invoke(dgrilla);
                        this.Invoke(guardar, new object[] { 1 });
                        conn.Close();
                    }
                    catch { conn.Close(); }
                });
            if (H1.ThreadState != ThreadState.Running) H1.Start();
        }

        private void DatosGrilla(int row)
        {
            try
            {
                IDprov = grillaProv[0, row].Value.ToString();
                txtnombre.Text = grillaProv[1, row].Value.ToString();
                txtdireccion.Text = grillaProv[2, row].Value.ToString();
                txttelefono.Text = grillaProv[3, row].Value.ToString();
                txtwebdir.Text = grillaProv[4, row].Value.ToString();
            }
            catch { }
        }

        private void GuardarDatos()
        {
            if (txtnombre.Text == "" || txttelefono.Text == "")
            {
                MessageBox.Show("Existen algunos campos obligatorios; favor llenarlos");
                return;
            }

            string sql = "update Proveedores set nombre='" + txtnombre.Text 
                + "', direccion='" + txtdireccion.Text + "',telefono='" + txttelefono.Text 
                + "', sitioweb='" + txtwebdir.Text + "' where idproveedor='" + IDprov + "'";

            H2 = new Thread(delegate()
                {

                    conn = new MySqlConnection(Modulos.Conexion.GetDireccion());
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    try
                    {
                      
                        MySqlCommand cmd = new MySqlCommand(sql , conn);
                        MySqlDataReader reader;
                        reader = cmd.ExecuteReader();
                        if (reader.RecordsAffected >= 1)
                        {
                            MessageBox.Show("Proveedor Editado con exito ", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conn.Close();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Error al momento de editar ", "Opss!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            conn.Close();
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error al momento de editar ", "Opss!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        conn.Close();
                        return;
                    }
                });
            if (H2.ThreadState == ThreadState.Unstarted || H2.ThreadState == ThreadState.Stopped) H2.Start();

        }

        private MotorBusqueda Busqueda = new MotorBusqueda();

        private void FrmEditarProveedor_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            AjustarGrilla(false);
            lblguardando.Text = "";
            ConectarGrilla();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        }

        private void grillaProv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DatosGrilla(e.RowIndex);
            AjustarGrilla(true);
        }

        private void cmdreflesh_Click(object sender, EventArgs e)
        {
            AjustarGrilla(false);
            ConectarGrilla();
        }

        private void cmdguardar_Click(object sender, EventArgs e)
        {
            GuardarDatos();
        }

        private void txtprov_TextChanged(object sender, EventArgs e)
        {

            if (MotorBusqueda.ParametrosBusqueda.Count >= 1)
                MotorBusqueda.ParametrosBusqueda.Clear();

            MotorBusqueda.ParametrosBusqueda.Add("nombre");
            MotorBusqueda.ParametrosBusqueda.Add("direccion");
            MotorBusqueda.ParametrosBusqueda.Add("telefono");
          

            MotorBusqueda.Cadena = txtprov.Text;
            MotorBusqueda.Datagrid = grillaProv;

            try
            {
                Busqueda.InitFunction(true);
            }
            catch { }

            Busqueda.GetBusqueda();
           /*if (Busqueda.IsaliveThreat() == true)
            {
                timer1.Enabled = true;
                Busqueda.WaitTimeConfig(grillaProv, new Point(350, 115));
           }*/
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           /* if (Busqueda.WaitTime() == true)
            {
                timer1.Enabled = false;
            }*/
        }

    }
}
