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

namespace Delatorre
{
    public partial class MostrarNotificaciones : Form
    {
        public MostrarNotificaciones()
        {
            InitializeComponent();
        }

        public static List<string[]> Listado = new List<string[]>();
        private List<string[]> listadoB = new List<string[]>();
        private ImageList ListaImagen = new ImageList();
        public static string SeguridadNotificaciones = null;
        private Thread H1 ,H2;
        private DataTable Templeados;
        private List<string[]> Lempleado = new List<string[]>();
        private List<string[]> Lsucursal = new List<string[]>();
        Modulos.Notificaciones Notificaciones = new Modulos.Notificaciones();


        private void cmdcerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MostrarNotificaciones_Load(object sender, EventArgs e)
        {
            this.Text = "Sistema de notificaciones DELATORRE";
            this.MaximizeBox = false;
            listanotificaciones.Scrollable = true;
            lblcargando.Text = "";
            ConvertirDatos();
            optact1.Checked = true;
        }

        private void ConvertirDatos()
        {
            try
            {
                ListaImagen = new ImageList();
                listanotificaciones.Items.Clear();
                for (int i = 0; i < Listado.Count; i++)
                {

                    string[] datos = Listado[i];

                    try
                    {
                        switch (int.Parse(datos[5]))
                        {
                            case 0:
                                ListaImagen.Images.Add(Delatorre.Properties.Resources.sesion);
                                break;
                            case 1:
                                ListaImagen.Images.Add(Delatorre.Properties.Resources.finsesion);
                                break;
                            case 2:
                                ListaImagen.Images.Add(Delatorre.Properties.Resources.venta);
                                break;
                            case 3:
                                ListaImagen.Images.Add(Delatorre.Properties.Resources.agotado);
                                break;
                            case 4:
                                ListaImagen.Images.Add(Delatorre.Properties.Resources.desactivado);
                                break;
                            case 5:
                                ListaImagen.Images.Add(Delatorre.Properties.Resources.noesistente);
                                break;
                            case 6:
                                ListaImagen.Images.Add(Delatorre.Properties.Resources.impresion);
                                break;
                        }


                    }
                    catch { }
                }

                ListaImagen.ImageSize = new System.Drawing.Size(24, 24);
                listanotificaciones.View = View.LargeIcon;
                listanotificaciones.LargeImageList = ListaImagen;
                listanotificaciones.StateImageList = ListaImagen;
                listanotificaciones.SmallImageList = ListaImagen;
                listanotificaciones.Alignment = ListViewAlignment.SnapToGrid;


                for (int k = 0; k < Listado.Count; k++)
                {
                    string[] Datos = Listado[k];
                    string Conversion = Datos[0] + " \n" 
                        + Datos[1] + " \n "
                        + Datos[2] + " \n " 
                        + Datos[3] + " \n " 
                        + Datos[4];

                    listanotificaciones.Items.Add(Conversion, k);

                }
            }
            catch { }
        }

        private delegate void LoadingDelegado();

        private void Loading()
        {
            if (Templeados != null || Templeados.Rows.Count >= 1)
            {
                try
                {
                    Lempleado = new List<string[]>();
                    ComboEmpleado.Items.Add("");
                    foreach (DataRow Row in Templeados.Rows)
                    {
                        var id = Row.Field<string>("idusuario", DataRowVersion.Default);
                        var n = Row.Field<string>("Nombre", DataRowVersion.Default);
                        var a = Row.Field<string>("Apellido", DataRowVersion.Default);
                        string[] V = new string[] { id, n, a };
                        ComboEmpleado.Items.Add(string.Join(" ", V));
                        Lempleado.Add(V);
                    }

                    ComboEmpleado.Text = "Seleccione";
                }
                catch { }
            }

            if (Lsucursal.Count >= 1)
            {
                try
                {
                    Combosucursal.Items.Add("");
                    for (int i = 0; i < Lsucursal.Count; i++)
                    {
                        string[] data = Lsucursal[i];
                        Combosucursal.Items.Add(string.Join(" ", data));
                    }
                    Combosucursal.Text = "Seleccione";
                }
                catch { }
            }
        }

        private void CargandoDatos()
        {
            H2 = new Thread(delegate()
                {
                    Templeados = new DataTable();
                    Lsucursal = new List<string[]>();
                    Templeados = Modulos.Datos.GetEmpleados(false);
                    Lsucursal = Modulos.Datos.GetAllSucursal();
                    LoadingDelegado delegadoLoading = new LoadingDelegado(Loading);
                    this.Invoke(delegadoLoading);
                });
            if (H2.ThreadState == ThreadState.Unstarted) H2.Start();
        }

