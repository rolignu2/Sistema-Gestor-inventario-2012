using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Net;
using System.Timers;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;



namespace Delatorre.Modulos
{
    
    class Seguridad
    {

        private List<Control> Controles;
        private Control.ControlCollection Controls;
        private Stopwatch TimeRespuesta;


        public void SetControles(List<Control> Control)
        {
            this.Controles = Control;
        }

        public bool GetControlisEmpty()
        {

            bool Bandera = false;

            for (int i = 0; i < this.Controles.Count; i++)
            {

              Type TipoControl = Controles[i].GetType();

              if (TipoControl == typeof(TextBox))
              {
                  TextBox txt = (TextBox)Controles[i];
                  if (txt.Text == "")
                  {
                      txt.BackColor = Color.Red;
                      Controles[i] = txt;
                      Bandera = true;
                  }
                  else
                  {
                      txt.BackColor = Color.White;
                      Controles[i] = txt;
                  }
              }
              else if (TipoControl == typeof(ComboBox))
              {
                  ComboBox combo = (ComboBox)Controles[i];
                  if (combo.Text == "")
                  {
                      combo.BackColor = Color.Red;
                      Controles[i] = combo;
                      Bandera = true;
                  }
                  else
                  {
                      combo.BackColor = Color.White;
                      Controles[i] = combo;
                  }
              }
              else if (TipoControl == typeof(DateTimePicker))
              {
                  DateTimePicker date = (DateTimePicker)Controles[i];
                  if (date.Text == "" )
                  {
                      date.BackColor = Color.Red;
                      Controles[i] = date;
                      Bandera = true;
                  }
                  else
                  {
                      date.BackColor = Color.White;
                      Controles[i] = date;
                  }
              }
              else if (TipoControl == typeof(MaskedTextBox))
              {
                  MaskedTextBox mtxt = (MaskedTextBox)Controles[i];
                  if (mtxt.Text == "" || mtxt.Text == null)
                  {
                      mtxt.BackColor = Color.Red;
                      Controles[i] = mtxt;
                      Bandera = true;
                  }
                  else
                  {
                      mtxt.BackColor = Color.White;
                      Controles[i] = mtxt;
                  }
              }


            }

            return Bandera;
        }

        public void EliminarCampos(Control.ControlCollection Controles)
        {
            this.Controls = Controles;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                Type TipoControl = this.Controls[i].GetType();
                if (TipoControl == typeof(GroupBox))
                {
                    GroupBox group = (GroupBox)this.Controls[i];
                    for (int j = 0; j < group.Controls.Count; j++)
                    {
                        Type TipoSubcontrol = group.Controls[j].GetType();

                        if (TipoSubcontrol == typeof(TextBox)
                            || TipoSubcontrol == typeof(MaskedTextBox)
                            || TipoSubcontrol == typeof(ComboBox))
                        {
                            try
                            {
                                TextBox txt = (TextBox)group.Controls[j];
                                txt.Text = "";
                            }
                            catch
                            {
                                try
                                {
                                    ComboBox txt = (ComboBox)group.Controls[j];
                                    txt.Text = "";
                                }
                                catch
                                {
                                    MaskedTextBox txt = (MaskedTextBox)group.Controls[j];
                                    txt.Text = "";
                                }
                            }
                        }

                    }
                }
                else
                {
                    if (TipoControl == typeof(TextBox)
                           || TipoControl == typeof(MaskedTextBox)
                           || TipoControl == typeof(ComboBox))
                    {
                        try
                        {
                            TextBox txt = (TextBox)this.Controls[i];
                            txt.Text = "";
                        }
                        catch
                        {
                            try
                            {
                                ComboBox txt = (ComboBox)this.Controls[i];
                                txt.Text = "";
                            }
                            catch
                            {
                                MaskedTextBox txt = (MaskedTextBox)this.Controls[i];
                                txt.Text = "";
                            }
                        }
                    }
                }
            }
        }

        public bool ExisteDatosEnBdd(string SQL)
        {
            try
            {
                MySqlConnection Conn = Conexion.GetConexion();

                if (Conn.State == System.Data.ConnectionState.Closed)
                {
                    Conn = new MySqlConnection(Conexion.GetDireccion());
                    Conn.Open();
                }
                else if (Conn.State == System.Data.ConnectionState.Broken)
                {
                    Conn = new MySqlConnection(Conexion.GetDireccion());
                    Conn.Open();
                }

                MySqlCommand Command = new MySqlCommand(SQL, Conn);
                MySqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read() == true)
                {
                    Conn.Close();
                    return true;
                }
                else
                {
                    Conn.Close();
                    return false;
                }
            }
            catch { }

            return true;
        }

        public bool IsDecimalNumber(string cadena)
        {

            int longitud = cadena.Length;
            bool Isdec = false;
            bool Isnumber = false;
            int numero =0;

            for (int i = 0; i < longitud; i++)
            {
                Isnumber = int.TryParse(cadena[i].ToString(), out numero);
                if (Isnumber == false)
                {
                    if (cadena[i].ToString() == ".")
                    {
                        if (Isdec == true) 
                             return false;
                        else
                             Isdec = true;
                    }
                    else
                    {
                        if (cadena[i].ToString() == ",")
                        {
                            cadena.Replace(',', '.');
                            Isdec = true;
                        }
                        else
                            return false;
                    }
                }
            }

            return true;

        }

        public string FormatoFecha(string fecha)
        {
         string Formato = string.Format("{0:yyyy-MM-dd}",Convert.ToDateTime(fecha));
          return Formato;
        }

        public string ConversionPrecios(string valor)
        {
            string[] ConversionPrecio = new string[valor.Length];

            if (valor == "" || valor == null)
                return "0.00";
            else
            {
                for (int k = 0; k < valor.Length; k++)
                {
                    if (valor[k] == ',')
                        ConversionPrecio[k] = ".";
                    else
                        ConversionPrecio[k] = valor[k].ToString();
                }
                return string.Join("", ConversionPrecio);
            }
        }

        /// <summary>
        ///  estado de conexion
        /// </summary>
        /// <returns> devuelve 0 si esta estable , 1 si es inestable y 2 si no existe</returns>
        public int EstadoConexionInternet()
        {

            TimeRespuesta = new Stopwatch();

            try
            {
                TimeRespuesta.Start();
               // WebRequest g = HttpWebRequest.Create("http://www.google.com.sv");
               // g.Timeout = Convert.ToInt32(30 / (0.001));
                //WebResponse response = g.GetResponse();
                //Create ping object
                Ping netMon = new Ping();
                PingReply P = netMon.Send(IPAddress.Parse("190.150.50.170"));
                TimeRespuesta.Stop();
            }
            catch 
            {
                TimeRespuesta.Stop();

                try {
                    IPHostEntry iph = Dns.GetHostEntry("www.google.com");
                    return 1;
                }
                catch { return 2; }
                
            }

            double Tiempoml = TimeRespuesta.ElapsedMilliseconds;
            double Segundos = (Tiempoml * 0.001);

            if (Segundos >= 3)
                return 1;
            else
                return 0;
        }

        

    }
}
