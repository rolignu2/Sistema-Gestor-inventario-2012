using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace Delatorre.Modulos
{
    class MotorBusqueda
    {
        #region Motor de busqueda 2.0

        private static Thread HiloBusqueda;

        public static string Cadena = "";
        public static DataGridView Datagrid = null;
        public static int Total = 0;
        public static List<string> ParametrosBusqueda = new List<string>();

        private static int Cont = 0;
        private static Control ctl;
        private static PictureBox picture;
        private static int Contador = 0;

        private static DataTable TablaTemporal;
        private static DataView DataviewTemporal;

        public void InitFunction()
        {
            try
            {
                TablaTemporal = (DataTable)Datagrid.DataSource;
                DataviewTemporal = new DataView(TablaTemporal);
            }
            catch { }
        }

        public void InitFunction(bool CambioDatagrid)
        {
            if (DataviewTemporal == null || CambioDatagrid == true)
            {
                TablaTemporal = (DataTable)Datagrid.DataSource;
                DataviewTemporal = new DataView(TablaTemporal);
            }
        }

        public void GetBusquedaAvanzada_()
        {


            try
            {
                DataTable tabla = new DataTable();
                tabla = TablaTemporal;
                DataView dv = new DataView(tabla);

                foreach (var N in ParametrosBusqueda)
                {
                    try
                    {
                        dv.RowFilter = N + " Like '" + Cadena + "%'";
                        if (dv.Count != 0 || dv.Count == TablaTemporal.Rows.Count)
                            break;
                    }
                    catch
                    {
                        try
                        {
                            int i = 0;
                            bool resultado = int.TryParse(Cadena, out i);
                            if (resultado == true)
                            {
                                dv.RowFilter = N + " =" + i + "";
                                if (dv.Count != 0 || dv.Count == TablaTemporal.Rows.Count)
                                    break;
                            }
                        }
                        catch { }
                    }
                }

                Datagrid.DataSource = dv;

                if (Datagrid.RowCount - 1 >= 1)
                {
                    return;
                }
                else
                {
                    Datagrid.DataSource = DataviewTemporal;
                    GetParametroBusqueda();
                }

            }
            catch { }
        }

        public void GetBusqueda()
        {
            Contador = 0;

            try
            {
                DataTable tabla = new DataTable();
                tabla = TablaTemporal;
                DataView dv = new DataView(tabla);

                foreach (var N in ParametrosBusqueda)
                {
                    try
                    {
                        dv.RowFilter = N + " Like '" + Cadena + "%'";
                        if (dv.Count != 0 || dv.Count == TablaTemporal.Rows.Count)
                            break;
                    }
                    catch
                    {
                        try
                        {
                            int i = 0;
                            bool resultado = int.TryParse(Cadena, out i);
                            if (resultado == true)
                            {
                                dv.RowFilter = N + " =" + i + "";
                                if (dv.Count != 0 || dv.Count == TablaTemporal.Rows.Count)
                                    break;
                            }
                        }
                        catch { }
                    }
                }

                Contador = dv.Count;
                Datagrid.DataSource = dv;

            }
            catch { }
        }

        public int TotalBusqueda()
        {
            return Contador;
        }

        private void GetParametroBusqueda()
        {
            HiloBusqueda = new Thread(delegate()
            {
                try
                {
                    Cont = 0;
                    Datagrid.CurrentCell = null;
                    for (int k = 0; k < Datagrid.RowCount - 1; k++)
                    {
                        DataGridViewBand band = Datagrid.Rows[k];
                        band.Visible = false;
                    }
                }
                catch { }


                try
                {
                    for (int i = 1; i < Datagrid.ColumnCount - 10; i++)
                    {
                        for (int j = 0; j < Datagrid.RowCount - 1; j++)
                        {
                            var comparar = Datagrid[i, j].Value.ToString();
                            if (string.Equals(Cadena, comparar, StringComparison.OrdinalIgnoreCase))
                            {
                                Datagrid.Rows[j].Visible = true;
                                Cont++;
                            }
                            var cadena = Datagrid[i, j].Value.ToString();
                            List<string> concatenar = new List<string>();
                            List<string> caracteres__ = new List<string>();

                            int c = 0;
                            int q = 0;
                            for (c = 0; c < cadena.Length; c++)
                            {
                                if (!(cadena[c].ToString() == " "))
                                    caracteres__.Add(cadena[c].ToString());
                                else
                                    break;
                            }

                            concatenar.Add(string.Join("", caracteres__));
                            caracteres__ = new List<string>();

                            if ((c) == cadena.Length)
                            {
                                if (string.Equals(Cadena, concatenar[0].ToString(), StringComparison.OrdinalIgnoreCase))
                                {
                                    Datagrid.Rows[j].Visible = true;
                                    Cont++;
                                }
                            }
                            else
                            {
                                for (q = c + 1; q < cadena.Length; q++)
                                {
                                    if (cadena[q].ToString() != " ")
                                        caracteres__.Add(cadena[q].ToString());
                                    else
                                        break;
                                }

                                concatenar.Add(string.Join("", caracteres__));
                                caracteres__ = new List<string>();

                                for (int z = 0; z < concatenar.Count; z++)
                                {
                                    if (string.Equals(Cadena, concatenar[z].ToString(), StringComparison.OrdinalIgnoreCase))
                                    {
                                        Datagrid.Rows[j].Visible = true;
                                        Cont++;
                                    }
                                }

                            }

                        }
                    }

                    if (Cadena == string.Empty || Cont == 0)
                    {
                        try
                        {
                            Datagrid.CurrentCell = null;
                            for (int k = 0; k < Datagrid.RowCount - 1; k++)
                            {
                                DataGridViewBand band = Datagrid.Rows[k];
                                band.Visible = false;
                            }
                        }
                        catch { }
                        return;
                    }


                }
                catch { }
            });
            HiloBusqueda.Priority = ThreadPriority.Highest;
            HiloBusqueda.Start();
        }

        public void WaitTimeConfig(Control control, Point p)
        {
            ctl = control;
            picture = new PictureBox();
            picture.Image = Delatorre.Properties.Resources.url;
            picture.Show();
            picture.Size = new Size(100, 100);
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Location = p;
            picture.BringToFront();
            //ctl.Controls.Add(picture);
        }

        public bool IsaliveThreat()
        {
            try
            {
                return HiloBusqueda.IsAlive;
            }
            catch
            {
                return false;
            }
        }

        public bool WaitTime()
        {
            try
            {
                if (HiloBusqueda.IsAlive == false)
                {
                    ctl.Controls.Remove(picture);
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return true;
            }
        }


        #endregion

    }

 
}
