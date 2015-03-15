using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Web;
using System.IO;

namespace Delatorre
{
    public partial class FrmVerFacturasCreadas : Form
    {
        public FrmVerFacturasCreadas()
        {
            InitializeComponent();
        }

        private Modulos.Vistafactura Facturacion = new Modulos.Vistafactura();
        private Thread Hilo , Hilo1;
        private List<object> ListaFacturas = new List<object>();
        private delegate void WaitOne(bool Activo);
        private string fechaselected = "";
        private void WaitOne_(bool activo)
        {
            switch (activo)
            {
                case true:
                    cmdbuscar.Enabled = false;
                    piccargandoCliente.Visible = true;
                    break;
                case false:
                    cmdbuscar.Enabled = true;
                    piccargandoCliente.Visible = false;
                    break;
            }
        }

        private delegate void LlenadoLista(List<object> listado);

        private void LlenadoLista_(List<object> listado)
        {
            if (listado == null)
                return;
            listafactura.Items.Clear();
            for (int i = 0; i < listado.Count; i++)
            {
                object[] objeto = (object[]) listado[i];
                string[] Valores = Array.ConvertAll<object, string>(objeto, Convert.ToString);
                listafactura.Items.Add(string.Join("_", Valores));
            }
        }


        private void FrmVerFacturasCreadas_Load(object sender, EventArgs e)
        {
            this.Text = "Sistema de Visualizacion Facturas";
            piccargandoCliente.Visible = false;
            listafactura.HorizontalScrollbar = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        }

        private void cmdbuscar_Click(object sender, EventArgs e)
        {
            Hilo = new Thread(delegate()
                {
                    WaitOne wait = new WaitOne(WaitOne_);
                    this.Invoke(wait, new object[] { true });
                    ListaFacturas = new List<object>();
                    ListaFacturas = Facturacion.Getfactura(fechaselected);
                    LlenadoLista lista_llenar = new LlenadoLista(LlenadoLista_);
                    this.Invoke(lista_llenar, new object[] { ListaFacturas });
                    this.Invoke(wait, new object[] { false });
                });
            if (Hilo.ThreadState != ThreadState.Running 
                || Hilo.ThreadState != ThreadState.WaitSleepJoin)
                Hilo.Start();
        }

        private void calendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            fechaselected = calendario.SelectionEnd.ToShortDateString();
        }

        private void linkverdocumento_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (listafactura.SelectedItem == null) return;

            string[] DatosVariables =  listafactura.SelectedItem.ToString().Split('_');
            int cantidad = DatosVariables.Length - 1;
            string Id_factura = DatosVariables[cantidad];

