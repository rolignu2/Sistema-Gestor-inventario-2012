using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Data;

namespace Delatorre.Modulos
{
    class Notificaciones
    {

        private  System.Threading.Thread __TareaNotificacion ;


        private MySqlCommand CMD;
        private MySqlDataReader Lector;
        private MySqlDataAdapter Adapter;
        private DataSet Ds;
        private DataTable Tabla;
        private String SqlQuery;
        private String SqlNonQuery;
        private MySqlConnection Conn;

        private List<string[]> NotificacionesEnCola;
        private List<string[]> ErrorNotificacion;

        private bool bandera = true;

        /*Prioridades para los iconos de notificacion
         
         * inicio sesion = 0
         * cerrar sesion = 1
         * venta = 2
         * producto agotado = 3
         * producto desactivado = 4
         * producto no existente = 5
         * impresion = 6
         */
       


        public Notificaciones()
        {
            Task tarea = new Task(delegate()
            {
                try
                {

                    NotificacionesEnCola = new List<string[]>();
                    ErrorNotificacion = new List<string[]>();
                    Conn = new MySqlConnection(Conexion.GetDireccion());
                    Conn.Open();
                }
                catch { }
            });
            tarea.Start();
        }

        public Boolean SetNotificacion(string ValorNotificacion , int Prioridad , string idsucursal)
        {

            Random rnd = new Random(DateTime.Now.Millisecond);
            var Id = "NTNP" + rnd.Next(0, 999).ToString() + rnd.Next(0, 999).ToString() + rnd.Next(0, 999).ToString() + rnd.Next(0, 999).ToString(); 
            string Hora = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;

            MySqlDataReader Lector_ = null;
            MySqlCommand CMD_;

            Seguridad security = new Seguridad();
            string FechaFormato = security.FormatoFecha(DateTime.Now.ToShortDateString());

            SqlNonQuery = "insert into Notificacion (idnotificacion , Notificacion , Hora , Fecha , idusuario , prioridad , idsucursal)"
                + "values ('" + Id + "','" +
                ValorNotificacion + "','" +
                Hora + "'," +
                "'"+ FechaFormato +
                "','" + Datos.Idusuario + "','" + Prioridad + "','" + idsucursal + "')" ;

            try
            {
                if (__TareaNotificacion.IsAlive == true) return false;
            }
            catch { }

            __TareaNotificacion = new System.Threading.Thread(delegate()
                {
                    MySqlConnection Conn_ = new MySqlConnection(Conexion.GetDireccion());

                    try
                    {

                        if (Conn_.State == System.Data.ConnectionState.Closed)
                        {
                            Conn_ = new MySqlConnection(Conexion.GetDireccion());
                            Conn_.Open();
                        }
                        else if (Conn_.State == System.Data.ConnectionState.Broken)
                        {
                            Conn_ = new MySqlConnection(Conexion.GetDireccion());
                            Conn_.Open();
                        }

                        CMD_ = new MySqlCommand(SqlNonQuery, Conn_);

                        try
                        {
                            try
                            {
                                if (CMD_.ExecuteReader() == null && Lector == null)
                                {
                                    Conn_.Close();
                                    Conn_.Open();
                                    CMD_ = new MySqlCommand(SqlNonQuery, Conn_);
                                }

                            }
                            catch { }

                            Lector_ = CMD_.ExecuteReader();

                            if (Lector.RecordsAffected <= -1)
                            {
                                ErrorNotificacion = new List<string[]>();
                                Conn_.Close();
                                bandera = false;
                            }
                            else bandera = true;

                        }
                        catch { }
                    }
                    catch (MySqlException ex)
                    {

                        ErrorNotificacion.Add(new string[] { "Error al recibir notificaciones || " + ex.Message });

                        Conn_.Close();

                        bandera = false;
                    }
                    catch { }

                    try
                    {
                        Conn_.Close();
                    }
                    catch { }
           

                });
            __TareaNotificacion.Start();

            return true;
        }

