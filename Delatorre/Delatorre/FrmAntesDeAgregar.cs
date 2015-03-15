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
    public partial class FrmAntesDeAgregar : Form
    {
        public FrmAntesDeAgregar()
        {
            InitializeComponent();
        }

        private void cmdok_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                AddProdNuevo.BanderaTipoProd = 0;
            }
            else if (radioButton2.Checked == true)
            {
                AddProdNuevo.BanderaTipoProd = 1;
            }
            else
            {
                MessageBox.Show("Seleccione El producto al agregar sea nuevo o usado", "Seleccion",  MessageBoxButtons.OK , MessageBoxIcon.Information);
                return;
            }

            AddProdNuevo N = new AddProdNuevo();
            N.Show();

            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
