using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using Delatorre.Modulos;
using MySql.Data.MySqlClient;
using System.Threading;


namespace Delatorre
{
    public partial class AddProdNuevo : Form
    {

        Seguridad seguridad = new Seguridad();
        List<Control> Controles = new List<Control>();
        List<string> Listado_Proveedor = new List<string>();
        Random RND = new Random(DateTime.Now.Millisecond);
        Thread Hilo;

        public AddProdNuevo()
        {
            InitializeComponent();
        }

        public static int BanderaTipoProd = 0;

        private void cmdexit_Click(object sender, EventArgs e)
        {
            this.Close();
          
        }

        private void AddProdNuevo_Load(object sender, EventArgs e)
        {
            pictureloading.Visible = false;

            txtfecha.Format = DateTimePickerFormat.Custom;
            txtfecha.CustomFormat = "yyyy-MM-dd";
            this.Text = "Agrega un producto nuevo o usado";
            Controles.Add(txtcodigo);
            Controles.Add(txtnombre);
            Controles.Add(txtcantidad);
            Controles.Add(txtfecha);
            Controles.Add(txtprecio);
            Controles.Add(comboproveeedor);

            txtgarantia.Enabled = false;
            txtporcentaje.Enabled = false;

            /* codigo proveedor  */
            Listado_Proveedor = Datos.GetProveedoresByID();
            comboproveeedor.Items.Clear();
            for (int i = 0; i < Listado_Proveedor.Count; i++)
                comboproveeedor.Items.Add(Listado_Proveedor[i]);
            /*fin codigo proveedor */

            if (BanderaTipoProd == 1)
            {
                GroupProdusado.Enabled = true;
            }
            else
            {
                GroupProdusado.Enabled = false;
            }


            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        }

        private void cmdsave_Click(object sender, EventArgs e)
        {

            if (OptdescuentoSi.Checked) { 
                if(Controles.Contains(txtporcentaje) ==false)
                         Controles.Add(txtporcentaje); 
            }
            if (optAplicaSI.Checked){
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
            string IdProd = "PROD" + RND.Next(0, 9) + RND.Next(0, 99) + codigo.Length.ToString();
            int existente = 0;
            int activo = 0;
            string[] proveedor = comboproveeedor.Text.Split(',');
            string Descuento = "No";
            string Garantia = "No";
            var Fecha = txtfecha.Text;

            string[] idsucursal = Datos.DatosSucursal.Split(',');


            if (optprodexistenteNo.Checked == false) existente = 1;
            else existente = 0;

            if (optactivoSi.Checked == true) activo = 1;
            else activo = 0;

            if (OptdescuentoSi.Checked == true)
                Descuento = txtporcentaje.Text;
            
            if (optAplicaSI.Checked == true)
                Garantia = txtgarantia.Text;


            switch (BanderaTipoProd)
            {
                case 0:

                if (seguridad.ExisteDatosEnBdd("Select * from productos where idpnuevos = '" + codigo + "' and idsucursal ='" + idsucursal[1] + "'") == true)
                {
                      MessageBox.Show("Este codigo de producto ya existe. ", "Opps!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                      return;
                }

                SqlProducto = "insert into productos (idproductos ,idpusados , idpnuevos , existente , activo , idproveedores , idsucursal)" 
                +" values('"
                + IdProd 
                + "','NULL' ,'" 
                + codigo 
                + "'," 
                + existente
                + ","
                + activo
                + ",'" 
                + proveedor[0] + "','" +
                 idsucursal[1] + "')" ;

                 SqlParamsProd = "insert into pnuevos(idpnuevos , nombre , fecha , precio , cantidad , descuentos , garantia , idsucursal) values ('"
                + codigo + "','"
                + txtnombre.Text
                + "','" + Fecha
                + "'," + txtprecio.Text
                + "," + txtcantidad.Text
                + ",'" + Descuento
                + "','" + Garantia + "','" +
                 idsucursal[1] + "')";


                    break;
                case 1:
                    if (seguridad.ExisteDatosEnBdd("Select * from productos where idpusados = '" + codigo + "' and idsucursal ='" + idsucursal[1] + "'") == true)
                    {
                        MessageBox.Show("Este codigo de producto ya existe. ", "Opps!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }


                SqlProducto = "insert into productos (idproductos ,idpusados , idpnuevos , existente , activo , idproveedores , idsucursal)" 
                +" values('"
                + IdProd 
                + "','" 
                + codigo 
                + "','NULL"
                + "'," 
                + existente
                + ","
                + activo
                + ",'"
                + proveedor[0] + "','" +
                 idsucursal[1] + "')";

                 SqlParamsProd = "insert into pusados(idpusado , nombre , fecha, estado , precio , descuento , garantia , cantidad , idsucursal) values ('"
                + codigo + "','"
                + txtnombre.Text
                + "','" + Fecha
                + "','" + txtestadoProd.Text
                + "'," + txtprecio.Text
                + ",'" + Descuento
                + "','" + Garantia  + "'," + txtcantidad.Text +   ",'" +
                 idsucursal[1]+ "')";

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
                                MessageBox.Show("Producto registrado con exito !!", "Exito",
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Information);
                                Conn.Close();
                                try
                                {
                                   
                                        Principal.EncolarNotificacionByParams("producto agregado Cod:("
                                            + codigo + " ) Nombre: "
                                            + txtnombre.Text, "2");
                               
                                }
                                catch {
                                 
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

        private void cmdbuscar_Click(object sender, EventArgs e)
        {

            string valor_buscar = txtbuscar.Text;
            for (int i = 0; i < Listado_Proveedor.Count; i++)
            {
                var Resultado = Listado_Proveedor[i].IndexOf(valor_buscar);
                if (Resultado != -1)
                {
                    comboproveeedor.Text = Listado_Proveedor[i];
                    return;
                }
            }
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            seguridad.EliminarCampos(this.Controls);
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

        private void txtcodigo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
                    }


       
    }
}
