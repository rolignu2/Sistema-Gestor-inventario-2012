using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Data;

namespace Delatorre.Modulos
{
    class Vistafactura
    {

        private MySqlConnection conn;
        private MySqlDataAdapter adaptador;
        private List<object> NumeroFactura;
        private List<object> ListDetalleFactura;
        private Semaphore semaforo = new Semaphore(1, 1);
        private Seguridad seguridad = new Seguridad();

        public List<object> Getfactura(string fecha)
        {
            NumeroFactura = new List<object>();

            try
            {
                semaforo.WaitOne();
                conn = new MySqlConnection(Modulos.Conexion.GetDireccion());
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open();

                string FormatoFecha = seguridad.FormatoFecha(fecha);
                //string mysql = "Select * from Factura where fecha='" + FormatoFecha + "'";
                string mysql = "select Factura.venta_total , Factura.venta_nosujeta , Factura.venta_exenta , " 
                    + " clientes.nombre , clientes.telefono , clientes.dui, empleados.Nombre , empleados.Apellido ,"
                    + " Factura.fecha , Factura.hora, Factura.idfactura FROM Factura inner join clientes on Factura.id_cliente = clientes.idcliente"
                    + " inner join empleados on Factura.id_empleado= empleados.idempleado Where Factura.fecha='" + FormatoFecha + "'";

                adaptador = new MySqlDataAdapter(mysql, conn);
                DataSet ds = new DataSet();
                adaptador.Fill(ds);
                DataTable tabla = new DataTable();
                tabla = ds.Tables[0];

                foreach (DataRow rows in tabla.Rows)
                {
                    var Valores = rows.ItemArray;
                    NumeroFactura.Add(Valores);
                }

                conn.Close();
                semaforo.Release();

            }
            catch {
                conn.Close();
                return NumeroFactura = null;
            }

            return NumeroFactura;
        }

        public List<object> GetDetallFactura(string idfactura)
        {
            ListDetalleFactura = new List<object>();
            try
            {
                semaforo.WaitOne();
                conn = new MySqlConnection(Modulos.Conexion.GetDireccion());
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open();

                string mysql = "Select cod_producto ,producto,precio,cantidad,descuentos,garantia from detalle_factura where id_factura='" + idfactura + "'";


                adaptador = new MySqlDataAdapter(mysql, conn);
                DataSet ds = new DataSet();
                adaptador.Fill(ds);
                DataTable tabla = new DataTable();
                tabla = ds.Tables[0];

                foreach (DataRow rows in tabla.Rows)
                {
                    var Valores = rows.ItemArray;
                    ListDetalleFactura.Add(Valores);
                }

                conn.Close();
                semaforo.Release();

            }
            catch
            {
                conn.Close();
                return ListDetalleFactura = null;
            }

            return ListDetalleFactura;
        }
    }
}
