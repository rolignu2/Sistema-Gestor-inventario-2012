using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delatorre.Modulos;

namespace Delatorre
{
    public partial class Permisos : Form
    {
        public Permisos()
        {
            InitializeComponent();
        }

        public static Boolean Acceso = false;

        private void Permisos_Load(object sender, EventArgs e)
        {
            Acceso = false;
            txtpass.PasswordChar = '*';
        }

        private void cmdacceso_Click(object sender, EventArgs e)
        {
            Acceso = Datos.GetPermision(Modulos.Encriptador.encriptar(txtuser.Text), Modulos.Encriptador.encriptar(txtpass.Text));
            if (Acceso == false)
            {
                MessageBox.Show("Acceso Denegado");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

   
    }
}
