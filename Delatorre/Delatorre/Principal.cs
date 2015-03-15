using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delatorre.Modulos;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
//using System.Diagnostics;


namespace Delatorre
{
    public partial class Principal : Form
    {
        public Principal() :base()
        {
            InitializeComponent();
        }

        #region Variables
        string[] datossucursal;
        string[] datosusuarios;
        string[] datosempleado;

        string SQL = null;

        string ParamBorrar = "";

        /*1 = eliminar nuevo ; 2 = eliminar usado */
        int PatronEliminar = 0;
        

        Boolean SesionIniciada = false;
        Notificaciones Notificacion = new Notificaciones();
        Sugestion Sugestion;

        static Queue<string[]> EncolarNotificacion = new Queue<string[]>();

        public static List<string[]> ListaProductosCarrito = new List<string[]>();

        List<string[]> ListaSucursales = new List<string[]>();
        List<object> ListaClientes = new List<object>();
       
        object[] Datoscliente = null;
        int RowCliente = 0;

        CarritoDeCompra CarritoCompra;

        Dictionary<int, object> ListaClienteByKey = new Dictionary<int, object>();

        MySqlDataAdapter adapter;
        DataTable dt;

        Task __TareaLoading;

        Mutex mutex = new Mutex();
        Mutex mutex1 = new Mutex();

        Thread HiloGrilla;
        Thread HiloEliminar;
        Thread HiloSesion;
        Thread HiloSucursal;
        Thread HiloActividades;

        Semaphore S1, S4 = new Semaphore(1, 1);

        MotorBusqueda Busqueda = new MotorBusqueda();
        Seguridad Seguridad = new Seguridad();

        ToolTip Tip = new ToolTip();

        Herramientas LoadingGrilla = new Herramientas();
        Herramientas LoadingNotificacion = new Herramientas();

        DataGridViewPrinter MyDataGridViewPrinter;

        Actividades actividades = new Actividades();
        List<Modulos.Factura> Listafactura = new List<Factura>();
        List<string> ParametrosFactura = new List<string>();



#endregion

        #region Funciones

        private string GetSucursalProducto(string Id)
        {
            if (ListaSucursales == null) return null;

            for (int i = 0; i < ListaSucursales.Count; i++)
            {
                string[] valores = ListaSucursales[i];
                if (valores[0] == Id)
                {
                    return valores[1];
                }
            }

            return null;
        }

        private bool ActivarTodasLasSucursales()
        {
            if (RadioSucuEsta.Checked == true) return false;
            else return true;
        }

        private void PrivilegiosEstados(string status)
        {
            try
            {
                if (status == "user" || status == "user\t")
                {
                    cmderase.Enabled = false;
                    cmdedit.Enabled = false;
                    registrarEmpleadoToolStripMenuItem.Enabled = false;
                    usuariosConectadosToolStripMenuItem.Enabled = false;
                    editarF2ToolStripMenuItem.Enabled = false;
                    usuariosConectadosToolStripMenuItem.Enabled = false;
                    opcionesAvanzadasToolStripMenuItem.Enabled = false;
                    registrarSucursalToolStripMenuItem1.Enabled = false;
                    registrarSucursalToolStripMenuItem.Enabled = false;
                    registrarUsuarioToolStripMenuItem.Enabled = false;
                    proveedoresToolStripMenuItem.Enabled = false;
                    picsesionusuario.Image = Delatorre.Properties.Resources.admin_sesion1;
                }
                else if (status == "admin" || status == "admin\t")
                {
                    cmderase.Enabled = true;
                    cmdedit.Enabled = true;
                    registrarEmpleadoToolStripMenuItem.Visible = true;
                    usuariosConectadosToolStripMenuItem.Visible = true;
                    usuariosConectadosToolStripMenuItem.Visible = true;
                    editarF2ToolStripMenuItem.Enabled = true;
                    registrarSucursalToolStripMenuItem1.Visible = true;
                    registrarSucursalToolStripMenuItem.Visible = true;
                    registrarUsuarioToolStripMenuItem.Visible = true;
                    proveedoresToolStripMenuItem.Visible = true;
                    opcionesAvanzadasToolStripMenuItem.Enabled = false;
                    picsesionusuario.Image = Delatorre.Properties.Resources.admin_sesion;
                }
                else if (status == "root" || status == "root\t")
                {
                    cmderase.Enabled = true;
                    cmdedit.Enabled = true;
                    registrarEmpleadoToolStripMenuItem.Visible = true;
                    usuariosConectadosToolStripMenuItem.Visible = true;
                    usuariosConectadosToolStripMenuItem.Visible = true;
                    editarF2ToolStripMenuItem.Enabled = true;
                    registrarSucursalToolStripMenuItem1.Visible = true;
                    registrarSucursalToolStripMenuItem.Visible = true;
                    registrarUsuarioToolStripMenuItem.Visible = true;
                    proveedoresToolStripMenuItem.Visible = true;
                    opcionesAvanzadasToolStripMenuItem.Enabled = true;
                    picsesionusuario.Image = Delatorre.Properties.Resources.admin_sesion;

                }
            }
            catch
            {

            }
        }

        private void ClsCarritoCompra()
        {
            ListaProductosCarrito = new List<string[]>();
            CarritoCompra.ObtenerDatosEngrilla(ListaProductosCarrito);
            Datoscliente = null;
            lblCtotal.Text = "0.0";
            GetdatosClientes();
            cambiocarrito = true;
            comboCbusqueda.Text = "";
        }

        private void DatosEmpleados()
        {
            __TareaLoading = new Task(delegate()
            {
                try
                {
                    SesionIniciada = Modulos.Datos.IniciarSesion();
                    datosempleado = Modulos.Datos.GeTdatosEmpleadosByID().Split(',');
                    if (SesionIniciada == true)
                    {
                        lblsesion.Text = DateTime.Now.ToShortDateString();
                    }
                    else
                    {
                        lblsesion.Text = "Sesion corrupta";
                    }

                    lblcodemp.Text = datosempleado[0];
                    lblnombre.Text = datosempleado[1];
                    lblapellido.Text = datosempleado[2];
                    lblcargo.Text = datosempleado[3];
                }
                catch { }
            });
            __TareaLoading.Start();

            EncolarNotificacionByParams("Sesion Iniciada", "0");

        }

        private void GetActividades(string id, string fecha = null)
        {
            HiloActividades = new Thread(delegate()
            {
                MySqlConnection conn1 = new MySqlConnection(Conexion.GetDireccion());
                MySqlDataAdapter Madapter;
                try
                {
                    conn1.Open();
                    string SqlAct = "";

                    if (fecha == null)
                        SqlAct = "SELECT actividad as Actividad , fecha as Fecha , hora as Hora FROM actividades where idempleado='"
                            + id + "' and fecha='" + Seguridad.FormatoFecha(DateTime.Today.ToShortDateString()) + "'";
                    else
                        SqlAct = "SELECT actividad as Actividad , fecha as Fecha , hora as Hora FROM actividades where idempleado='"
                            + id + "'and fecha='" + Seguridad.FormatoFecha(fecha) + "'";

                    Madapter = new MySqlDataAdapter(SqlAct, conn1);
                    DataTable DT = new DataTable();
                    Madapter.Fill(DT);
                    GetResultActividades_ Result = new GetResultActividades_(GetResultActividades);
                    this.Invoke(Result, new object[] { DT });
                    conn1.Close();
                }
                catch { }
            });
            if (HiloActividades.ThreadState == ThreadState.Running)
                HiloActividades.Abort();
            else
                HiloActividades.Start();
        }

        private delegate void GetResultActividades_(DataTable DT);

        Label L = new Label();
        private void GetResultActividades(DataTable DT)
        {

            if (DT != null && DT.Rows.Count != 0)
            {
                if (grupoactividades.Controls.Contains(L))
                {
                    grupoactividades.Controls.Remove(L);
                }
                grillaActividades.DataSource = DT;
                grillaActividades.Visible = true;
            }
            else
            {
                grillaActividades.Visible = false;

                if (!grupoactividades.Controls.Contains(L))
                {
                    L.ForeColor = Color.White;
                    L.Font = new Font("Times New Roman", 12.0f, FontStyle.Bold);
                    L.Location = grillaActividades.Location;
                    L.Visible = true;
                    L.AutoSize = true;
                    L.TextAlign = ContentAlignment.TopCenter;
                    L.Text = "NO EXISTEN ACTIVIDADES";
                    grupoactividades.Controls.Add(L);
                }
            }
        }

