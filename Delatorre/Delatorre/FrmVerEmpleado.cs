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
using Delatorre;

namespace Delatorre
{
    public partial class FrmVerEmpleado : Form
    {
        public FrmVerEmpleado()
        {
            InitializeComponent();
        }

        private Thread Hilo , Hilo1;
        private DataTable DTEmpleados = null;
        private List<object> ListaEmpleados;

        private delegate void Espera(int Estado);

        private void Despera(int estado)
        {
            switch (estado)
            {
                case 1:
                    comboBox1.Text = "Cargando datos de los empleados espere";
                    break;
                case 2:
                    if(DTEmpleados!= null)
                    {
                        ListaEmpleados = new List<object>();
                        foreach (DataRow Fila in DTEmpleados.Rows)
                        {
                            var n = Fila.Field<string>("Nombre", DataRowVersion.Current);
                            var a = Fila.Field<string>("Apellido", DataRowVersion.Current);
                            comboBox1.Items.Add(n + " " + a);
                            ListaEmpleados.Add(Fila.ItemArray);
                        }
                        comboBox1.Text = "Seleccione un empleado";
                        break;
                    }
                    comboBox1.Text = "Error al cargar empleados";
                    break;
                default:
                    break;
            }

        }

        private delegate void GenerarDatosDelegado(string[] datos);

        private void GenerarDatos(string[] datos)
        {
            try{
                txtn.Text = datos[2];
                txta.Text = datos[3];
                txtd.Text = datos[4];
                txts.Text = datos[5];
                txtu.Text = datos[1];
                txtsu.Text = datos[6];
                txtcar.Text = datos[7];
                if (int.Parse(datos[8]) == 1)
                    txtact.Text = "Activo";
                else
                    txtact.Text = "Inactivo";
            }
            catch{}
        }

        private delegate void Cargando(bool F);

        private void cargando(bool F)
        {
            switch (F)
            {
                case true:
                    piccargandoCliente.Visible = true;
                    break;
                case false:
                    piccargandoCliente.Visible = false;
                    break;
            }
        }

        private void GetDatos()
        {
            int index = comboBox1.SelectedIndex;
            Hilo1 = new Thread(delegate()
                {
                    try
                    {
                        Cargando c = new Cargando(cargando);
                        this.Invoke(c, new object[] { true });
                        object[] valores = (object[])ListaEmpleados[index];
                        string[] Vconversion = Array.ConvertAll(valores, p => (p ?? string.Empty).ToString());
                        string usuario = Vconversion[1];
                        string sucursal = Vconversion[6];
                        string sql = "select User_login.username as user, sucursal.Nombre as sucursal from empleados" 
                            + " inner join User_login on User_login.iduser = empleados.idusuario " 
                            + " inner join sucursal on empleados.idsucursal = sucursal.idsucursal "
                            + " where empleados.idusuario like '"
                            + usuario + "'";

                        MySqlConnection conn = new MySqlConnection(Modulos.Conexion.GetDireccion());
                        if (conn.State == ConnectionState.Closed) conn.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        DataTable tabla = ds.Tables[0];
                        foreach (DataRow Fila in tabla.Rows)
                        {
                            string u = Fila.Field<string>("user", DataRowVersion.Current);
                            string s = Fila.Field<string>("sucursal", DataRowVersion.Current);
                            Vconversion[1] = Modulos.Encriptador.desencriptar(u);
                            Vconversion[6] = s;
                        }
                        GenerarDatosDelegado delegadoDatos = new GenerarDatosDelegado(GenerarDatos);
                        this.Invoke(delegadoDatos, new object[] { Vconversion });
                        this.Invoke(c, new object[] { false});
                    }
                    catch { }
                });
            if (Hilo1.ThreadState != ThreadState.Running
                || Hilo1.ThreadState != ThreadState.WaitSleepJoin) 
                Hilo1.Start();
        }

        private void FrmVerEmpleado_Load(object sender, EventArgs e)
        {
            this.Text = "Vista previa Empleado";
            this.MaximizeBox = false;
            piccargandoCliente.Visible = false;

            Hilo = new Thread(delegate()
            {
                Thread.Sleep(100);
                Espera espera = new Espera(Despera);
                this.Invoke(espera, new object[] { 1 });
                DTEmpleados = Modulos.Datos.GetEmpleados(false);
                this.Invoke(espera, new object[] { 2 });
            });
            Hilo.Start();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDatos();
        }
    }
}
