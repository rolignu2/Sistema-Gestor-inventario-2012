using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.IO;


namespace Delatorre.Modulos 
{
    class Backup
    {

        private string DirBackup()
        {
            string formato = DateTime.Now.ToShortDateString().Replace('/', '_') 
               + "_"  + DateTime.Now.ToShortTimeString().Replace(':' , '_');
            string nombre = "DtB_" + formato + ".sql";
            string direccion = System.IO.Directory.GetCurrentDirectory() + @"/backups\" + nombre;
            return direccion;
        }

        private string dirfile() { return System.IO.Directory.GetCurrentDirectory() + @"/backups\"; }

        public Backup()
        {
            try
            {
                if (!Directory.Exists(dirfile()))
                {
                    Directory.CreateDirectory(dirfile());
                }
            }
            catch { }
        }
     
        public bool GenerarBackup()
        {
            try
            {
             
                MySqlBackup Backup = new MySqlBackup(Conexion.GetDireccion());
                Backup.ExportInfo.FileName = DirBackup();
                Backup.Export();
                return true;
            }
            catch {
                return false;
            }

        }

        public bool RestaurarBakup(string archivo)
        {

            try
            {
                MySqlBackup Backup = new MySqlBackup(Conexion.GetDireccion());
                Backup.ImportInfo.FileName = dirfile() + archivo;
                Backup.Import();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public System.IO.FileInfo[] BackupsDisponibles()
        {
            DirectoryInfo dirinfo = new DirectoryInfo(System.IO.Directory.GetCurrentDirectory() + @"/backups\");
            if (dirinfo.Exists == true)
                return dirinfo.GetFiles();
            else
                return null;
        }
        
    }
}
