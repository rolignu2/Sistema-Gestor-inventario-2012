using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Delatorre.Modulos
{
    class Errores
    {


        private static List<object> ListaErrores = new List<object>();

        public static void SetErrores(object error)
        {
            ListaErrores.Add(error);
        }

        public static List<object> GetErrores()
        {
            return ListaErrores;
        }


        public static void MostrarNumeroErrores()
        {
            if (ListaErrores.Count >= 1)
            {
                DialogResult resultado = MessageBox.Show("Se ha presentado " +
                    ListaErrores.Count + " error(es) durante la carga ¿desea continuar?", "Error",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resultado == DialogResult.No)
                    Application.Exit();
            }
        }
    }

    
}