        public static void EncolarNotificacionByParams(string N, string Prioridad)
        {
            string[] Notificacion = { N, Prioridad };
            EncolarNotificacion.Enqueue(Notificacion);
        }

        private void GetDataGrilla(int producto, string ParamSql = null)
        {



            grillaproductos.DataSource = null;

            if (HiloGrilla != null)
                if (HiloGrilla.ThreadState == ThreadState.WaitSleepJoin || HiloGrilla.ThreadState == ThreadState.Running)
                    return;
         /*   try
            {
                if (HiloGrilla.IsAlive)
                {
                    HiloGrilla.Abort();
                    TiempoEjecucion.Enabled = false;
                }
            }
            catch { }*/

            HiloGrilla = new Thread(delegate()
            {
                S1.WaitOne();
                try
                {
                    MySqlConnection conn = new MySqlConnection(Conexion.GetDireccion());
                    if (conn.State != ConnectionState.Open) conn.Open(); 
                    switch (producto)
                    {
                        case 0:
                            if (ParamSql != null)
                                SQL = ParamSql;
                            else
                                SQL = "SELECT pusados.idpusado as CodigoProd_Usado , pusados.nombre as Producto_Usado , pnuevos.idpnuevos as CodigoProd_Nuevo , pnuevos.nombre as Producto_Nuevo , productos.existente as Existentes , productos.activo as Activos , productos.idsucursal as ids  FROM productos LEFT OUTER JOIN pnuevos ON productos.idpnuevos = pnuevos.idpnuevos INNER JOIN pusados ON productos.idpusados = pusados.idpusado";
                            adapter = new MySqlDataAdapter(SQL, conn);
                            dt = new DataTable();
                            adapter.Fill(dt);
                            break;
                        case 1:
                            if (ParamSql != null)
                                SQL = ParamSql;
                            else
                                SQL = "SELECT  pnuevos.idpnuevos as Codigo , pnuevos.nombre as Nombre, pnuevos.precio as Precio, pnuevos.cantidad as Cantidad, pnuevos.fecha as Fecha, pnuevos.descuentos as Descuentos, pnuevos.garantia as Garantia, productos.existente as Existente, productos.activo as Activo , pnuevos.idsucursal as ids  FROM productos INNER JOIN pnuevos ON productos.idpnuevos = pnuevos.idpnuevos";
                            adapter = new MySqlDataAdapter(SQL, conn);
                            dt = new DataTable();
                            adapter.Fill(dt);
                            break;
                        case 2:
                            if (ParamSql != null)
                                SQL = ParamSql;
                            else
                                SQL = "SELECT  pusados.idpusado as Codigo , pusados.nombre as Nombre, pusados.precio as Precio, pusados.cantidad as Cantidad, pusados.fecha as Fecha, pusados.descuento as Descuentos, pusados.garantia as Garantia, productos.existente as Existente, productos.activo as Activo , pusados.estado as Estado , productos.idsucursal as ids  FROM productos INNER JOIN pusados ON productos.idpusados = pusados.idpusado";

                            adapter = new MySqlDataAdapter(SQL, conn);
                            dt = new DataTable();
                            adapter.Fill(dt);
                            break;
                    }

                    conn.Close();
                    S1.Release();
                }
                catch (MySqlException ex)
                {
                    Errores.SetErrores(ex.Message);
                    S1.Release();
                }
                catch(Exception et)
                {
                    Errores.SetErrores(et.Message);
                    MessageBox.Show("Ocurrio un problema al momento de enviar solicitud al servidor", "Opps", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    S1.Release();
                }
            });
            if (HiloGrilla.ThreadState != ThreadState.WaitSleepJoin || HiloGrilla.ThreadState != ThreadState.Running)
            {
                HiloGrilla.Start();
                TiempoEjecucion.Enabled = true;
            }
        }

        private delegate void SubProcesoGrilla();

        private void GetDatosProductos(int i)
        {
            try
            {
                linkcodigo.Text = grillaproductos[0, i].Value.ToString();
                linknombre.Text = grillaproductos[1, i].Value.ToString();
                linkprecio.Text = grillaproductos[2, i].Value.ToString();
                linkcantidad.Text = grillaproductos[3, i].Value.ToString();
                linkfecha.Text = grillaproductos[4, i].Value.ToString();
                linkdescuentos.Text = grillaproductos[5, i].Value.ToString();
                linkgarantia.Text = grillaproductos[6, i].Value.ToString() + " Mes(es)";

                if (grillaproductos[7, i].Value.ToString() == "1")
                    linkexistente.Text = "Si";
                else
                    linkexistente.Text = "No";

                if (grillaproductos[8, i].Value.ToString() == "1")
                    linkactivo.Text = "Si";
                else
                    linkactivo.Text = "No";

                if (combobusqueda.SelectedIndex == 2)
                {
                    linkestado.Text = grillaproductos[9, i].Value.ToString();
                    FrmEditar.Identificador = 1;
                }
                else
                {
                    linkestado.Text = "Nuevo";
                    FrmEditar.Identificador = 0;
                }

                try
                {
                    string id = grillaproductos["ids", i].Value.ToString();
                    string sucursalObtenida = GetSucursalProducto(id.ToString());
                    
                    if (sucursalObtenida != lblsucursal.Text)
                        cmdedit.Enabled = false;
                    else
                        cmdedit.Enabled = true;

                    linksucursalProd.Text = sucursalObtenida;
                }
                catch { 
                    linksucursalProd.Text = lblsucursal.Text;
 
                }

                ParamBorrar = linkcodigo.Text;

                if (FrmEditar.ListaParametros.Count >= 1) FrmEditar.ListaParametros.Clear();
                for (int iteracion = 0; iteracion < grillaproductos.ColumnCount; iteracion++)
                {
                    FrmEditar.ListaParametros.Add(grillaproductos[iteracion, i].Value.ToString());
                }

                FrmVerProveedor.IdProducto = linkcodigo.Text;

            }
            catch { }
        }



        private delegate void RespuestaSpellCheck(string palabra, int estado);

        private void GetSpell(string palabra, int estado)
        {

            switch (estado)
            {
                case 1:
                    lbldidyoumean.Visible = true;
                    linkDidyoumean.Visible = true;
                    linkDidyoumean.Text = palabra;
                    break;
                case 2:
                    lbldidyoumean.Visible = false;
                    linkDidyoumean.Visible = false;
                    break;
            }

        }

        private Thread HiloSpell;

        private void Agregar__() { FrmAntesDeAgregar add = new FrmAntesDeAgregar(); add.Show(); }

        private void Reflescar()
        {
            string sql_param = null;
            switch (combobusqueda.SelectedIndex)
            {
                case 1:
                    sql_param = "SELECT  pnuevos.idpnuevos as Codigo , pnuevos.nombre as Nombre, pnuevos.precio as Precio," +
               "pnuevos.cantidad as Cantidad, pnuevos.fecha as Fecha, pnuevos.descuentos as Descuentos, pnuevos.garantia " +
               " as Garantia, productos.existente as Existente," +
               "productos.activo as Activo , pnuevos.idsucursal  FROM productos LEFT JOIN pnuevos " +
               " ON productos.idpnuevos = pnuevos.idpnuevos WHERE productos.idsucursal ='"
               + datossucursal[1] + "' and pnuevos.idsucursal ='" + datossucursal[1] + "'";

                    if (ActivarTodasLasSucursales() == false)
                        GetDataGrilla(1, sql_param);
                    else
                        GetDataGrilla(1);
                    break;
                case 2:

                    sql_param = "SELECT  pusados.idpusado as Codigo , pusados.nombre as Nombre, pusados.precio as Precio,"
                    + " pusados.cantidad as Cantidad, pusados.fecha as Fecha, pusados.descuento as Descuentos, pusados.garantia as Garantia," +
                    " productos.existente as Existente, productos.activo as Activo , pusados.estado as Estado " +
                   " FROM productos LEFT JOIN pusados ON productos.idpusados = pusados.idpusado WHERE productos.idsucursal LIKE '"
                       + datossucursal[1] + "' and pusados.idsucursal='" + datossucursal[1] + "'";


                    if (ActivarTodasLasSucursales() == false)
                        GetDataGrilla(2, sql_param);
                    else
                        GetDataGrilla(2);
                    break;
                case 3:
                    break;
                default:
                    break;
            }

        }


        private void AccesosDirectos(Keys k)
        {

            switch (k)
            {
                case Keys.F1:
                    FrmAntesDeAgregar Add = new FrmAntesDeAgregar();
                    Add.Show();
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    break;
                case Keys.F5:
                    break;
                case Keys.Control | Keys.P:
                    MessageBox.Show("Combinacion");
                    break;
                default:
                    break;
            }

        }
        private void ParametrosProductos(int min = 5)
        {

            try
            {

                for (int i = 0; i < grillaproductos.RowCount - 1; i++)
                {
                    var cantidad = grillaproductos[3, i].Value;
                    var activo = grillaproductos[8, i].Value;
                    var existente = grillaproductos[7, i].Value;

                    if ((int)cantidad <= min)
                    {
                        grillaproductos.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }

                    if ((int)activo == 0)
                    {
                        grillaproductos.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    }

                    if ((int)existente == 0)
                    {
                        grillaproductos.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
            }
            catch { }

        }

        Thread HiloNotificacion;

        private delegate void ResultadosNotificacion(object args);

        private void ResultNotifiacion(object args)
        {
            List<string[]> Listado = (List<string[]>)args;

            try
            {

                if (Notificacion.GetCountNotifiaciones() == 0)
                {

                    lblnotificaciones.Text = "No hay Notificacion";
                    cmdnotificacion.Text = "+0";
                    linkLabel1.Visible = true;
                }
                else if (Notificacion.GetCountNotifiaciones() >= 0)
                {
                    lblnotificaciones.Text = "Notificaciones Disponibles";
                    cmdnotificacion.Text = "+" + Notificacion.GetCountNotifiaciones().ToString();
                    Thread.SpinWait(200);
                    linkLabel1.Visible = false;
                    try
                    {

                        string[] datos = MostrarNotificaciones.Listado[MostrarNotificaciones.Listado.Count - 1];

                        switch (int.Parse(datos[5]))
                        {
                            case 0:

                                picnotificacion.Image = (Delatorre.Properties.Resources.sesionw);
                                break;
                            case 1:
                                picnotificacion.Image = (Delatorre.Properties.Resources.finsesionw);
                                break;
                            case 2:
                                picnotificacion.Image = (Delatorre.Properties.Resources.ventaw);
                                break;
                            case 3:
                                picnotificacion.Image = (Delatorre.Properties.Resources.agotadow);
                                break;
                            case 4:
                                picnotificacion.Image = (Delatorre.Properties.Resources.desactivadow);
                                break;
                            case 5:
                                picnotificacion.Image = (Delatorre.Properties.Resources.noexistew);
                                break;
                            case 6:
                                picnotificacion.Image = (Delatorre.Properties.Resources.impresionw);
                                break;
                        }

                        lblshowlastnotificacion.Text =
                            datos[0] + "\n"
                            + datos[1] + " "
                            + datos[2] + " "
                            + datos[3] + " "
                            + datos[4];

                    }
                    catch { }

                }

            }
            catch
            {

            }

        }

        private delegate void FinForm();

        private void CerrarForm()
        {
            Login.SesionMuerta = true;
            Login L = new Login();
            L.Show();
            this.Close();
        }

        private void CerrarPrograma()
        {
            Application.Exit();
        }

        private void FuncionControlSesiones(bool IsClose)
        {
            HiloSesion = new Thread(delegate()
            {
                if (SesionActiva() == 0)
                {
                    if (!IsClose)
                    {
                        Notificacion.SetNotificacion("Cerro sesion ", 1, datossucursal[1]);
                        FinForm frmfin = new FinForm(CerrarForm);
                        this.Invoke(frmfin);
                    }
                    else
                    {
                        Notificacion.SetNotificacion("Cerro sesion ", 1, datossucursal[1]);
                        FinForm frmfin = new FinForm(CerrarPrograma);
                        try
                        {
                            this.Invoke(frmfin);
                        }
                        catch { }
                    }
                }
                else
                {
                    HiloSesion.Abort();
                }
            });
            HiloSesion.Start();
        }



        private delegate void LLenarComboCliente_(Dictionary<int, object> diccionario);

        private void LLenarComboCliente(Dictionary<int, object> diccionario)
        {

            int i = 0;

            if (diccionario.Count == 0)
            {
                picclientes.Image = Delatorre.Properties.Resources.cancelblanco;
                return;
            }

            foreach (KeyValuePair<int, object> pair in diccionario)
            {
                object[] value = (object[])pair.Value;
                string Nombre = value[1].ToString();
                comboCbusqueda.Items.Add(pair.Key.ToString() + "," + Nombre);
                if (i == 0)
                    Datoscliente = value;
                i++;
            }
            comboCbusqueda.SelectedIndex = 0;
            picclientes.Image = Delatorre.Properties.Resources.checkmark_icon_16;
            GetdatosClientes();
        }

        private void GetdatosClientes()
        {

            try
            {
                LinkNombreCliente.Text = Datoscliente[1].ToString();
                LinkTelefonoCliente.Text = Datoscliente[2].ToString();
                linkdui.Text = Datoscliente[3].ToString();
                linkdireccion.Text = Datoscliente[5].ToString();
            }
            catch
            {
                LinkNombreCliente.Text = "-";
                LinkTelefonoCliente.Text = "-";
            }
        }

        private decimal VentaExenta(decimal Valor)
        {
            return Math.Round(Convert.ToDecimal(Convert.ToDouble(Valor) / 1.13), 2); 
        }

        Thread HiloVentaFinal;
        Semaphore SemtaforoFactura = new Semaphore(1, 1);
        private void RealizarVentaFinal(List<string> parametrosfactura, List<string[]> Productos)
        {
            string[] Sql = new string[4];
            string id_emp = lblcodemp.Text;
            string cliente = Datoscliente[0].ToString();
            string nit_dui = parametrosfactura[2];
           
            string direccion = parametrosfactura[1];
            string ventas_no_sujetas = Seguridad.ConversionPrecios(parametrosfactura[5]);
            string ventas_exentas = Seguridad.ConversionPrecios(parametrosfactura[6]);
            string total = Seguridad.ConversionPrecios(parametrosfactura[7]);

            Random Rnd = new Random(DateTime.Now.Millisecond);
            MySqlConnection Fcnn;
            MySqlDataReader Freader;
            MySqlCommand Fcmd;

            DataGridViewRowCollection Filas = grillaproductos.Rows;

            string id_factura = "FACT" 
                + cliente + Rnd.Next(0, 9).ToString() 
                + Rnd.Next(0, 99).ToString() 
                + Rnd.Next(0, 5).ToString();

            string fecha = Seguridad.FormatoFecha(DateTime.Now.ToShortDateString());

            try
            {
                HiloVentaFinal = new Thread(delegate()
                {
                    try
                    {
                        Fcnn = new MySqlConnection(Conexion.GetDireccion());
                        if (Fcnn.State != ConnectionState.Open) Fcnn.Open();

                        //Primera consulta....
                        Sql[0] = "insert into Factura (idfactura, venta_total, venta_nosujeta, venta_exenta, id_cliente, fecha, id_empleado, hora, direccion)"
                            + " Values ('"
                            + id_factura + "','"
                            + total + "','"
                            + ventas_no_sujetas + "','"
                            + ventas_exentas + "','"
                            + cliente + "','"
                            + fecha + "','"
                            + id_emp + "','"
                            + DateTime.Now.ToShortTimeString() + "','"
                            + direccion + "')";

                        Fcmd = new MySqlCommand(Sql[0], Fcnn);
                        Freader = Fcmd.ExecuteReader();



                        if (Freader.RecordsAffected >= 1)
                        {


                            for (int i = 0; i < Productos.Count; i++)
                            {

                                string[] DatosPRoductos = Productos[i];
                                SemtaforoFactura.WaitOne();
                                Sql[1] = "insert into detalle_factura (id_factura, cod_producto, producto, precio, cantidad, descuentos, garantia) "
                                    + "VALUES ('"
                                    + id_factura + "','"
                                    + DatosPRoductos[0] + "','"
                                    + DatosPRoductos[1] + "','"
                                    + Seguridad.ConversionPrecios(DatosPRoductos[2]) + "','"
                                    + DatosPRoductos[3] + "','"
                                    + DatosPRoductos[4] + "','"
                                    + DatosPRoductos[5] + "')";
                                    

                                Sql[2] = "update pnuevos set cantidad = cantidad-" 
                                    + DatosPRoductos[3] + " where idpnuevos='" 
                                    + DatosPRoductos[0] + "' and idsucursal='" + datossucursal[1] + "'" ;

                                Sql[3] = "update pusados set cantidad = cantidad-"
                                      + DatosPRoductos[3] + " where idpusado='"
                                      + DatosPRoductos[0] + "' and idsucursal='" + datossucursal[1] + "'";

                                for (int j = 1; j < Sql.Length; j++)
                                {
                                    try
                                    {
                                        Freader.Close();
                                        Fcmd.CommandText = Sql[j];
                                        Freader = Fcmd.ExecuteReader();
                                    }
                                    catch { }
                                }


                                SemtaforoFactura.Release();
                            }
                            Fcnn.Close();
                        }
                        else
                        {
                            MessageBox.Show("Hubo un Problema al momento de transaccionar la factura", "OPPS!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Fcnn.Close();
                            return;
                        }
                    }
                    catch { }

                });
                if (HiloVentaFinal.ThreadState != ThreadState.Running
                    || HiloVentaFinal.ThreadState != ThreadState.WaitSleepJoin)
                    HiloVentaFinal.Start();
            }
            catch { }

        }
       
        private List<Modulos.Factura> generar_factura()
        {

            DialogResult Diag_Factura = MessageBox.Show("Esta seguro que desea terminar esta venta (no hay marcha atras). ",
                "Seguridad ventas...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Diag_Factura == System.Windows.Forms.DialogResult.No)
                return null;


            Listafactura.Clear();
            ParametrosFactura.Clear();

            string id_emp = lblcodemp.Text;
            string cliente = "";
            string dui = "";
            string nit = "";
            string direccion = "";
            string acuenta_de = lblnombre.Text;
            string sumas = "";
            string ventas_no_sujetas = "";
            string ventas_exentas = "";
            string total = lblCtotal.Text;

            try
            {
                if (Datoscliente != null)
                {
                    cliente = Datoscliente[1].ToString();
                    dui = Datoscliente[3].ToString();
                    nit = Datoscliente[4].ToString();
                    direccion = Datoscliente[5].ToString();

                    ParametrosFactura.Add(cliente);
                    ParametrosFactura.Add(direccion);

                    if (dui != "" && nit != "")
                    {
                        DialogResult diag = MessageBox.Show("Este cliente proporciona Dui y Nit. ¿desea usar Dui en esta transaccion?"
                            , "Sugerencia", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (diag == DialogResult.Yes)
                            ParametrosFactura.Add(dui);
                        else
                            ParametrosFactura.Add(nit);
                    }
                    else if (dui != "" && nit == "")
                    {
                        ParametrosFactura.Add(dui);
                    }
                    else if (dui == "" && nit != "")
                    {
                        ParametrosFactura.Add(nit);
                    }

                    ParametrosFactura.Add(acuenta_de);
                    ParametrosFactura.Add(sumas);
                    ParametrosFactura.Add(ventas_no_sujetas);
                    ParametrosFactura.Add(ventas_exentas);
                    ParametrosFactura.Add(total);

                }
                else
                {
                    MessageBox.Show("No existe cliente vinculado; favor vincular el cliente", "OPPS!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }

                for (int k = 0; k < grillacarrito.RowCount - 1; k++)
                {

                    if (checkventaexenta.Checked == false)
                    {
                        Modulos.Factura factura = new Factura()
                        {
                            cantidad = grillacarrito[3, k].Value,
                            V_Unidad = (Convert.ToDecimal(grillacarrito[2, k].Value) / Convert.ToInt32(grillacarrito[3, k].Value)),
                            producto = grillacarrito[1, k].Value,
                            V_gravados = Convert.ToDecimal(grillacarrito[2, k].Value)
                        };
                        Listafactura.Add(factura);
                    }
                    else
                    {

                        Modulos.Factura factura = new Factura()
                        {
                            cantidad = grillacarrito[3, k].Value,
                            V_Unidad = (Convert.ToDecimal(grillacarrito[2, k].Value) / Convert.ToInt32(grillacarrito[3, k].Value)),
                            producto = grillacarrito[1, k].Value,
                            V_ex = VentaExenta((Convert.ToDecimal(grillacarrito[2, k].Value) / Convert.ToInt32(grillacarrito[3, k].Value))),
                            V_gravados = Convert.ToDecimal(grillacarrito[2, k].Value)
                        };
                        Listafactura.Add(factura);
                    }

             
                }

                List<string[]> Productos = new List<string[]>();

                for (int p = 0; p < grillacarrito.RowCount - 1; p++)
                {
                    string[] DatosCarrito = new string[6];
                    for (int z = 0; z < DatosCarrito.Length; z++)
                    {
                        DatosCarrito[z] = grillacarrito[z, p].Value.ToString();
                    }
                    Productos.Add(DatosCarrito);
                }

                RealizarVentaFinal(ParametrosFactura, Productos);

            }
            catch
            {
                MessageBox.Show("No existe cliente vinculado; favor vincular el cliente", "OPPS!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            return Listafactura;
        }


         

        #endregion

        #region Eventos

        protected override void OnClosed(EventArgs e)
        {
            MessageBox.Show("Sistema De Refrigeracion Delatorre se cerrara",
                "advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            try
            {
                HiloSesion_ = new Thread(delegate()
                {
                    //Notificacion.SetNotificacion("Cerro sesion ", 1, datossucursal[1]);
                    Datos.CerrarSesion();
                    FuncionControlSesiones(true);
                });
                if (HiloSesion_.ThreadState != ThreadState.WaitSleepJoin || HiloSesion_.ThreadState != ThreadState.Running)
                    HiloSesion_.Start();
            }
            catch { }
            base.OnClosed(e);
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            try
            {
              
                S1 = new Semaphore(1, 1);
                piccargando.Visible = false;
                piccargandoCliente.Visible = false;
                this.MaximizeBox = false;
                CarritoCompra = new CarritoDeCompra(grillacarrito);
                datosusuarios = Datos.DatosUsuario.Split(',');
                PrivilegiosEstados(datosusuarios[2]);
                lblusuario.Text = datosusuarios[0];
                datossucursal = Datos.DatosSucursal.Split(',');
                this.Text = "Repuestos Frigorificos Delatorre               Sucursal: " + datossucursal[0];
                lblsucursal.Text = datossucursal[0];
                RadioSucuEsta.Text = "Solo sucursal " + datossucursal[0];
                lblgerente.Text = datossucursal[2];
                RadioSucuEsta.Checked = true;
                linksucursalProd.Text = "___";
                string location =  System.Reflection.Assembly.GetExecutingAssembly().Location;
                string fileversion = System.Diagnostics.FileVersionInfo.GetVersionInfo(location).FileVersion;
                int compilacion = System.Diagnostics.FileVersionInfo.GetVersionInfo(location).FileBuildPart;
                lblversion.Text = "Version: " + fileversion + " | " + compilacion.ToString();
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            }
            catch
            {
                if (datossucursal == null)
                {
                    MessageBox.Show("");
                }
            }

            combobusqueda.Text = "Productos Usados";
            combobusqueda.Items.Add("Prod Hermanos (obsoleto) ");
            combobusqueda.Items.Add("Productos Nuevos");
            combobusqueda.Items.Add("Productos Usados");
            combobusqueda.SelectedIndex = 2;
            

            string sql_param = "SELECT  pusados.idpusado as Codigo , pusados.nombre as Nombre, pusados.precio as Precio,"
            + " pusados.cantidad as Cantidad, pusados.fecha as Fecha, pusados.descuento as Descuentos, pusados.garantia as Garantia,"+
            " productos.existente as Existente, productos.activo as Activo , pusados.estado as Estado "+
            " FROM productos INNER JOIN pusados ON productos.idpusados = pusados.idpusado WHERE productos.idsucursal LIKE '"
            + datossucursal[1] + "'";

            GetDataGrilla(2 , sql_param);
            PatronEliminar = 2;
           

            if (txtbusqueda.Text == "" || txtbusqueda.Text == null) cmdbuscar.Enabled = false;

            this.Focus();
           // TcontrolSesiones.Enabled = true;

            HiloSucursal = new Thread(delegate()
            {
                ListaSucursales = new List<string[]>();
                ListaSucursales = Datos.GetAllSucursal();
                 DatosEmpleados();
            });
            HiloSucursal.Start();

            lbldidyoumean.Visible = false;
            linkDidyoumean.Visible = false;
            TimerVelocidadInternet.Enabled = true;
            //reportesToolStripMenuItem.Visible = false;
        }

        private void TiempoEjecucion_Tick(object sender, EventArgs e)
        {
            try
            {
                if (HiloGrilla.IsAlive != true)
                {
                    grillaproductos.DataSource = dt;
                    linkcantidadp.Text = "Cantidad de productos: " + (grillaproductos.RowCount - 1).ToString() + " Encontrados";
                    try
                    {

                        try {

                            string campo = grillaproductos.Columns["ids"].HeaderText;
                            if (campo != "")
                            {
                                grillaproductos.Columns["ids"].Visible = false;

                            }

                        }
                        catch { }


                        MotorBusqueda.Datagrid = grillaproductos;
                        Busqueda.InitFunction(true);
                        ParametrosProductos(8);

                        if (LoadingGrilla.Isactivate() == true)
                        {
                            LoadingGrilla.DesactivateLoading();
                            LoadingGrilla.Loading(false, grillaproductos, new Point(223, 156), new Size(40, 40));
                        }

                    }
                    catch { }

                    try
                    {
                        Sugestion = new Sugestion(grillaproductos);
                        Sugestion.StartSuggestion();
                    }
                    catch
                    {
                    }


                    TiempoEjecucion.Enabled = false;
                }
                else
                {
                    if (LoadingGrilla.Isactivate() == false)
                    {
                        LoadingGrilla.Loading(true, grillaproductos, new Point(223, 156), new Size(40, 40));
                    }
                    
                }
            }
            catch { }
        }

        private void combobusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql_param = null;
            if (combobusqueda.SelectedIndex == 0)
            {
                
                GetDataGrilla(0);
                linkproductos.Text = "Productos Relacionados";
                PatronEliminar = 0;
              
            }
            else if (combobusqueda.SelectedIndex == 1)
            {
                sql_param = "SELECT  pnuevos.idpnuevos as Codigo , pnuevos.nombre as Nombre, pnuevos.precio as Precio," +
                "pnuevos.cantidad as Cantidad, pnuevos.fecha as Fecha, pnuevos.descuentos as Descuentos, pnuevos.garantia " +
                " as Garantia, productos.existente as Existente,"+
                "productos.activo as Activo FROM productos LEFT JOIN pnuevos " +
                " ON productos.idpnuevos = pnuevos.idpnuevos WHERE productos.idsucursal ='"
                + datossucursal[1] + "' and pnuevos.idsucursal ='" + datossucursal[1] + "'" ;

                if (ActivarTodasLasSucursales() == false)
                    GetDataGrilla(1, sql_param);
                else
                    GetDataGrilla(1);

                linkproductos.Text = "Productos Nuevos";
                PatronEliminar = 1;
          
            }
            else
            {
                sql_param = "SELECT  pusados.idpusado as Codigo , pusados.nombre as Nombre, pusados.precio as Precio,"
                 + " pusados.cantidad as Cantidad, pusados.fecha as Fecha, pusados.descuento as Descuentos, pusados.garantia as Garantia," +
                 " productos.existente as Existente, productos.activo as Activo , pusados.estado as Estado " +
                " FROM productos LEFT JOIN pusados ON productos.idpusados = pusados.idpusado WHERE productos.idsucursal LIKE '"
                    + datossucursal[1] + "' and pusados.idsucursal='" + datossucursal[1] + "'";


                if (ActivarTodasLasSucursales() == false)
                    GetDataGrilla(2, sql_param);
                else
                    GetDataGrilla(2);

                linkproductos.Text = "Productos Usados";
                PatronEliminar = 2;
            }

           
        }

        private void Thorafecha_Tick(object sender, EventArgs e)
        {
            lblhorafecha.Text = "Fecha: " +  DateTime.Now.Date.ToShortDateString()
                + " Hora: "
                + DateTime.Now.TimeOfDay.Hours 
                + ":" 
                + DateTime.Now.TimeOfDay.Minutes 
                + ":" 
                + DateTime.Now.TimeOfDay.Seconds;
        }

        private void grillaproductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(combobusqueda.SelectedIndex != 0 || combobusqueda.Text != "Todos los productos")
                        GetDatosProductos(e.RowIndex);
        }

        private void cmdbuscar_Click(object sender, EventArgs e)
        {

            try
            {

                if (MotorBusqueda.ParametrosBusqueda.Count >= 1)
                    MotorBusqueda.ParametrosBusqueda.Clear();

                MotorBusqueda.ParametrosBusqueda.Add("Codigo");
                MotorBusqueda.ParametrosBusqueda.Add("Nombre");
                MotorBusqueda.ParametrosBusqueda.Add("Precio");
                MotorBusqueda.ParametrosBusqueda.Add("Cantidad");
                MotorBusqueda.ParametrosBusqueda.Add("Fecha");
                MotorBusqueda.ParametrosBusqueda.Add("Descuentos");
                MotorBusqueda.ParametrosBusqueda.Add("Estado");


                MotorBusqueda.Cadena = txtbusqueda.Text;

                Busqueda.GetBusquedaAvanzada_();

                if (Busqueda.IsaliveThreat() == true)
                {
                    TimeBusqueda.Enabled = true;
                    Busqueda.WaitTimeConfig(grillaproductos, new Point(350, 115));
                }
           
            
                try
                {
                    if (HiloSpell != null)
                    {
                        if (HiloSpell.ThreadState == ThreadState.Running) HiloSpell.Abort();
                    }

                    HiloSpell = new Thread(delegate()
                    {
                        RespuestaSpellCheck spellc = new RespuestaSpellCheck(GetSpell);
                        string palabra = Expresiones.GetExpresionDidYouMean(txtbusqueda.Text);
                        if (palabra != string.Empty)
                        {
                            this.Invoke(spellc, new object[] { palabra, 1 });
                        }
                        else
                        {
                            this.Invoke(spellc, new object[] { palabra, 2 });
                        }
                    });
                    HiloSpell.Start();
                }
               
                catch { }

                ParametrosProductos();
                

            }
            catch { }
        }

        private void TimeBusqueda_Tick(object sender, EventArgs e)
        {
            if (Busqueda.WaitTime() == true)
            {
                GetDataGrilla(combobusqueda.SelectedIndex);
                TimeBusqueda.Enabled = false;
            }
        }

        private void grillaproductos_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            GetDatosProductos(e.RowIndex);

        }

        Thread HiloSesion_;

      /*  private delegate void EjecutarSalidaSesion();

        private void EjecutarSalida()
        {
        }*/

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HiloSesion_ = new Thread(delegate()
            {
                //Notificacion.SetNotificacion("Cerro sesion ", 1, datossucursal[1]);
                Datos.CerrarSesion();
                FuncionControlSesiones(true);
            });
            if (HiloSesion_.ThreadState != ThreadState.WaitSleepJoin || HiloSesion_.ThreadState != ThreadState.Running)
                HiloSesion_.Start();
            //TimeControlSalidas.Enabled = true;
        }

        private void Principal_KeyPress(object sender, KeyPressEventArgs e)
        {
       
        }

        private void cmdreflescar_Click(object sender, EventArgs e)
        {
            Reflescar();
        }

        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtbusqueda.Text != "" || txtbusqueda.Text != null) cmdbuscar.Enabled = true;

            if (MotorBusqueda.ParametrosBusqueda.Count >= 1)
                MotorBusqueda.ParametrosBusqueda.Clear();

            MotorBusqueda.ParametrosBusqueda.Add("Codigo");
            MotorBusqueda.ParametrosBusqueda.Add("Nombre");
            MotorBusqueda.ParametrosBusqueda.Add("Precio");
            MotorBusqueda.ParametrosBusqueda.Add("Cantidad");
            MotorBusqueda.ParametrosBusqueda.Add("Fecha");
            MotorBusqueda.ParametrosBusqueda.Add("Descuentos");
            MotorBusqueda.ParametrosBusqueda.Add("Estado");


            MotorBusqueda.Cadena = txtbusqueda.Text;

            Busqueda.GetBusquedaAvanzada_();

            if (Busqueda.IsaliveThreat() == true)
            {
                TimeBusqueda.Enabled = true;
                Busqueda.WaitTimeConfig(grillaproductos, new Point(350, 115));
            }

            ParametrosProductos();
           /* try
            {
                Sugestion.Getsuggestion(txtbusqueda);
            }
            catch { }*/
           
        }

        private void txtbusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
               
         }

        private void txtbusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            AccesosDirectos(e.KeyCode);
        }

        private void cmdadd_Click(object sender, EventArgs e)
        {
            FrmAntesDeAgregar Add = new FrmAntesDeAgregar();
            Add.Show();
        }

        private void registrarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cmdadd_MouseMove(object sender, MouseEventArgs e)
        {
            Tip.SetToolTip(this.cmdadd, "Agrega un nuevo producto");
        }

        private void cmdedit_MouseMove(object sender, MouseEventArgs e)
        {
            Tip.SetToolTip(this.cmdedit, "Edita un producto existente");
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Tloading_Tick(object sender, EventArgs e)
        {
     
        }

        private void TimeNotificaciones_Tick(object sender, EventArgs e)
        {

     
          TimeNotificaciones.Interval = 40000;
          TiempoResultanteNotificaciones = TimeNotificaciones.Interval;

          try
          {


              if (HiloNotificacion.IsAlive == true)
              {
                  HiloNotificacion.Priority = ThreadPriority.Highest;
                  return;
              }
              else
              {
                  HiloNotificacion = new Thread(delegate()
                  {
                      mutex = new Mutex();
                      mutex.WaitOne();
                      MostrarNotificaciones.Listado = Notificacion.GetNotificaciones(datossucursal[1]);
                      ResultadosNotificacion resultado = new ResultadosNotificacion(ResultNotifiacion);
                      try
                      {
                          this.Invoke(resultado, new object[] { MostrarNotificaciones.Listado });
                      }
                      catch { }
                      mutex.ReleaseMutex();
                  });
                  HiloNotificacion.Start();
                 
                  return;
              }
          }
          catch {

              HiloNotificacion = new Thread(delegate()
              {
                  try
                  {
                      mutex = new Mutex();
                      mutex.WaitOne();
                      MostrarNotificaciones.Listado = Notificacion.GetNotificaciones(datossucursal[1]);
                      ResultadosNotificacion resultado = new ResultadosNotificacion(ResultNotifiacion);
                      this.Invoke(resultado, new object[] { MostrarNotificaciones.Listado });
                      mutex.ReleaseMutex();
                  }
                  catch { }
              });
              HiloNotificacion.Start();
        
              return;
          }

        }

        private void cmdnotificacion_Click(object sender, EventArgs e)
        {
            MostrarNotificaciones MostrarNot = new MostrarNotificaciones();
            MostrarNot.Show();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HiloSesion_ = new Thread(delegate()
            {
                //Notificacion.SetNotificacion("Cerro sesion ", 1, datossucursal[1]);
                Datos.CerrarSesion();
                FuncionControlSesiones(false);
            });
            if (HiloSesion_.ThreadState != ThreadState.WaitSleepJoin || HiloSesion_.ThreadState != ThreadState.Running)
                HiloSesion_.Start();

        }

        private void TimecontrolNotificaciones_Tick(object sender, EventArgs e)
        {
            if (EncolarNotificacion.Count >= 1)
            {

                try
                {
                    if (Notificacion.Isalive() == false)
                    {
                        string[] salida = EncolarNotificacion.Dequeue();
                        Notificacion.SetNotificacion(salida[0], int.Parse(salida[1]), datossucursal[1]);
                        if (Notificacion.IsNotError() == false)
                        {
                            EncolarNotificacion.Enqueue(salida);
                        }
                        else return;
                    }
                }
                catch {
                    string[] salida = EncolarNotificacion.Dequeue();
                    Notificacion.SetNotificacion(salida[0], int.Parse(salida[1]), datossucursal[1]);
                    if (Notificacion.IsNotError() == false)
                    {
                        EncolarNotificacion.Enqueue(salida);
                    }
                }
            }

        }

        private void TimeControlSalidas_Tick(object sender, EventArgs e)
        {
            if (Notificacion.Isalive() == false)
            {
                TimeControlSalidas.Enabled = false;
                Application.Exit();
            }
        }

        private void usuariosConectadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuariosConectados conn = new UsuariosConectados();
            conn.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            MostrarNotificaciones.Listado = Notificacion.GetNotificaciones(datossucursal[1]);

            if (Notificacion.GetCountNotifiaciones() == 0)
            {

                lblnotificaciones.Text = "No hay Notificacion";
                cmdnotificacion.Text = "+0";
                linkLabel1.Visible = true;
            }
            else if (Notificacion.GetCountNotifiaciones() >= 0)
            {
                lblnotificaciones.Text = "Notificaciones Disponibles";
                cmdnotificacion.Text = "+" + Notificacion.GetCountNotifiaciones().ToString();
                Thread.SpinWait(200);
                linkLabel1.Visible = false;
                try
                {

                    string[] datos = MostrarNotificaciones.Listado[MostrarNotificaciones.Listado.Count - 1];

                    switch (int.Parse(datos[5]))
                    {
                        case 0:

                            picnotificacion.Image = (Delatorre.Properties.Resources.sesionw);
                            break;
                        case 1:
                            picnotificacion.Image = (Delatorre.Properties.Resources.finsesionw);
                            break;
                        case 2:
                            picnotificacion.Image = (Delatorre.Properties.Resources.ventaw);
                            break;
                        case 3:
                            picnotificacion.Image = (Delatorre.Properties.Resources.agotadow);
                            break;
                        case 4:
                            picnotificacion.Image = (Delatorre.Properties.Resources.desactivadow);
                            break;
                        case 5:
                            picnotificacion.Image = (Delatorre.Properties.Resources.noexistew);
                            break;
                        case 6:
                            picnotificacion.Image = (Delatorre.Properties.Resources.impresionw);
                            break;
                    }

                    lblshowlastnotificacion.Text =
                        datos[0] + "\n"
                        + datos[1] + " "
                        + datos[2] + " "
                        + datos[3] + " "
                        + datos[4];

                }
                catch { }

            }
        }

        private void linkestado_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkmas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EstadosProducto.CadenaEstadoProducto = linkestado.Text;
            EstadosProducto estadop = new EstadosProducto();
            estadop.Show();
        }

        private void grillaproductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private delegate void HabilitarCmd();

        private void HabilitarBoton() { cmderase.Enabled = true; }

        private void cmderase_Click(object sender, EventArgs e)
        {

            DialogResult dialog = MessageBox.Show("¿Desea eliminar el producto "
                + ParamBorrar + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           
            if (dialog == DialogResult.Yes)
            {
                HiloEliminar = new Thread(delegate()
                    {
                        int prodIn = PatronEliminar;
                        HabilitarCmd cmderace = new HabilitarCmd(HabilitarBoton);

                        try
                        {
                            
                            string sql = null;
                        

                            if (PatronEliminar == 1)
                            {
                                sql = "DELETE FROM a1 , a2 USING pnuevos as a1  INNER JOIN productos as a2 WHERE a1.idpnuevos = a2.idpnuevos AND a1.idpnuevos LIKE '"
                                + ParamBorrar + "' AND a2.idsucursal ='" + datossucursal[1] + "' AND a1.idsucursal ='" + datossucursal[1] + "'";
                                prodIn = 1;
                            }
                            else if (PatronEliminar == 2)
                            {
                                prodIn = 2;
                                sql = "DELETE FROM a1 , a2 USING pusados as a1  INNER JOIN productos as a2 WHERE a1.idpusado = a2.idpusados AND a1.idpusado LIKE '"
                                + ParamBorrar + "' AND a2.idsucursal ='" + datossucursal[1] + "' AND a1.idsucursal ='" + datossucursal[1] + "'";
                            }
                            else
                            {
                                sql = null;
                                this.Invoke(cmderace);
                                return;
                            }

                            MySqlConnection conn = Conexion.GetConexion();
                            if (conn.State == ConnectionState.Closed)
                            {
                                conn = new MySqlConnection(Conexion.GetDireccion());
                                conn.Open();
                            }
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            MySqlDataReader reader = cmd.ExecuteReader();
                            if (reader.IsClosed)
                            {
                                reader.Close();
                            }


                            if (reader.Read() != true)
                            {
                                MessageBox.Show("Producto eliminado de la lista con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);                             
                                EncolarNotificacionByParams("Producto " + ParamBorrar + " Ha sido eliminado de la lista ", "5");
                                conn.Close();
                                SubProcesoGrilla SubPG = new SubProcesoGrilla(Reflescar);
                                this.Invoke(SubPG);
                                this.Invoke(cmderace);
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Producto No se ha podido eliminar", "Opss!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.Invoke(cmderace);
                                conn.Close();
                                return;
                            }
                        }
                        catch { 
                            this.Invoke(cmderace);
                        }
                    });
                HiloEliminar.Start();
                cmderase.Enabled = false;
            }
            else
            {
                return;
            }

        }

        static int TiempoResultanteNotificaciones = 0;
        private void ActualizacionNotificaciones_Tick(object sender, EventArgs e)
        {
            double Result = TiempoResultanteNotificaciones * (0.0010);
            TiempoResultanteNotificaciones -= 1000;
            lblactualizacion.Text = "Actualizando en : " + Result + " Segundos" ;
        }

        private void registrarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void opcionesAvanzadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpcionesAvanzadas Opadvance = new OpcionesAvanzadas();
            Opadvance.Show();
        }

    

        private void TcontrolSesiones_Tick(object sender, EventArgs e)
        {
            try
            {
                if (HiloSesion.IsAlive == false)
                {
                    FuncionControlSesiones(false);
                }
            }
            catch 
            {
                FuncionControlSesiones(false);
            }
           
        }

        private int SesionActiva()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(Conexion.GetDireccion());
                conn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("Select * from User_login Where iduser like '"
                    + Datos.Idusuario + "' And sesion = 0", conn);
                DataTable Tabla = new DataTable();
                DataSet Ds = new DataSet();
             
                adapter.Fill(Ds);
                Tabla = Ds.Tables[0];

                if (Tabla.Rows.Count >= 1)
                {
                    conn.Close();
                    return 0;
                }
                else
                {
                    conn.Close();
                    return 1;
                }
            }
            catch { }

            return 1;
        }

        private void cmdedit_Click(object sender, EventArgs e)
        {
            FrmEditar editar = new FrmEditar();
            editar.Show();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private List<ReporteProdNuevo> GenerarReportePN()
        {
            List<ReporteProdNuevo> listareportes = new List<ReporteProdNuevo>();

            for (int i = 0; i < grillaproductos.RowCount - 1; i++)
            {
                Modulos.ReporteProdNuevo PN = new ReporteProdNuevo()
                {
                    id = grillaproductos[0, i].Value,
                    nombre = grillaproductos[1, i].Value,
                    fecha = grillaproductos[2, i].Value,
                    cantidad = grillaproductos[3, i].Value,
                    descuentos = grillaproductos[4, i].Value,
                    garantia = grillaproductos[5, i].Value
                };
                listareportes.Add(PN);
            }
            return listareportes;
        }

        private void reportesProductosNuevosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes RpN = new Reportes();
            RpN.listaPnuevo = GenerarReportePN();
            RpN.Sucursal = lblsucursal.Text;
            RpN.Show();
        }

        private void registrarEmpleadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RegistrarEmpleado RegEmp = new RegistrarEmpleado();
            RegistrarEmpleado.Secuencia = 0;
            RegEmp.Show();
        }

