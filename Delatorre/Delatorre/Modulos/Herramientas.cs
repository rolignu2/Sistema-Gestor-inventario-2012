using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace Delatorre.Modulos
{
    class Herramientas
    {

        private  Boolean IsActivate = false;
        private  PictureBox ImagenCargando = new System.Windows.Forms.PictureBox();
       
        public void salir()
        {
            DialogResult diag = MessageBox.Show("¿ DESEA SALIR DEL PROGRAMA ?", "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (diag == DialogResult.Yes)
            {
                Application.Exit();
            }
            else { goto estatus_q; }

        estatus_q:
            Console.WriteLine("se anulo la salida");
            Console.ReadLine();
        }

        public Boolean IsEmail(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public Boolean Loading(Boolean Activo, Control Objeto , Point P , Size T)
        {
            if (IsActivate != true)
            {
                switch (Activo)
                {
                    case true:
                        Point Ubicar = new Point(P.X , P.Y );
                        ImagenCargando.Size = T;
                        ImagenCargando.Image = Delatorre.Properties.Resources.url;
                        ImagenCargando.Location = Ubicar;
                        ImagenCargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        IsActivate = true;
                        Objeto.Controls.Add(ImagenCargando);
                        break;
                    case false:
                        IsActivate = false;
                        Objeto.Controls.Remove(ImagenCargando);
                        break;
                }
            }
            return IsActivate;
        }

        public void DesactivateLoading() { IsActivate = false; }

        public bool Isactivate() { return IsActivate; }

       

    }
}
