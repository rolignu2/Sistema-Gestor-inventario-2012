using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Delatorre.Modulos;

namespace Delatorre
{
    public partial class EditarSucursal : Form
    {
        public EditarSucursal()
        {
            InitializeComponent();
        }

        private System.Threading.Thread HiloDatosSucursal;
        private MySqlConnection Conn;
        private MySqlCommand CMD;
        private string SQL = "";
        private string ID = "";


        private delegate void Wait__( object DataResultante = null, bool Espera = true);
     
        private void Wait( object DataResultante = null , bool espera = true )
        {
            switch (espera)
            {
                case true:
                    ListaSucursal.Items.Clear();
                    ListaSucursal.Text = "Buscando en la base de datos... ";
                    ListaSucursal.Items.Add("Buscando en la base de datos...");
                    break;
                case false:
                    ListaSucursal.Items.Clear();
                    List<string[]> valores = new List<string[]>();
                    valores = (List<string[]>)DataResultante;
                    foreach (string[] M in valores)
                    {
                        string[] data = new string[M.Length];
                        for (int i = 0; i < data.Length; i++)
                        {
                            data[i] = M[i] + ",";
                        }
                        ListaSucursal.Items.Add(string.Concat(data));
                    }
                    break;
            }
        }

        private delegate void GetDataControls_(object[] valores);

        private void GetDataControls(object[] valores)
        {
            try
            {
                ID = valores[0].ToString();
                lblid.Text = ID;
                txtnombre.Text = valores[1].ToString();
                txtdir.Text = valores[2].ToString();
                txttel.Text = valores[3].ToString();
                txtgerente.Text = valores[4].ToString();
            }
            catch { }
        }

        private void EditarSucursal_Load(object sender, EventArgs e)
        {
            HiloDatosSucursal = new System.Threading.Thread(delegate()
            {
                GetSucursales();
            });
            HiloDatosSucursal.Start();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        }

        private void GetSucursales()
        {
            Wait__ W = new Wait__(Wait);
            this.Invoke(W, new object[] { null, true });
            object Obj = Datos.GetAllSucursal();
            this.Invoke(W, new object[] { Obj, false });
        }

        private object[] GetSucursalesDataobject(string id)
        {
            object[] Adata = null;

            MySqlConnection conn = new MySqlConnection(Conexion.GetDireccion());
            conn.Open();
            string Sql_ = "Select * from sucursal Where idsucursal='" + id + "'";
            MySqlDataAdapter Adapter = new MySqlDataAdapter(Sql_, conn);
            DataSet ds = new DataSet();
            Adapter.Fill(ds);
            DataTable tab = new DataTable();
            tab = ds.Tables[0];
           
            foreach(DataRow row in tab.Rows)
            {
                Adata = row.ItemArray;
            }

            return Adata;
        }

        private void BuscarDato(string cadena)
        {
            
            for (int i = 0; i < ListaSucursal.Items.Count; i++)
            {
                string[] Posibles = ListaSucursal.Items[i].ToString().Split(',');
                for (int k = 0; k < Posibles.Length; k++)
                {
                    if (Posibles[k].ToUpper().Equals(cadena.ToUpper()))
                    {
                        ListaSucursal.SelectedIndex = i;
                        return;
                    }
                }
            }
        }

        private void txtbuscador_TextChanged(object sender, EventArgs e)
        {
            BuscarDato(txtbuscador.Text);
        }

        private void ListaSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ListaSucursal.SelectedIndex;


            System.Threading.Thread HiloData = new System.Threading.Thread(delegate()
            {
                try
                {
                    string[] id = ListaSucursal.Items[index].ToString().Split(',');
                    object[] valores = GetSucursalesDataobject(id[0]);
                    GetDataControls_ GC = new GetDataControls_(GetDataControls);
                    this.Invoke(GC, new object[] { valores });
                }
                catch { }
            });

            if (HiloData.ThreadState == System.Threading.ThreadState.Running)
                HiloData.Abort();
            else
                HiloData.Start();
        }

        private void cmdeliminar_Click(object sender, EventArgs e)
        {
            DialogResult D = MessageBox.Show("Desea eliminar la sucurusal "
                + ListaSucursal.SelectedItem.ToString(), "Eliminar",  MessageBoxButtons.YesNo , MessageBoxIcon.Question);
            if (D == System.Windows.Forms.DialogResult.Yes)
            {
                System.Threading.Thread Heliminar = new System.Threading.Thread(delegate()
                {
                    try
                    {
                        SQL = "Delete from sucursal where idsucursal='" + ID + "'";
                        Conn = new MySqlConnection(Conexion.GetDireccion());
                        Conn.Open();
                        CMD = new MySqlCommand(SQL, Conn);
                        MySqlDataReader Dr = CMD.ExecuteReader();
                        if (Dr.RecordsAffected >= 1)
                        {
                            MessageBox.Show("Sucursal eliminada con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Conn.Close();
                            HiloDatosSucursal = new System.Threading.Thread(delegate()
                            {
                                GetSucursales();
                            });
                            HiloDatosSucursal.Start();
                            return;
                        }
                    }
                    catch {
                        MessageBox.Show("Hubo un problema al momento de eliminar", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Conn.Close();
                    }
                });
                if (!(Heliminar.ThreadState == System.Threading.ThreadState.Running))
                    Heliminar.Start();
                else
                    Heliminar.Abort();
            }
        }

        private void cmdeditar_Click(object sender, EventArgs e)
        {
             System.Threading.Thread HiloU= new System.Threading.Thread(delegate()
                {

                    try
                    {
                        SQL = "update sucursal set Nombre='" 
                            + txtnombre.Text + "' , Direccion='" + txtdir.Text + "',Telefono='"
                            + txttel.Text + "', Gerente='" + txtgerente.Text + "' Where idsucursal='" + ID + "'" ;
                        Conn = new MySqlConnection(Conexion.GetDireccion());
                        Conn.Open();
                        CMD = new MySqlCommand(SQL, Conn);
                        MySqlDataReader Dr = CMD.ExecuteReader();
                        if (Dr.RecordsAffected >= 1)
                        {
                            MessageBox.Show("Sucursal editada con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Conn.Close();
                            HiloDatosSucursal = new System.Threading.Thread(delegate()
                            {
                                GetSucursales();
                            });
                            HiloDatosSucursal.Start();
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Hubo un problema al momento de editar", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Conn.Close();
                    }

                });
             HiloU.Start();
        }

        private void linkreflesh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HiloDatosSucursal = new System.Threading.Thread(delegate()
            {
                GetSucursales();
            });
            HiloDatosSucursal.Start();
        }
    }
}
