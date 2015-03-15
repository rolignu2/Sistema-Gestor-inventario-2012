using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Delatorre.Modulos
{
    class CarritoDeCompra
    {

        private DataGridView Grilla = null;

        public CarritoDeCompra(DataGridView DataGrillaSourse)
        {
            Grilla = DataGrillaSourse;
        }

        public void ObtenerDatosEngrilla(List<string[]> Valores)
        {
            if (Grilla.ColumnCount <= 0)
            {
                Grilla.Columns.Add("codigo", "Cod Producto");
                Grilla.Columns.Add("nombre", "Producto");
                Grilla.Columns.Add("precio", "Precio Producto");
                Grilla.Columns.Add("cantidad", "Cantidad");
                Grilla.Columns.Add("descuentos", "Descuentos");
                Grilla.Columns.Add("garantia", "Garantia");
            }

            if (Grilla.RowCount >= 1)
            {
                Grilla.Rows.Clear();
            }

            for (int i = 0; i < Valores.Count; i++)
            {
                Grilla.Rows.Add(Valores[i]);
            }

        }

        public decimal TotalCantidadProductos()
        {
            decimal total = 0.0M;

            try
            {
                for (int i = 0; i < Grilla.Rows.Count - 1; i++)
                {
                    total += Convert.ToDecimal(Grilla[2, i].Value.ToString());
                }
            }
            catch { }

            return total;
        }

        //public bool RealizarVenta();
    }
}
