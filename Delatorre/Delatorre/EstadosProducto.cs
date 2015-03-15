using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Delatorre
{
    public partial class EstadosProducto : Form
    {
        public EstadosProducto()
        {
            InitializeComponent();
        }

        public static string CadenaEstadoProducto = "";

        private void EstadosProducto_Load(object sender, EventArgs e)
        {
            this.Text = "Estado del producto";
            richestado.Text = CadenaEstadoProducto;
        }
    }
}
