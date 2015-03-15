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
    public partial class SubPrincipal : Form
    {
        public SubPrincipal()
        {
            InitializeComponent();
        }

        private void SubPrincipal_Load(object sender, EventArgs e)
        {
            this.Text = "Seleccion de sucursal";
            GetSucursal();
        }


        private MySqlDataAdapter adapter;
        private DataSet ds;
        private string SQL = null;

        private void GetSucursal()
        {
            SQL = "Select * from sucursal";
            adapter = new MySqlDataAdapter(SQL, Modulos.Conexion.GetConexion());
            ds = new DataSet();
            adapter.Fill(ds);
            DataTable tabla = new DataTable();
            tabla = ds.Tables[0];
            combosucursal.Items.Clear();
            foreach ( DataRow filas in tabla.Rows)
            {
                combosucursal.Items.Add(filas.Field<string>("Nombre", DataRowVersion.Default) + 
                    "," + filas.Field<string>("idsucursal", DataRowVersion.Default) + "," +
                    filas.Field<string>("Gerente", DataRowVersion.Default));
                if (combosucursal.Text == "")
                    combosucursal.Text = filas.Field<string>("Nombre", DataRowVersion.Default) +
                    "," + filas.Field<string>("idsucursal", DataRowVersion.Default) + "," +
                    filas.Field<string>("Gerente", DataRowVersion.Default);
            }
        
        }

        private void combosucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            Modulos.Datos.DatosSucursal = combosucursal.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Principal p = new Principal();
            p.Show();
            this.Close();
        }
    }
}