        public List<string[]> GetNotificaciones(string idsucursal)
        {
           Reintento:
            try
            {
                /*if (ErrorNotificacion.Count >= 1)
                {
                    return ErrorNotificacion;
                }*/
                    

                    if (Conn.State == System.Data.ConnectionState.Closed)
                    {
                        Conn = new MySqlConnection(Conexion.GetDireccion());
                        Conn.Open();
                    }
                    else if (Conn.State == System.Data.ConnectionState.Executing)
                    {
                        Conn = new MySqlConnection(Conexion.GetDireccion());
                        Conn.Open();
                    }
                    else if (Conn.State == ConnectionState.Broken)
                    {
                        Conn = new MySqlConnection(Conexion.GetDireccion());
                        Conn.Open();
                    }

                    Seguridad security = new Seguridad();
                    string FechaFormato = security.FormatoFecha(DateTime.Now.ToShortDateString());

                    SqlQuery = "Select Notificacion.Notificacion , Notificacion.Hora , Notificacion.Fecha , empleados.Nombre , empleados.Apellido , Notificacion.prioridad"
                        + " From Notificacion INNER JOIN empleados ON Notificacion.idusuario = empleados.idusuario Where Fecha ='"
                        + FechaFormato + "' And Notificacion.idsucursal ='" + idsucursal + "' ORDER BY Notificacion.Hora asc";

                    Ds = new DataSet();
                    Tabla = new DataTable();

                    Adapter = new MySqlDataAdapter(SqlQuery, Conn);
                    System.Threading.Thread.Sleep(500);
                    Adapter.Fill(Ds);
                    Tabla = Ds.Tables[0];
                    NotificacionesEnCola = new List<string[]>();

                    foreach (DataRow Dr in Tabla.Rows)
                    {
                        var Notificacion = Dr.Field<string>("Notificacion", DataRowVersion.Default);
                        var Hora = Dr.Field<TimeSpan>("Hora", DataRowVersion.Default);
                        var Fecha = Dr.Field<DateTime>("Fecha", DataRowVersion.Default);
                        var Nombre = Dr.Field<string>("Nombre", DataRowVersion.Default);
                        var Apellido = Dr.Field<string>("Apellido", DataRowVersion.Default);
                        var prioridad = Dr.Field<int>("prioridad", DataRowVersion.Default);
                        string[] datos = { Notificacion, Hora.ToString(), Fecha.ToShortDateString(), Nombre, Apellido, prioridad.ToString() };
                        NotificacionesEnCola.Add(datos);
                    }

                    Conn.Close();
           
            }
            catch 
            {
                try
                {
                    Conn.Close();
                    goto Reintento;
                }
                catch { }
            }
            
            if (NotificacionesEnCola.Count == 0)
            {
                List<string[]> S = new List<string[]>();
               S.Add( new string[] {"No hay Notificaciones"});
               return S;
            }
            Conn.Close();
            return NotificacionesEnCola;
        }

        public List<string[]> GetNotificaciones(string idsucursal , string fecha , string fecha1 , string usuario , int E)
        {
        Reintento:
            try
            {
   
                if (Conn.State == System.Data.ConnectionState.Closed)
                {
                    Conn = new MySqlConnection(Conexion.GetDireccion());
                    Conn.Open();
                }
                else if (Conn.State == System.Data.ConnectionState.Executing)
                {
                    Conn = new MySqlConnection(Conexion.GetDireccion());
                    Conn.Open();
                }
                else if (Conn.State == ConnectionState.Broken)
                {
                    Conn = new MySqlConnection(Conexion.GetDireccion());
                    Conn.Open();
                }

                switch (E)
                {
                    case 1:
                        SqlQuery = "Select Notificacion.Notificacion , Notificacion.Hora , Notificacion.Fecha , empleados.Nombre , empleados.Apellido , Notificacion.prioridad"
                            + " From Notificacion INNER JOIN empleados ON Notificacion.idusuario = empleados.idusuario" 
                            +" Where DATE(Notificacion.Fecha) BETWEEN '"
                            + fecha + "' and '" + fecha1 + "'";
                        break;
                    case 2:
                        SqlQuery = "Select Notificacion.Notificacion , Notificacion.Hora , Notificacion.Fecha , empleados.Nombre , empleados.Apellido , Notificacion.prioridad"
                         + " From Notificacion LEFT JOIN empleados ON Notificacion.idusuario = empleados.idusuario" +
                         " where Notificacion.idusuario ='" + usuario + "'";
                        break;
                    case 3:
                        SqlQuery = "Select Notificacion.Notificacion , Notificacion.Hora , Notificacion.Fecha , empleados.Nombre , empleados.Apellido , Notificacion.prioridad"
                    + " From Notificacion INNER JOIN empleados ON Notificacion.idusuario = empleados.idusuario Where Notificacion.idsucursal LIKE '" + idsucursal + "'";
                        break;
                }


      

                Ds = new DataSet();
                Tabla = new DataTable();

                Adapter = new MySqlDataAdapter(SqlQuery, Conn);
                System.Threading.Thread.Sleep(500);
                Adapter.Fill(Ds);
                Tabla = Ds.Tables[0];
                NotificacionesEnCola = new List<string[]>();

                foreach (DataRow Dr in Tabla.Rows)
                {
                    var Notificacion = Dr.Field<string>("Notificacion", DataRowVersion.Default);
                    var Hora = Dr.Field<TimeSpan>("Hora", DataRowVersion.Default);
                    var Fecha = Dr.Field<DateTime>("Fecha", DataRowVersion.Default);
                    var Nombre = Dr.Field<string>("Nombre", DataRowVersion.Default);
                    var Apellido = Dr.Field<string>("Apellido", DataRowVersion.Default);
                    var prioridad = Dr.Field<int>("prioridad", DataRowVersion.Default);
                    string[] datos = { Notificacion, Hora.ToString(), Fecha.ToShortDateString(), Nombre, Apellido, prioridad.ToString() };
                    NotificacionesEnCola.Add(datos);
                }

                Conn.Close();

            }
            catch
            {
                try
                {
                    Conn.Close();
                    goto Reintento;
                }
                catch { }
            }

            if (NotificacionesEnCola.Count == 0)
            {
                List<string[]> S = new List<string[]>();
                S.Add(new string[] { "No hay Notificaciones" });
                return S;
            }
            Conn.Close();
            return NotificacionesEnCola;
        }

        public int GetCountNotifiaciones() { return NotificacionesEnCola.Count; }

        public bool Isalive()
        {
            return __TareaNotificacion.IsAlive;
        }

        public bool IsNotError() { return bandera; }

    }
}