        private void registrarSucursalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RegistrarSucursal RS = new RegistrarSucursal();
            RS.Show();
        }

        private void grillaproductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registro Reg = new Registro();
            Reg.Show();
        }

        private void Principal_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F1:
                     FrmAntesDeAgregar Add = new FrmAntesDeAgregar();
                     Add.Show();
                     break;
                case Keys.F2:
                     FrmEditar editar = new FrmEditar();
                     editar.Show();
                     break;
                default:
                     if ( Convert.ToInt32( e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.P))
                     {

                     }
                     break;

            }
        }


        private bool SetupThePrinting(DataGridView MyDataGridView, string Tema)
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;

            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;


            MyPrintDocument.DocumentName = "Repuestos delatorre " + Tema;
            MyPrintDocument.PrinterSettings =
                                MyPrintDialog.PrinterSettings;
            MyPrintDocument.DefaultPageSettings =
            MyPrintDialog.PrinterSettings.DefaultPageSettings;
            MyPrintDocument.DefaultPageSettings.Margins =
                             new System.Drawing.Printing.Margins(40, 40, 40, 40);

            if (MessageBox.Show("¿Desea que el reporte se centre automaticamente a la pagina?",
                "Centrar", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MyDataGridViewPrinter = new DataGridViewPrinter(MyDataGridView,
                MyPrintDocument, true, true, Tema, new Font("Tahoma", 18,
                FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            }
            else
                MyDataGridViewPrinter = new DataGridViewPrinter(MyDataGridView,
                MyPrintDocument, false, true, Tema, new Font("Tahoma", 18,
                FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }

        private void cmdprint_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting(grillaproductos, "Productos "))
            {
                PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                MyPrintPreviewDialog.Document = MyPrintDocument;
                MyPrintPreviewDialog.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se ha detectado dispositivo de impresion", "Error Impresion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MyPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private void editarSucursalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditarSucursal EditS = new EditarSucursal();
            EditS.Show();
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                try
                {
                    CarritoCompra.ObtenerDatosEngrilla(ListaProductosCarrito);
                    lblCtotal.Text = CarritoCompra.TotalCantidadProductos().ToString();
                }
                catch { }
            }
            else if(tabControl1.SelectedIndex == 2)
            {
                try
                {
                    string[] datosE = Datos.DatosEmpleados.Split(',');
                    GetActividades(datosE[0]);
                }
                catch { }
            }
        }

        private void cmdVenta_Click(object sender, EventArgs e)
        {

            if (linkactivo.Text == "No")
            {
                MessageBox.Show("Producto Desactivado ", "Descativado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (linkexistente.Text == "No")
            {
                MessageBox.Show("Producto Inexistente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            hacerventa.DatosProductos.Add(linkcodigo.Text);
            hacerventa.DatosProductos.Add(linknombre.Text);
            hacerventa.DatosProductos.Add(linkprecio.Text);
            hacerventa.DatosProductos.Add(linkcantidad.Text);
            hacerventa.DatosProductos.Add(linkdescuentos.Text);
            hacerventa.DatosProductos.Add(linkgarantia.Text);
            hacerventa HV = new hacerventa();
            HV.Show();
        }

        private void cmdbuscaract_Click(object sender, EventArgs e)
        {
            string[] datosE = Datos.DatosEmpleados.Split(',');
            GetActividades(datosE[0] , datefechabuscar.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] datosE = Datos.DatosEmpleados.Split(',');
            GetActividades(datosE[0]);
        }

        private delegate void GuardandoWait(bool F);

        private void GuardandoWaitFn(bool F)
        {
            switch (F)
            {
                case true:
                    cmdregcliente.Enabled = true;
                    piccargando.Visible = false;
                    break;
                case false:
                     cmdregcliente.Enabled = false;
                    piccargando.Visible = true;
                    break;
            }

        }


        private void GuardandoWaitFn2(bool F)
        {
            switch (F)
            {
                case true:
                    cmdnuscarcliente.Enabled = true;
                    piccargandoCliente.Visible = false;
                    break;
                case false:
                    cmdnuscarcliente.Enabled = false;
                    piccargandoCliente.Visible = true;
                    break;
            }

        }


        private void cmdregcliente_Click(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();
            Random RndC = new Random(DateTime.Now.Millisecond);

            if (TxtCnombre.Text == "" || TxtCtelefono.Text == "")
            {
                MessageBox.Show("Algunos campos son obligatorios, favor llenarlos", "Opps!!"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string IDC = "CLT" + RndC.Next(100, 400) + RndC.Next(100, 700) + RndC.Next(10, 99);
            string FechaDehoy = Seguridad.FormatoFecha(DateTime.Now.ToShortDateString());
            string[] valoresC = new string[] {
                IDC , 
                TxtCnombre.Text , 
                TxtCtelefono.Text ,
                TxtCdui.Text , 
                txtnit.Text,
                TxtCdireccion.Text,
                FechaDehoy
            };

            string[] parametrosBusquedaC = new string[] { TxtCnombre.Text, TxtCtelefono.Text, TxtCdui.Text, txtnit.Text };

            Thread hiloc = new Thread(delegate()
            {
                GuardandoWait W = new GuardandoWait(GuardandoWaitFn);
                this.Invoke(W, new object[] { false });
                if (cliente.ExisteCliente(parametrosBusquedaC))
                {
                    this.Invoke(W, new object[] { true });
                    MessageBox.Show("Al parecer este cliente ya esta registrado ...", "Info"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                bool exito = cliente.SetDatosClientes(valoresC);
                if (exito)
                {
                    this.Invoke(W, new object[] { true });
                    MessageBox.Show("Cliente registrado con exito" , "Exito" 
                        , MessageBoxButtons.OK , MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    this.Invoke(W, new object[] { true });
                    MessageBox.Show("Ocurrio un Error inseperado .. intente denuevo o reinicie el programa"
                        , "opps", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            });
            if (hiloc.ThreadState != ThreadState.Running) hiloc.Start();
        }


        private void cmdnuscarcliente_Click(object sender, EventArgs e)
        {
            ListaClientes = new List<object>();
            ListaClienteByKey = new Dictionary<int, object>();
            comboCbusqueda.Items.Clear();
            string Param = comboCbusqueda.Text;

            Thread HiloBuscarC = new Thread(delegate()
            {
                GuardandoWait Guardando = new GuardandoWait(GuardandoWaitFn2);
                this.Invoke(Guardando, new object[] { false });
                Clientes Clientes_ = new Clientes();
                ListaClienteByKey = new Dictionary<int, object>();
                ListaClientes = Clientes_.GetdatosClientes(Param);
                int i =0;
                try
                {
                    foreach (object obj in ListaClientes)
                    {
                        ListaClienteByKey.Add(i, obj);
                        i++;
                    }
                }
                catch { }
                LLenarComboCliente_ llenado = new LLenarComboCliente_(LLenarComboCliente);
                this.Invoke(llenado, new object[] { ListaClienteByKey });
                this.Invoke(Guardando, new object[] { true });
            });
            if (HiloBuscarC.ThreadState != ThreadState.Running 
                || HiloBuscarC.ThreadState != ThreadState.WaitSleepJoin) 
                HiloBuscarC.Start();
        }

        private void cmdcarritoCreate_Click(object sender, EventArgs e)
        {
            ClsCarritoCompra();
        }

  

        private void comboCbusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] llave = comboCbusqueda.Items[comboCbusqueda.SelectedIndex].ToString().Split(',');
                foreach (KeyValuePair<int, object> pair in ListaClienteByKey)
                {
                    if (pair.Key == int.Parse(llave[0]))
                    {
                        Datoscliente = (object[])pair.Value;
                        GetdatosClientes();
                        break;
                    }
                }
            }
            catch { }
        }

        private void cmdEliminarCarrito_Click(object sender, EventArgs e)
        {
            DialogResult Diag = MessageBox.Show("¿Desea eliminar el producto del carrito?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Diag == DialogResult.Yes)
            {
                ListaProductosCarrito.RemoveAt(RowCliente);
                CarritoCompra.ObtenerDatosEngrilla(ListaProductosCarrito);
                lblCtotal.Text =  CarritoCompra.TotalCantidadProductos().ToString();
                cambiocarrito = true;
            }
        }

        private void grillacarrito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowCliente = e.RowIndex;
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarProveedor regp = new RegistrarProveedor();
            regp.Show();
        }

        private void grillacarrito_CellBorderStyleChanged(object sender, EventArgs e)
        {

        }

        #endregion

        private void modoAdministradorF5ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void linkDidyoumean_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            txtbusqueda.Text = linkDidyoumean.Text;
        }

        private void editarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmeditarempleados fee = new frmeditarempleados();
            fee.Show();
        }

        public static bool cambiocarrito = false;
        private void TimeControlCarrito_Tick(object sender, EventArgs e)
        {
            if (cambiocarrito == true)
            {
                if (ListaProductosCarrito.Count >= 1)
                {
                    tabcarrito.ImageIndex = 4;
                    tabcarrito.Text = "Carrito de compra  (+" + ListaProductosCarrito.Count + ")" ;
                }
                else
                {
                    tabcarrito.ImageIndex = 1;
                    tabcarrito.Text = "Carrito de compra ";
                }

                cambiocarrito = false;
            }
        }

        private void cmdverproveedor_Click(object sender, EventArgs e)
        {
            FrmVerProveedor prov = new FrmVerProveedor();
            prov.Show();
        }


        private void cmdGuardarCarrito_Click(object sender, EventArgs e)
        {


            factura f = new factura();
            f.ParametrosDiscretos = ParametrosFactura;
            f.ListaFactura = generar_factura();

            try
            {
                if (f.ListaFactura.Count >=1  
                    && f.ListaFactura != null)
                {
                    f.Show();
                    for (int i = 0; i < grillacarrito.RowCount - 1; i++)
                    {

                        string[] Envioactividades;
                        string id = lblcodemp.Text;
                        string Producto = grillacarrito[0, i].Value.ToString() + ":" + grillacarrito[1, i].Value.ToString();
                        string fecha = Seguridad.FormatoFecha(DateTime.Now.ToShortDateString());
                        string Hora = DateTime.Now.ToShortTimeString();
                        Envioactividades = new string[] { Producto, fecha, Hora, id };
                        actividades.SetActividades(Envioactividades);
                    }
                }

                Notificacion.SetNotificacion("Se realizo una venta; En hora de " 
                    + DateTime.Now.ToShortTimeString() , 2, datossucursal[1]);

                ClsCarritoCompra();
            }
            catch { }

        }

        private void txtpago_MouseClick(object sender, MouseEventArgs e)
        {
            txtpago.Text = "";
        }

        private void txtpago_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string pago = txtpago.Text;
                decimal Total_pagar = Convert.ToDecimal(lblCtotal.Text);
                decimal Pago_con = Convert.ToDecimal(pago);
                decimal Devolucion = Pago_con - Total_pagar;
                lblresultadopago.Text = "Dev $:" + Devolucion;
            }
            catch { lblresultadopago.Text = "$0.00" ; }
        }

        private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmEditarProveedor editprov = new FrmEditarProveedor();
            editprov.Show();
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
          /*  try
            {
                Notificacion.SetNotificacion("Cerro sesion ", 1, datossucursal[1]);
                Datos.CerrarSesion();
                TimeControlSalidas.Enabled = true;
            }
            catch { }*/
        }

        Thread HiloInternet;

        private delegate void NotificacionInternetDelegado(int request);

        private void NotificacionInternetFuncion(int request)
        {

            NotificacionInternet.BalloonTipTitle = "Avertencia ";
            NotificacionInternet.BalloonTipIcon = ToolTipIcon.Warning;
            
            if (request == 1)
                NotificacionInternet.BalloonTipText = "Se ha detectado que la conexion de internet esta 'Lenta'. Puede que el programa no trabaje bien.";
            else if(request ==2)
                NotificacionInternet.BalloonTipText = "Conexion Interrumpida (No hay conexion)";

            NotificacionInternet.ShowBalloonTip(10000);
        }

        private void TimerVelocidadInternet_Tick(object sender, EventArgs e)
        {

            try
            {
                if (HiloInternet != null)
                    if (HiloInternet.ThreadState == ThreadState.Running 
                        || HiloInternet.ThreadState == ThreadState.WaitSleepJoin)
                        return;

                HiloInternet = new Thread(delegate()
                    {
                        int respuesta = Seguridad.EstadoConexionInternet();
                        if (respuesta == 1 || respuesta == 2)
                        {
                            try
                            {
                                NotificacionInternetDelegado Not = new NotificacionInternetDelegado(NotificacionInternetFuncion);
                                this.Invoke(Not, new object[] { respuesta });
                                Thread.Sleep(500);
                                double espera = (40 / 0.001);
                                Thread.Sleep(Convert.ToInt32(espera));
                            }
                            catch { }
                        }
                      
                    });
                HiloInternet.Start();
            }
            catch { }


        }

        private void agregarF1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAntesDeAgregar Add = new FrmAntesDeAgregar();
            Add.Show();
          
        }

        private void imprimirCtlPToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (SetupThePrinting(grillaproductos, "Productos "))
            {
                PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                MyPrintPreviewDialog.Document = MyPrintDocument;
                MyPrintPreviewDialog.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se ha detectado dispositivo de impresion", "Error Impresion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vistaEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVerEmpleado emp = new FrmVerEmpleado();
            emp.Show();
        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
           // Application.Exit();
        }

        private void CmdAcercade_Click(object sender, EventArgs e)
        {
            AcercaDebox acercade = new AcercaDebox();
            acercade.Show();
        }

        private void restaurarSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Backup_Form frmbackup = new Backup_Form();
            frmbackup.Show();
        }

        private void grillacarrito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void verFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVerFacturasCreadas facturacion = new FrmVerFacturasCreadas();
            facturacion.Show();
        }

        private void toolhelp_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + @"\ayuda.html");
            }
            catch { }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditarUsuario edituser = new frmEditarUsuario();
            edituser.Show();
        }

        private void cmdprint_MouseMove(object sender, MouseEventArgs e)
        {
            Tip.SetToolTip(this.cmdprint, "Imprime ...");
        }

        private void cmderase_MouseMove(object sender, MouseEventArgs e)
        {
            Tip.SetToolTip(this.cmderase, "Elimina un producto ...");
        }

        private void cmdreflescar_MouseMove(object sender, MouseEventArgs e)
        {
            Tip.SetToolTip(this.cmdreflescar, "Reflescar Datos de la grilla");
        }

        private void cmdbuscar_MouseMove(object sender, MouseEventArgs e)
        {
            Tip.SetToolTip(this.cmdbuscar, "Busqueda Avanzada");
        }




    }
}