        private delegate void WaitDelegado(int i);

        private void Wait(int z)
        {
            switch (z)
            {
                case 0:
                    lblcargando.Text = "Buscando notificaciones...";
                    break;
                case 1:
                    lblcargando.Text = "No hay resultados";
                    break;
                case 2:
                    lblcargando.Text = "Encontrado: " + (listadoB.Count - 1);
                    try
                    {
                        ListaImagen = new ImageList();
                        listafiltro.Items.Clear();
                        for (int i = 0; i < listadoB.Count; i++)
                        {

                            string[] datos = listadoB[i];

                            try
                            {
                                switch (int.Parse(datos[5]))
                                {
                                    case 0:
                                        ListaImagen.Images.Add(Delatorre.Properties.Resources.sesion);
                                        break;
                                    case 1:
                                        ListaImagen.Images.Add(Delatorre.Properties.Resources.finsesion);
                                        break;
                                    case 2:
                                        ListaImagen.Images.Add(Delatorre.Properties.Resources.venta);
                                        break;
                                    case 3:
                                        ListaImagen.Images.Add(Delatorre.Properties.Resources.agotado);
                                        break;
                                    case 4:
                                        ListaImagen.Images.Add(Delatorre.Properties.Resources.desactivado);
                                        break;
                                    case 5:
                                        ListaImagen.Images.Add(Delatorre.Properties.Resources.noesistente);
                                        break;
                                    case 6:
                                        ListaImagen.Images.Add(Delatorre.Properties.Resources.impresion);
                                        break;
                                }


                            }
                            catch { }
                        }

                        ListaImagen.ImageSize = new System.Drawing.Size(24, 24);
                        listafiltro.View = View.SmallIcon;
                        listafiltro.LargeImageList = ListaImagen;
                        listafiltro.StateImageList = ListaImagen;
                        listafiltro.SmallImageList = ListaImagen;
                        listafiltro.Alignment = ListViewAlignment.SnapToGrid;


                        for (int k = 0; k < listadoB.Count; k++)
                        {
                            string[] Datos = listadoB[k];
                            string Conversion = Datos[0] + " \n"
                                + Datos[1] + " \n "
                                + Datos[2] + " \n "
                                + Datos[3] + " \n "
                                + Datos[4];

                            listafiltro.Items.Add(Conversion, k);

                        }
                    }
                    catch { }
                    break;

            }
        }

        private void FiltrarDatosNotificaciones(int E)
        {
            Delatorre.Modulos.Seguridad seguridad = new Modulos.Seguridad();

            string[] sucursal = null;
            string[] empleado = null;

            try
            {
                sucursal = Lsucursal[Combosucursal.SelectedIndex-1];
            }
            catch { }

            try
            {
                empleado = Lempleado[ComboEmpleado.SelectedIndex-1];
            }
            catch { }

            string idsucursal = "";
            string fecha = seguridad.FormatoFecha(ComboFecha.Text);
            string fecha1 = seguridad.FormatoFecha(Combofecha1.Text);
            string idempleado = "";
                
            if(sucursal !=null)
                idsucursal = sucursal[0];
            if (empleado!= null)
                idempleado = empleado[0];


            H1 = new Thread(delegate()
                {
                    WaitDelegado wait = new WaitDelegado(Wait);
                    this.Invoke(wait, new object[] { 0 });
                    listadoB = Notificaciones.GetNotificaciones(idsucursal,fecha, fecha1,idempleado , E);
                    if (listadoB.Count >= 1)
                    {
                        this.Invoke(wait, new object[] { 2 });
                    }
                    else
                    {
                        this.Invoke(wait, new object[] { 1 });
                    }
                });
            if (H1.ThreadState == ThreadState.Unstarted) H1.Start();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    listanotificaciones.View = View.List;
                    break;
                case 1:
                    listanotificaciones.View = View.LargeIcon;
                    break;
                case 2:
                    listanotificaciones.View = View.SmallIcon;
                    break;
            }
        }

        private void MostrarNotificaciones_Layout(object sender, LayoutEventArgs e)
        {
          
        }

        private void Reflescar_Click(object sender, EventArgs e)
        {
            ConvertirDatos();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                CargandoDatos();
            }
        }

        private void cmdbuscar_Click(object sender, EventArgs e)
        {
            int E = 0;
            if (optact1.Checked == true) E = 1;
            else if (optact2.Checked == true) E = 2;
            else E = 3;
            FiltrarDatosNotificaciones(E);
        }


    }
}
