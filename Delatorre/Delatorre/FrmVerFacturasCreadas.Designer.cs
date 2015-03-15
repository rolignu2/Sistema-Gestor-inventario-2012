namespace Delatorre
{
    partial class FrmVerFacturasCreadas
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.calendario = new System.Windows.Forms.MonthCalendar();
            this.cmdbuscar = new System.Windows.Forms.Button();
            this.piccargandoCliente = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listafactura = new System.Windows.Forms.ListBox();
            this.linkverdocumento = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piccargandoCliente)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.piccargandoCliente);
            this.groupBox1.Controls.Add(this.cmdbuscar);
            this.groupBox1.Controls.Add(this.calendario);
            this.groupBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Location = new System.Drawing.Point(15, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 227);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paso 1: Seleccione Fecha ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(345, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sistema De Visualizacion Facturas Delatorre";
            // 
            // calendario
            // 
            this.calendario.Location = new System.Drawing.Point(12, 25);
            this.calendario.Name = "calendario";
            this.calendario.TabIndex = 0;
            this.calendario.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendario_DateChanged);
            // 
            // cmdbuscar
            // 
            this.cmdbuscar.Image = global::Delatorre.Properties.Resources.zoom_icon_161;
            this.cmdbuscar.Location = new System.Drawing.Point(164, 199);
            this.cmdbuscar.Name = "cmdbuscar";
            this.cmdbuscar.Size = new System.Drawing.Size(75, 23);
            this.cmdbuscar.TabIndex = 1;
            this.cmdbuscar.UseVisualStyleBackColor = true;
            this.cmdbuscar.Click += new System.EventHandler(this.cmdbuscar_Click);
            // 
            // piccargandoCliente
            // 
            this.piccargandoCliente.Image = global::Delatorre.Properties.Resources.url;
            this.piccargandoCliente.Location = new System.Drawing.Point(12, 187);
            this.piccargandoCliente.Name = "piccargandoCliente";
            this.piccargandoCliente.Size = new System.Drawing.Size(33, 35);
            this.piccargandoCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.piccargandoCliente.TabIndex = 15;
            this.piccargandoCliente.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.linkverdocumento);
            this.groupBox2.Controls.Add(this.listafactura);
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(271, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(388, 226);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Paso 2:  Seleccionar factura encontrada";
            // 
            // listafactura
            // 
            this.listafactura.FormattingEnabled = true;
            this.listafactura.Items.AddRange(new object[] {
            "No se ha seleccionado Fecha"});
            this.listafactura.Location = new System.Drawing.Point(6, 36);
            this.listafactura.Name = "listafactura";
            this.listafactura.Size = new System.Drawing.Size(376, 160);
            this.listafactura.TabIndex = 0;
            // 
            // linkverdocumento
            // 
            this.linkverdocumento.ActiveLinkColor = System.Drawing.Color.White;
            this.linkverdocumento.AutoSize = true;
            this.linkverdocumento.LinkColor = System.Drawing.Color.Red;
            this.linkverdocumento.Location = new System.Drawing.Point(6, 203);
            this.linkverdocumento.Name = "linkverdocumento";
            this.linkverdocumento.Size = new System.Drawing.Size(139, 13);
            this.linkverdocumento.TabIndex = 1;
            this.linkverdocumento.TabStop = true;
            this.linkverdocumento.Text = "Ver contenido seleccionado";
            this.linkverdocumento.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkverdocumento_LinkClicked);
            // 
            // FrmVerFacturasCreadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(671, 290);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "FrmVerFacturasCreadas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVerFacturasCreadas";
            this.Load += new System.EventHandler(this.FrmVerFacturasCreadas_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.piccargandoCliente)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdbuscar;
        private System.Windows.Forms.MonthCalendar calendario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox piccargandoCliente;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listafactura;
        private System.Windows.Forms.LinkLabel linkverdocumento;
    }
}