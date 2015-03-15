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
    public partial class FrmVerProveedor : Form
    {
        public FrmVerProveedor()
        {
            InitializeComponent();
        }

        public static string IdProducto = null;
        private Thread Hilo;


        private delegate void Datos(List<string> Valores);

        private void Datos_(List<string> Valores)
        {
            try
            {
                lblnombre.Text = Valores[0];
                lbldireccion.Text = Valores[1];
                lbltelefono.Text = Valores[2];
                lblsitioweb.Text = Valores[3];
            }
            catch
            {
                lblnombre.Text = "No hay proveedor";
                lbldireccion.Text = "";
                lbltelefono.Text = "";
                lblsitioweb.Text = "";
            }
        }

        private void FrmVerProveedor_Load(object sender, EventArgs e)
        {
            this.Text = "Proveedor";
            List<string> Lista = new List<string>();
            Hilo = new Thread(delegate()
            {
                MySqlConnection conn = new MySqlConnection(Delatorre.Modulos.Conexion.GetDireccion());
                if (conn.State != ConnectionState.Open) conn.Open();
                try
                {
                    string sql = "select Proveedores.nombre , Proveedores.direccion , Proveedores.telefono , Proveedores.sitioweb"
                        + " from productos inner join Proveedores on Proveedores.idproveedor = productos.idproveedores where "
                        + " idpnuevos ='" + IdProducto + "' Or idpusados ='" + IdProducto + "'";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                    System.Data.DataTable tabla = new DataTable();
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    tabla = ds.Tables[0];
                    foreach (DataRow R in tabla.Rows)
                    {
                         Lista.Add(R.Field<string>("nombre", DataRowVersion.Default)); 
                         Lista.Add(R.Field<string>("direccion", DataRowVersion.Default));
                         Lista.Add(R.Field<string>("telefono", DataRowVersion.Default));
                         Lista.Add(R.Field<string>("sitioweb", DataRowVersion.Default));
                         break;
                    }
                    Datos d = new Datos(Datos_);
                    this.Invoke(d, new object[] { Lista });
                }
                catch { }
            });
            Hilo.Start();
        }
    }
}
