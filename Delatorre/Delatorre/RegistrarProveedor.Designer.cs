namespace Delatorre
{
    partial class RegistrarProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarProveedor));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdexit = new System.Windows.Forms.Button();
            this.Cmdregistrar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtwebdir = new System.Windows.Forms.TextBox();
            this.txttelefono = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdireccion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cmdexit);
            this.groupBox1.Controls.Add(this.Cmdregistrar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtwebdir);
            this.groupBox1.Controls.Add(this.txttelefono);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtdireccion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtnombre);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(43, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 247);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro de Proveedor        (*)Campos Obligatorios";
            // 
            // cmdexit
            // 
            this.cmdexit.ForeColor = System.Drawing.Color.Black;
            this.cmdexit.Location = new System.Drawing.Point(87, 218);
            this.cmdexit.Name = "cmdexit";
            this.cmdexit.Size = new System.Drawing.Size(80, 23);
            this.cmdexit.TabIndex = 10;
            this.cmdexit.Text = "Cerrar";
            this.cmdexit.UseVisualStyleBackColor = true;
            this.cmdexit.Click += new System.EventHandler(this.cmdexit_Click);
            // 
            // Cmdregistrar
            // 
            this.Cmdregistrar.ForeColor = System.Drawing.Color.Black;
            this.Cmdregistrar.Location = new System.Drawing.Point(186, 218);
            this.Cmdregistrar.Name = "Cmdregistrar";
            this.Cmdregistrar.Size = new System.Drawing.Size(80, 23);
            this.Cmdregistrar.TabIndex = 9;
            this.Cmdregistrar.Text = "Registrar";
            this.Cmdregistrar.UseVisualStyleBackColor = true;
            this.Cmdregistrar.Click += new System.EventHandler(this.Cmdregistrar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Sitio Web o Correo Electronico";
            // 
            // txtwebdir
            // 
            this.txtwebdir.Location = new System.Drawing.Point(18, 179);
            this.txtwebdir.Name = "txtwebdir";
            this.txtwebdir.Size = new System.Drawing.Size(212, 20);
            this.txtwebdir.TabIndex = 7;
            this.txtwebdir.Text = "http://";
            // 
            // txttelefono
            // 
            this.txttelefono.Location = new System.Drawing.Point(18, 134);
            this.txttelefono.Mask = "0000-0000";
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(114, 20);
            this.txttelefono.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Telefono (*)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Direccion";
            // 
            // txtdireccion
            // 
            this.txtdireccion.Location = new System.Drawing.Point(18, 90);
            this.txtdireccion.Name = "txtdireccion";
            this.txtdireccion.Size = new System.Drawing.Size(212, 20);
            this.txtdireccion.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre (*)";
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(18, 44);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(212, 20);
            this.txtnombre.TabIndex = 0;
            // 
            // RegistrarProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(396, 285);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistrarProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegistrarProveedor";
            this.Load += new System.EventHandler(this.RegistrarProveedor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox txttelefono;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtdireccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Button Cmdregistrar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtwebdir;
        private System.Windows.Forms.Button cmdexit;
    }
}