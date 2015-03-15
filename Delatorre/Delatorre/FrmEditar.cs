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
    public partial class FrmEditar : Form
    {
        public FrmEditar()
        {
            InitializeComponent();
        }

        /*
 0-->codigo
1-->nombre
2-->precio
3-->cantidad
4-->fecha
5-->descuentos
6-->garantia
7-->existente
8-->activo

*/

        public static int Identificador = 0;
        public static List<string> ListaParametros = new List<string>();
        private Thread Hilo;
        private Delatorre.Modulos.Seguridad seguridad = new Modulos.Seguridad();
        private delegate void ResultadoHilo__(object args, object args1);
        private List<Control> Controles = new List<Control>();
        private string IdProdOld = "";

        private void FrmEditar_Load(object sender, EventArgs e)
        {

            try
            {
                this.Text = "Editar Producto";
                txtgarantia.Enabled = false;
                txtporcentaje.Enabled = false;
                pictureloading.Visible = false;

                txtcodigo.Text = ListaParametros[0];
                IdProdOld = ListaParametros[0];
                txtnombre.Text = ListaParametros[1];
                txtfecha.Text  = ListaParametros[4];
                txtcantidad.Text = ListaParametros[3];
                txtprecio.Text = ListaParametros[2];

                string codigo = txtcodigo.Text;

                if (ListaParametros[5].ToUpper() == "NO")
                {
                    OptdescuentoSi.Checked = false;
                    OptDescuentoNo.Checked = true;
                    txtporcentaje.Enabled = false;
                }
                else
                {
                    OptdescuentoSi.Checked = true;
                    OptDescuentoNo.Checked = false;
                    txtporcentaje.Text = ListaParametros[5];
                }

                if (ListaParametros[6].ToUpper() == "NO")
                {

                    optAplicaSI.Checked = false;
                    OptaplicaNo.Checked= true;
                    txtgarantia.Enabled = false;
                }
                else
                {
                    OptdescuentoSi.Checked = true;
                    OptDescuentoNo.Checked = false;
                    txtgarantia.Text = ListaParametros[6];
                }

                if (ListaParametros[7] == "1")
                {
                    optprodexistenteSI.Checked = true;
                    optprodexistenteNo.Checked = false;
                }
                else
                {
                    optprodexistenteSI.Checked = false;
                    optprodexistenteNo.Checked = true;
                }

                if (ListaParametros[8] == "1")
                {

                    optactivoSi.Checked = true;
                    optactivoNo.Checked = false;
                }
                else
                {
                    optactivoSi.Checked = false;
                    optactivoNo.Checked = true;
                }

                if (Identificador == 2)
                {
                    txtestadoProd.Text = ListaParametros[9];
                }
                else
                {
                    txtestadoProd.Enabled = false;
                }

              
                Hilo = new Thread(delegate()
                    {
                        ResultadoHilo__ resultadoH = new ResultadoHilo__(Result);
                        string IDP = Modulos.Datos.GetProveedorByProducto(codigo);
                        object DatosTotalesResultantes = Modulos.Datos.GetProveedoresByID();
                        object DatoIdResultante = Modulos.Datos.GetProveedoresByID(IDP);
                        try
                        {
                            this.Invoke(resultadoH, new object[] { DatosTotalesResultantes, DatoIdResultante });
                        }
                        catch { }
                    });
                Hilo.Start();

                Controles.Add(txtcodigo);
                Controles.Add(txtnombre);
                Controles.Add(txtcantidad);
                Controles.Add(txtfecha);
                Controles.Add(txtprecio);
                Controles.Add(comboproveeedor);

            }
            catch { }
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        }

        private void Result(object args , object args1)
        {
            List<string> ListaResultante = (List<string>)args;
            List<string> ListaId = (List<string>)args1;

            comboproveeedor.Items.Clear();

            foreach (string valor in ListaResultante)
            {
                comboproveeedor.Items.Add(valor);
            }
            pictureloading.Enabled = false;
           
            try
            {
                comboproveeedor.Text = ListaId[0];
            }
            catch { }
        }

        private void optAplicaSI_CheckedChanged(object sender, EventArgs e)
        {
            txtgarantia.Enabled = true;
        }

        private void OptdescuentoSi_CheckedChanged(object sender, EventArgs e)
        {
            txtporcentaje.Enabled = true;
        }

        private void txtprecio_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtprecio_TextChanged(object sender, EventArgs e)
        {
            if (seguridad.IsDecimalNumber(txtprecio.Text) != true)
            {
                txtprecio.BackColor = Color.Red;
            }
            else
            {
                txtprecio.BackColor = Color.White;
            }
        }

        private void cmdsave_Click(object sender, EventArgs e)
        {
            if (OptdescuentoSi.Checked)
            {
                if (Controles.Contains(txtporcentaje) == false)
                    Controles.Add(txtporcentaje);
            }
            if (optAplicaSI.Checked)
            {
                if (Controles.Contains(txtgarantia) == false)
                    Controles.Add(txtgarantia);
            }

            seguridad.SetControles(Controles);

            if (seguridad.GetControlisEmpty() == true)
            {
                lbladvertencia.Text = "Algunos campos no son correctos";
                return;
            }

            if (seguridad.IsDecimalNumber(txtprecio.Text) != true)
            {
                txtprecio.BackColor = Color.Red;
                return;
            }
            else
            {
                txtprecio.BackColor = Color.White;
            }


            string SqlProducto = "";
            string SqlParamsProd = "";
            string codigo = txtcodigo.Text.ToUpper();
            int existente = 0;
            int activo = 0;
            string[] proveedor = comboproveeedor.Text.Split(',');
            string Descuento = "No";
            string Garantia = "No";
            var Fecha = seguridad.FormatoFecha(txtfecha.Text);

            string[] idsucursal = Datos.DatosSucursal.Split(',');

            string[] ConversionPrecio = new string[txtprecio.Text.Length];
            for (int k = 0; k < txtprecio.Text.Length; k++)
            {
                if (txtprecio.Text[k] == ',')
                    ConversionPrecio[k] = ".";
                else
                    ConversionPrecio[k] = txtprecio.Text[k].ToString();
            }

            if (optprodexistenteNo.Checked == false) existente = 1;
            else existente = 0;

            if (optactivoSi.Checked == true) activo = 1;
            else activo = 0;

            if (OptdescuentoSi.Checked == true)
                Descuento = txtporcentaje.Text;

            if (optAplicaSI.Checked == true)
                Garantia = txtgarantia.Text;


            switch (Identificador)
            {
                case 0:

                    SqlProducto = "update productos set idpnuevos ='" + codigo
                        + "',existente='" + existente
                        + "', activo='" + activo
                        + "', idproveedores='" + proveedor[0]
                        + "',idsucursal='" + idsucursal[1] 
                        + "' Where idpnuevos='" + IdProdOld + "'" ;

                    SqlParamsProd = "update pnuevos set "
                   + " idpnuevos='" + codigo + "', " 
                   + "nombre='" + txtnombre.Text
                   + "', fecha='" + Fecha
                   + "', precio='" + string.Join("", ConversionPrecio)
                   + "', cantidad=" + txtcantidad.Text
                   + ", descuentos='" + Descuento
                   + "', garantia='" + Garantia + "',idsucursal='" 
                   + idsucursal[1] + "' where idpnuevos='" + IdProdOld + "'" ;


                    break;
                case 1:

                    SqlProducto = "update productos set idpusados ='" + codigo
                        + "',existente='" + existente
                        + "', activo='" + activo
                        + "', idproveedores='" + proveedor[0]
                        + "',idsucursal='" + idsucursal[1]
                        + "' Where idpusados='" + IdProdOld + "'";

                    SqlParamsProd = "update pusados set "
                   + " idpusado='" + codigo + "', nombre='"
                   + txtnombre.Text
                   + "',fecha='" + Fecha
                   + "',estado='" + txtestadoProd.Text
                   + "',precio='" + string.Join("", ConversionPrecio)
                   + "' ,descuento='" + Descuento
                   + "',garantia='" + Garantia 
                   + "',cantidad=" + txtcantidad.Text 
                   + ",idsucursal='" + idsucursal[1] + "' where idpusado='" + IdProdOld + "'";

                    break;
            }


            Hilo = new Thread(delegate()
            {

                MySqlConnection Conn = new MySqlConnection();
                Conn = Conexion.GetConexion();
                MySqlTransaction Tran = null;
                try
                {

                    if (Conn.State == System.Data.ConnectionState.Closed)
                    {
                        Conn.Open();
                    }
                    else if (Conn.State == System.Data.ConnectionState.Executing)
                    {
                        Conn = new MySqlConnection(Conexion.GetDireccion());
                        Conn.Open();
                    }
                    MySqlCommand Cmd = new MySqlCommand(SqlProducto, Conn);
                    MySqlDataReader Reader = Cmd.ExecuteReader();
                    if (Reader.RecordsAffected >= 1)
                    {
                        Cmd.CommandText = SqlParamsProd;
                        Reader.Close();
                        Reader = Cmd.ExecuteReader();
                        if (Reader.RecordsAffected >= 1)
                        {
                            MessageBox.Show("Producto Editado con exito !!", "Exito",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            Conn.Close();
                            try
                            {

                                Principal.EncolarNotificacionByParams("producto Editado... Cod:("
                                    + codigo + " ) Nombre: "
                                    + txtnombre.Text, "2");

                            }
                            catch
                            {

                            }
                            return;
                        }
                    }


                }
                catch
                {
                    try
                    {
                        Tran.Rollback();
                    }
                    catch { }

                    MessageBox.Show("Ocurrio un error inesperado al momento de realiza la consulta\n\n Verifique su conexion al internet", "Opps!!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                    Conn.Close();
                    return;
                }


            });
            Hilo.Start();
            TprocesoGuardar.Enabled = true;
        }

        private void TprocesoGuardar_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Hilo.IsAlive != true)
                {
                    cmdsave.Enabled = true;
                    pictureloading.Visible = false;
                    TprocesoGuardar.Enabled = false;
                }
                else
                {
                    cmdsave.Enabled = false;
                    pictureloading.Visible = true;
                }
            }
            catch { }
        }
    }
}
