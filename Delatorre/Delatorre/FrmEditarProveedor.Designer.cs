namespace Delatorre
{
    partial class FrmEditarProveedor
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grillaProv = new System.Windows.Forms.DataGridView();
            this.txtprov = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtwebdir = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtdireccion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txttelefono = new System.Windows.Forms.MaskedTextBox();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdguardar = new System.Windows.Forms.Button();
            this.cmdreflesh = new System.Windows.Forms.Button();
            this.lblguardando = new System.Windows.Forms.Label();
            this.cachedRepFactura1 = new Delatorre.CachedRepFactura();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaProv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Editar Proveedor:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grillaProv);
            this.groupBox1.Controls.Add(this.txtprov);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtwebdir);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtdireccion);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txttelefono);
            this.groupBox1.Controls.Add(this.txtnombre);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(16, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 219);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // grillaProv
            // 
            this.grillaProv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaProv.Location = new System.Drawing.Point(9, 45);
            this.grillaProv.Name = "grillaProv";
            this.grillaProv.Size = new System.Drawing.Size(439, 58);
            this.grillaProv.TabIndex = 2;
            this.grillaProv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaProv_CellDoubleClick);
            // 
            // txtprov
            // 
            this.txtprov.Location = new System.Drawing.Point(77, 19);
            this.txtprov.Name = "txtprov";
            this.txtprov.Size = new System.Drawing.Size(173, 20);
            this.txtprov.TabIndex = 1;
            this.txtprov.TextChanged += new System.EventHandler(this.txtprov_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Buscar Prov:";
            // 
            // txtwebdir
            // 
            this.txtwebdir.Location = new System.Drawing.Point(260, 186);
            this.txtwebdir.Name = "txtwebdir";
            this.txtwebdir.Size = new System.Drawing.Size(177, 20);
            this.txtwebdir.TabIndex = 15;
            this.txtwebdir.Text = "http://";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(257, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Sitio Web o Correo Electronico";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(22, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Direccion";
            // 
            // txtdireccion
            // 
            this.txtdireccion.Location = new System.Drawing.Point(20, 170);
            this.txtdireccion.Multiline = true;
            this.txtdireccion.Name = "txtdireccion";
            this.txtdireccion.Size = new System.Drawing.Size(212, 36);
            this.txtdireccion.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(17, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Nombre (*)";
            // 
            // txttelefono
            // 
            this.txttelefono.Location = new System.Drawing.Point(260, 132);
            this.txttelefono.Mask = "0000-0000";
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(114, 20);
            this.txttelefono.TabIndex = 14;
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(20, 122);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(172, 20);
            this.txtnombre.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(257, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Telefono (*)";
            // 
            // cmdguardar
            // 
            this.cmdguardar.Image = global::Delatorre.Properties.Resources.save_icon_16;
            this.cmdguardar.Location = new System.Drawing.Point(389, 256);
            this.cmdguardar.Name = "cmdguardar";
            this.cmdguardar.Size = new System.Drawing.Size(75, 23);
            this.cmdguardar.TabIndex = 2;
            this.cmdguardar.UseVisualStyleBackColor = true;
            this.cmdguardar.Click += new System.EventHandler(this.cmdguardar_Click);
            // 
            // cmdreflesh
            // 
            this.cmdreflesh.Image = global::Delatorre.Properties.Resources.refresh_icon_16;
            this.cmdreflesh.Location = new System.Drawing.Point(308, 256);
            this.cmdreflesh.Name = "cmdreflesh";
            this.cmdreflesh.Size = new System.Drawing.Size(75, 23);
            this.cmdreflesh.TabIndex = 3;
            this.cmdreflesh.UseVisualStyleBackColor = true;
            this.cmdreflesh.Click += new System.EventHandler(this.cmdreflesh_Click);
            // 
            // lblguardando
            // 
            this.lblguardando.AutoSize = true;
            this.lblguardando.Location = new System.Drawing.Point(16, 256);
            this.lblguardando.Name = "lblguardando";
            this.lblguardando.Size = new System.Drawing.Size(31, 13);
            this.lblguardando.TabIndex = 4;
            this.lblguardando.Text = "____";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmEditarProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(482, 286);
            this.Controls.Add(this.lblguardando);
            this.Controls.Add(this.cmdreflesh);
            this.Controls.Add(this.cmdguardar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "FrmEditarProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEditarProveedor";
            this.Load += new System.EventHandler(this.FrmEditarProveedor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaProv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grillaProv;
        private System.Windows.Forms.TextBox txtprov;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtwebdir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtdireccion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txttelefono;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdguardar;
        private System.Windows.Forms.Button cmdreflesh;
        private System.Windows.Forms.Label lblguardando;
        private CachedRepFactura cachedRepFactura1;
        private System.Windows.Forms.Timer timer1;
    }
}