            if(!Directory.Exists(Directory.GetCurrentDirectory() + @"/HtmlFacturas"))
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"/HtmlFacturas");
            if (!File.Exists(Directory.GetCurrentDirectory() + @"/HtmlFacturas\" + Id_factura + ".html"))
            {
                File.Create(Directory.GetCurrentDirectory() + @"/HtmlFacturas\" + Id_factura + ".html").Close();
            }
            else
            {
                File.Delete(Directory.GetCurrentDirectory() + @"/HtmlFacturas\" + Id_factura + ".html");
                File.Create(Directory.GetCurrentDirectory() + @"/HtmlFacturas\" + Id_factura + ".html").Close();
            }

          /*  string mysql = "select Factura.venta_total , Factura.venta_nosujeta , Factura.venta_exenta , "
                   + " clientes.nombre , clientes.telefono , clientes.dui, empleados.Nombre , empleados.Apellido ,"
                   + " Factura.fecha , Factura.hora, Factura.idfactura FROM Factura inner join clientes on Factura.id_cliente = clientes.idcliente"
                   + " inner join empleados on Factura.id_empleado= empleados.idempleado Where Factura.fecha='" + FormatoFecha + "'";*/

            Hilo1 = new Thread(delegate()
            {

                StreamWriter EscrituraDatos = new StreamWriter(Directory.GetCurrentDirectory() + @"/HtmlFacturas\" + Id_factura + ".html");
                EscrituraDatos.WriteLine(@"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                EscrituraDatos.WriteLine(@"<html xmlns='http://www.w3.org/1999/xhtml'>");
                EscrituraDatos.WriteLine("<head><meta content='text/html; charset=utf-8' http-equiv='Content-Type' />");
                EscrituraDatos.WriteLine("<title>Factura Seleccionada</title>");
                EscrituraDatos.WriteLine("</head><body>");
                EscrituraDatos.WriteLine("<p align='center'>Vista previa factura Nº <b>" + Id_factura + "</b></p><p></p>");
                EscrituraDatos.WriteLine("<p align='center'>Nombre cliente: <b>" + DatosVariables[3] + "</b></p>");
                EscrituraDatos.WriteLine("<p align='center'>Fecha: <b>" + DatosVariables[8] + "</b></p>");
                EscrituraDatos.WriteLine("<p align='center'>Hora: <b>" + DatosVariables[9] + "</b></p>");
                EscrituraDatos.WriteLine("<p align='center'>Telefono: <b>" + DatosVariables[4] + "</b></p>");
                EscrituraDatos.WriteLine("<p align='center'>Dui/Nit: <b>" + DatosVariables[5] + "</b></p>");
                EscrituraDatos.WriteLine("<p></p><p align='center'>Empleado que atendio: <b>"
                    + DatosVariables[6] + " " + DatosVariables[7] + "</b></p>");

                List<object> ObjetoDetalle = Facturacion.GetDetallFactura(Id_factura);
                List<string[]> ListaDetalle = new List<string[]>();
                foreach (object[] obj in ObjetoDetalle)
                    ListaDetalle.Add(Array.ConvertAll<object, string>(obj , Convert.ToString));
         

                EscrituraDatos.WriteLine("<table align='center' border='1' style='border:medium'>");
                EscrituraDatos.WriteLine("<tr>");
                EscrituraDatos.WriteLine("<td bgcolor='aqua'>Codigo Producto</td>");
                EscrituraDatos.WriteLine("<td bgcolor='aqua'>Producto</td>");
                EscrituraDatos.WriteLine("<td bgcolor='aqua'>Precio ($)</td>");
                EscrituraDatos.WriteLine("<td bgcolor='aqua'>Cantidad</td>");
                EscrituraDatos.WriteLine("<td bgcolor='aqua'>Descuento (%)</td>");
                EscrituraDatos.WriteLine("<td bgcolor='aqua'>garantia</td>");
                EscrituraDatos.WriteLine("</tr>");
                for (int i = 0; i < ListaDetalle.Count; i++)
                {
                    string[] datalles__ = ListaDetalle[i];
                    EscrituraDatos.WriteLine("<tr>");
                    for(int j =0; j < datalles__.Length;j++)
                        EscrituraDatos.WriteLine("<td>" + datalles__[j] + "</td>");
                    EscrituraDatos.WriteLine("</tr>");
                }
                EscrituraDatos.WriteLine("</table>");

                EscrituraDatos.WriteLine("<p align='center'>Venta Total: <b>" + DatosVariables[0] + "</b></p>");
                EscrituraDatos.WriteLine("<p align='center'>Ventas Exentas: <b>" + DatosVariables[1] + "</b></p>");
                EscrituraDatos.WriteLine("<p align='center'>Ventas no sujetas: <b>" + DatosVariables[2] + "</b></p>");
                EscrituraDatos.WriteLine("<p></p><input type='button' align='center' onclick='window.print();' value='Imprimir' />");
                EscrituraDatos.WriteLine("</body>");
                EscrituraDatos.WriteLine("</html>");

                EscrituraDatos.Close();

                System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + @"/HtmlFacturas\" + Id_factura + ".html");
            });
            if (Hilo1.ThreadState != ThreadState.Running || Hilo1.ThreadState != ThreadState.WaitSleepJoin)
                Hilo1.Start();
        }
    }
}
