using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;
using Delatorre.Modulos;
using CrystalDecisions.Shared;

namespace Delatorre
{
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
        }

        public List<ReporteProdNuevo> listaPnuevo = new List<ReporteProdNuevo>();

        public string Sucursal = null;


        private void Reportes_Load(object sender, EventArgs e)
        {
           
            //ParameterValues Parametros = new ParameterValues();
            try
            {
                ParameterDiscreteValue Pdiscretos = new ParameterDiscreteValue();
                ParameterField Parametro = new ParameterField();
                ParameterFields Parametros = new ParameterFields();
                CrystalProdNuevo CrystalPN = new CrystalProdNuevo();


                Parametro.Name = "sucursal";
                Pdiscretos.Value = "Sucursal " + Sucursal;
                Parametro.CurrentValues.Add(Pdiscretos);

                Parametros.Add(Parametro);

                crystalReportViewer1.ParameterFieldInfo = Parametros;
                crystalReportViewer1.ReportSource = CrystalPN;
                CrystalPN.SetDataSource(listaPnuevo);
            }
            catch (CrystalReportsException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message);
            }
            finally { }
        }

    }
}
