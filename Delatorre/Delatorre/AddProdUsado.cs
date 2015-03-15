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
    public partial class AddProdUsado : Form
    {
        public AddProdUsado()
        {
            InitializeComponent();
        }

        private void AddProdUsado_Load(object sender, EventArgs e)
        {
            this.Text = "Producto usado ...";
        }

        private void cmdexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
