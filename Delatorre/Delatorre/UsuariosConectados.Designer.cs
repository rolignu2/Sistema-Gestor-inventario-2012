namespace Delatorre
{
    partial class UsuariosConectados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ListaUsuarios = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TcargaDatos = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListaUsuarios
            // 
            this.ListaUsuarios.Location = new System.Drawing.Point(0, 0);
            this.ListaUsuarios.Name = "ListaUsuarios";
            this.ListaUsuarios.Size = new System.Drawing.Size(270, 195);
            this.ListaUsuarios.TabIndex = 0;
            this.ListaUsuarios.UseCompatibleStateImageBehavior = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ListaUsuarios);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 200);
            this.panel1.TabIndex = 1;
            // 
            // TcargaDatos
            // 
            this.TcargaDatos.Tick += new System.EventHandler(this.TcargaDatos_Tick);
            // 
            // UsuariosConectados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(293, 218);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "UsuariosConectados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UsuariosConectados";
            this.Load += new System.EventHandler(this.UsuariosConectados_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ListaUsuarios;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer TcargaDatos;
    }
}