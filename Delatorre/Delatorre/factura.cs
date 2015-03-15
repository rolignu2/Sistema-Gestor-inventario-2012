using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions;
using CrystalDecisions.Shared;

namespace Delatorre
{
    public partial class factura : Form
    {


        public List<Modulos.Factura> ListaFactura = new List<Modulos.Factura>();
        public List<string> ParametrosDiscretos = new List<string>();

        public factura()
        {
            InitializeComponent();
            ListaFactura = new List<Modulos.Factura>();
            ParametrosDiscretos = new List<string>();
        }

        private void factura_Load(object sender, EventArgs e)
        {
            GetFactura();
        }

        private string[] keys = new string[] 
        { "nombre",
            "direccion" 
            ,"nit_dui", 
            "acuenta_de","sumas" 
            ,"venta_no_sujetas" 
            ,  "Venta_exenta" 
            , "total"};

        private void GetFactura()
        {

            ParameterDiscreteValue[] Pdiscretos = new ParameterDiscreteValue[8];
            ParameterField[] Parametro = new ParameterField[8];
            ParameterFields Parametros = new ParameterFields();
            RepFactura ReportFactura = new RepFactura();

            for (int i = 0; i < 8; i++)
            {
                Parametro[i] = new ParameterField();
                Pdiscretos[i] = new ParameterDiscreteValue();
            }

            for (int k = 0; k < 8; k++)
            {
                Parametro[k].Name = keys[k];
                Pdiscretos[k].Value = ParametrosDiscretos[k];
                Parametro[k].CurrentValues.Add(Pdiscretos[k]);
                Parametros.Add(Parametro[k]);
            }

            crystalReportViewer1.ParameterFieldInfo = Parametros;
            crystalReportViewer1.ReportSource = ReportFactura;
            ReportFactura.SetDataSource(ListaFactura);

        }
    }
}
