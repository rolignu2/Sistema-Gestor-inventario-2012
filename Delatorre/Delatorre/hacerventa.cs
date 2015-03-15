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
    public partial class hacerventa : Form
    {

        public static List<string> DatosProductos = new List<string>();

        public hacerventa()
        {
            InitializeComponent();
        }

        private void hacerventa_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        }

        private void Hacerventa()
        {
            if (DatosProductos.Contains("..........") || DatosProductos.Count == 0)
            {
                MessageBox.Show("No existe producto para agregar al carrito", "OPPS!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DatosProductos.Clear();
                return;
            }
            if (txtcantidad.Text == "")
            {
                MessageBox.Show("Favor elija una cantidad ", "OPPS!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //DatosProductos.Clear();
                return;
            }

            if ((Convert.ToInt32(DatosProductos[3]) < Convert.ToInt32(txtcantidad.Text)))
            {
                MessageBox.Show("Producto insuficiente para esta venta ", "OPPS!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //DatosProductos.Clear();
                return;
            }

            try
            {

                decimal ValorResultanteProductos = 0.0M;
                ValorResultanteProductos = (Convert.ToDecimal(DatosProductos[2]) * Convert.ToInt32(txtcantidad.Text));
                decimal salida_descuento = 0.0M;
                bool descuento = decimal.TryParse(DatosProductos[4], out salida_descuento);
                if (descuento)
                {
                    decimal SalidaDescuento = ((salida_descuento * ValorResultanteProductos) / 100);
                    ValorResultanteProductos -= SalidaDescuento;
                    DatosProductos[2] = ValorResultanteProductos.ToString();

                }
                else
                {
                    DatosProductos[2] = ValorResultanteProductos.ToString();
                }

                DatosProductos[3] = txtcantidad.Text;

                string[] valores = new string[6];
                for (int i = 0; i < DatosProductos.Count; i++)
                {
                    valores[i] = DatosProductos[i];
                }

                Principal.ListaProductosCarrito.Add(valores);
                DatosProductos.Clear();
                Principal.cambiocarrito = true;
                this.Close();
            }
            catch { DatosProductos.Clear(); }
        }

        private void cmdEnviar_Click(object sender, EventArgs e)
        {

            Hacerventa();
           
        }

        private void hacerventa_Activated(object sender, EventArgs e)
        {
            txtcantidad.Focus();
        }

        private void txtcantidad_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter) Hacerventa();
        }

    
    }
}
