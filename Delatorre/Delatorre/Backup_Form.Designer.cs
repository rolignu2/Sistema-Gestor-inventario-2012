namespace Delatorre
{
    partial class Backup_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Backup_Form));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdrestaurar = new System.Windows.Forms.Button();
            this.piccargandoCliente = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdcrearbackup = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblhora = new System.Windows.Forms.Label();
            this.lblfecha = new System.Windows.Forms.Label();
            this.lblnombre = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Listabackups = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piccargandoCliente)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdrestaurar);
            this.groupBox1.Controls.Add(this.piccargandoCliente);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmdcrearbackup);
            this.groupBox1.Location = new System.Drawing.Point(12, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 152);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmdrestaurar
            // 
            this.cmdrestaurar.ForeColor = System.Drawing.Color.Black;
            this.cmdrestaurar.Image = ((System.Drawing.Image)(resources.GetObject("cmdrestaurar.Image")));
            this.cmdrestaurar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdrestaurar.Location = new System.Drawing.Point(6, 83);
            this.cmdrestaurar.Name = "cmdrestaurar";
            this.cmdrestaurar.Size = new System.Drawing.Size(183, 23);
            this.cmdrestaurar.TabIndex = 16;
            this.cmdrestaurar.Text = "Restaurar backup";
            this.cmdrestaurar.UseVisualStyleBackColor = true;
            this.cmdrestaurar.Click += new System.EventHandler(this.cmdrestaurar_Click);
            // 
            // piccargandoCliente
            // 
            this.piccargandoCliente.Image = global::Delatorre.Properties.Resources.url;
            this.piccargandoCliente.Location = new System.Drawing.Point(84, 112);
            this.piccargandoCliente.Name = "piccargandoCliente";
            this.piccargandoCliente.Size = new System.Drawing.Size(26, 27);
            this.piccargandoCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.piccargandoCliente.TabIndex = 15;
            this.piccargandoCliente.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Propiedades:";
            // 
            // cmdcrearbackup
            // 
            this.cmdcrearbackup.ForeColor = System.Drawing.Color.Black;
            this.cmdcrearbackup.Image = global::Delatorre.Properties.Resources.doc_export_icon_161;
            this.cmdcrearbackup.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdcrearbackup.Location = new System.Drawing.Point(6, 43);
            this.cmdcrearbackup.Name = "cmdcrearbackup";
            this.cmdcrearbackup.Size = new System.Drawing.Size(183, 23);
            this.cmdcrearbackup.TabIndex = 5;
            this.cmdcrearbackup.Text = "Crear backup";
            this.cmdcrearbackup.UseVisualStyleBackColor = true;
            this.cmdcrearbackup.Click += new System.EventHandler(this.cmdcrearbackup_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblhora);
            this.groupBox2.Controls.Add(this.lblfecha);
            this.groupBox2.Controls.Add(this.lblnombre);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.Listabackups);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(213, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 152);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // lblhora
            // 
            this.lblhora.AutoSize = true;
            this.lblhora.ForeColor = System.Drawing.Color.White;
            this.lblhora.Location = new System.Drawing.Point(232, 98);
            this.lblhora.Name = "lblhora";
            this.lblhora.Size = new System.Drawing.Size(49, 13);
            this.lblhora.TabIndex = 6;
            this.lblhora.Text = "_______";
            // 
            // lblfecha
            // 
            this.lblfecha.AutoSize = true;
            this.lblfecha.ForeColor = System.Drawing.Color.White;
            this.lblfecha.Location = new System.Drawing.Point(246, 72);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.Size = new System.Drawing.Size(49, 13);
            this.lblfecha.TabIndex = 5;
            this.lblfecha.Text = "_______";
            // 
            // lblnombre
            // 
            this.lblnombre.ForeColor = System.Drawing.Color.White;
            this.lblnombre.Location = new System.Drawing.Point(246, 27);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(89, 39);
            this.lblnombre.TabIndex = 4;
            this.lblnombre.Text = "_______";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(193, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Hora:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(193, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Creacion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(193, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nombre:";
            // 
            // Listabackups
            // 
            this.Listabackups.FormattingEnabled = true;
            this.Listabackups.Location = new System.Drawing.Point(6, 16);
            this.Listabackups.Name = "Listabackups";
            this.Listabackups.Size = new System.Drawing.Size(181, 121);
            this.Listabackups.TabIndex = 0;
            this.Listabackups.SelectedIndexChanged += new System.EventHandler(this.Listabackups_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Sistema de seguridad base de datos delatorre";
            // 
            // Backup_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(567, 191);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Backup_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup_Form";
            this.Load += new System.EventHandler(this.Backup_Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piccargandoCliente)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdcrearbackup;
        private System.Windows.Forms.PictureBox piccargandoCliente;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cmdrestaurar;
        private System.Windows.Forms.ListBox Listabackups;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblhora;
        private System.Windows.Forms.Label lblfecha;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}