using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Delatorre
{
    public partial class Backup_Form : Form
    {
        public Backup_Form()
        {
            InitializeComponent();
        }

        string dir = Directory.GetCurrentDirectory() + @"\backups";
        Delatorre.Modulos.Backup Backup = new Modulos.Backup();
        Thread hilo;
        Dictionary<string, FileInfo> InformacionBackup = new Dictionary<string, FileInfo>();

        private delegate void Estado(int i);

        private void Estado_(int i)
        {
            switch (i)
            {
                case 1:
                    piccargandoCliente.Visible = true;
                    cmdcrearbackup.Enabled = false;
                    cmdrestaurar.Enabled = false;
                    break;
                case 2:
                     piccargandoCliente.Visible = false;
                    cmdcrearbackup.Enabled = true;
                    cmdrestaurar.Enabled = true;
                    break;
            }
        }

        private void Backup_Form_Load(object sender, EventArgs e)
        {
            piccargandoCliente.Visible = false;
            this.Text = "Backup beta";
        
            Listabackups.Text = "Creando lista";
            FileInfo[] sqlfile = Backup.BackupsDisponibles();
            if (sqlfile != null)
            {
                foreach (FileInfo info in sqlfile)
                {
                    Listabackups.Items.Add(info.Name);
                    InformacionBackup.Add(info.Name, info);
                }
            }

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        }

        private void cmdcrearbackup_Click(object sender, EventArgs e)
        {
            hilo = new Thread(delegate()
                {
                    if (!System.IO.Directory.Exists(dir))
                        System.IO.Directory.CreateDirectory(dir);

                    Estado E = new Estado(Estado_);
                    this.Invoke(E, new object[] { 1 });
                    bool IsOk = Backup.GenerarBackup();
                    if (IsOk == true) MessageBox.Show("Copia de seguridad creada con exito");
                    else MessageBox.Show("Error al hacer la copia de seguridad , puede que el servidor este ocupado; intente mas tarde ");
                    this.Invoke(E, new object[] { 2 });
                });
            if (hilo.ThreadState != ThreadState.Running || hilo.ThreadState != ThreadState.WaitSleepJoin)
                hilo.Start();
        }

        private void cmdrestaurar_Click(object sender, EventArgs e)
        {
            string backup_file;
            try
            {
                backup_file = Listabackups.SelectedItem.ToString();
            }
            catch {
                MessageBox.Show("Seleccione archivo a restaurar");
                return;
            }
            hilo = new Thread(delegate()
            {
    
                Estado E = new Estado(Estado_);
                this.Invoke(E, new object[] {1 });
                bool IsOk = Backup.RestaurarBakup(backup_file);
                if (IsOk == true) MessageBox.Show("RESTAURACION COMPLEADA!!!!");
                else MessageBox.Show("El servidor esta ocupado intentar mas tarde ");
                this.Invoke(E, new object[] { 2 });
            });
            if (hilo.ThreadState != ThreadState.Running || hilo.ThreadState != ThreadState.WaitSleepJoin)
                hilo.Start();
        }

        private void Listabackups_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Archivo = Listabackups.SelectedItem.ToString();
            foreach( var Inf in InformacionBackup)
            {
                string llave = Inf.Key;
                FileInfo valor = Inf.Value;
                if( string.Compare(Archivo, llave) == 0 )
                {
                    DateTime FechaHora = valor.CreationTime;
                    lblfecha.Text = FechaHora.ToShortDateString();
                    lblhora.Text = FechaHora.ToShortTimeString();
                    lblnombre.Text = llave;
                }
            }
        }

       

    }
}
