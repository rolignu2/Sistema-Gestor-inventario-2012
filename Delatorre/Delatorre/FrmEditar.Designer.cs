namespace Delatorre
{
    partial class FrmEditar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditar));
            this.GroupProdusado = new System.Windows.Forms.GroupBox();
            this.txtestadoProd = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.optactivoNo = new System.Windows.Forms.RadioButton();
            this.optactivoSi = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.optprodexistenteNo = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.optprodexistenteSI = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pictureloading = new System.Windows.Forms.PictureBox();
            this.lbladvertencia = new System.Windows.Forms.LinkLabel();
            this.cmdsave = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtbuscar = new System.Windows.Forms.TextBox();
            this.comboproveeedor = new System.Windows.Forms.ComboBox();
            this.cmdbuscar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtgarantia = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.OptaplicaNo = new System.Windows.Forms.RadioButton();
            this.optAplicaSI = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtporcentaje = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.OptDescuentoNo = new System.Windows.Forms.RadioButton();
            this.OptdescuentoSi = new System.Windows.Forms.RadioButton();
            this.txtcantidad = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtfecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtprecio = new System.Windows.Forms.MaskedTextBox();
            this.TprocesoGuardar = new System.Windows.Forms.Timer(this.components);
            this.GroupProdusado.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureloading)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupProdusado
            // 
            this.GroupProdusado.BackColor = System.Drawing.Color.Transparent;
            this.GroupProdusado.Controls.Add(this.txtestadoProd);
            this.GroupProdusado.ForeColor = System.Drawing.Color.LightGray;
            this.GroupProdusado.Location = new System.Drawing.Point(244, 199);
            this.GroupProdusado.Name = "GroupProdusado";
            this.GroupProdusado.Size = new System.Drawing.Size(218, 58);
            this.GroupProdusado.TabIndex = 110;
            this.GroupProdusado.TabStop = false;
            this.GroupProdusado.Text = "Descripcion estado del producto";
            // 
            // txtestadoProd
            // 
            this.txtestadoProd.Location = new System.Drawing.Point(4, 13);
            this.txtestadoProd.Name = "txtestadoProd";
            this.txtestadoProd.Size = new System.Drawing.Size(208, 37);
            this.txtestadoProd.TabIndex = 0;
            this.txtestadoProd.Text = "No hay descripcion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 17);
            this.label1.TabIndex = 108;
            this.label1.Text = "Editar Producto Delatorre";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.optactivoNo);
            this.groupBox6.Controls.Add(this.optactivoSi);
            this.groupBox6.Location = new System.Drawing.Point(8, 218);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(218, 37);
            this.groupBox6.TabIndex = 107;
            this.groupBox6.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 67;
            this.label10.Text = "Prod Activo:";
            // 
            // optactivoNo
            // 
            this.optactivoNo.AutoSize = true;
            this.optactivoNo.Location = new System.Drawing.Point(142, 12);
            this.optactivoNo.Name = "optactivoNo";
            this.optactivoNo.Size = new System.Drawing.Size(39, 17);
            this.optactivoNo.TabIndex = 65;
            this.optactivoNo.TabStop = true;
            this.optactivoNo.Text = "No";
            this.optactivoNo.UseVisualStyleBackColor = true;
            // 
            // optactivoSi
            // 
            this.optactivoSi.AutoSize = true;
            this.optactivoSi.Location = new System.Drawing.Point(102, 12);
            this.optactivoSi.Name = "optactivoSi";
            this.optactivoSi.Size = new System.Drawing.Size(34, 17);
            this.optactivoSi.TabIndex = 64;
            this.optactivoSi.TabStop = true;
            this.optactivoSi.Text = "Si";
            this.optactivoSi.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.optprodexistenteNo);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.optprodexistenteSI);
            this.groupBox5.Location = new System.Drawing.Point(8, 175);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(218, 37);
            this.groupBox5.TabIndex = 106;
            this.groupBox5.TabStop = false;
            // 
            // optprodexistenteNo
            // 
            this.optprodexistenteNo.AutoSize = true;
            this.optprodexistenteNo.Location = new System.Drawing.Point(142, 12);
            this.optprodexistenteNo.Name = "optprodexistenteNo";
            this.optprodexistenteNo.Size = new System.Drawing.Size(39, 17);
            this.optprodexistenteNo.TabIndex = 65;
            this.optprodexistenteNo.TabStop = true;
            this.optprodexistenteNo.Text = "No";
            this.optprodexistenteNo.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 63;
            this.label9.Text = "Prod Existente:";
            // 
            // optprodexistenteSI
            // 
            this.optprodexistenteSI.AutoSize = true;
            this.optprodexistenteSI.Location = new System.Drawing.Point(102, 12);
            this.optprodexistenteSI.Name = "optprodexistenteSI";
            this.optprodexistenteSI.Size = new System.Drawing.Size(34, 17);
            this.optprodexistenteSI.TabIndex = 64;
            this.optprodexistenteSI.TabStop = true;
            this.optprodexistenteSI.Text = "Si";
            this.optprodexistenteSI.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.pictureloading);
            this.groupBox4.Controls.Add(this.lbladvertencia);
            this.groupBox4.Controls.Add(this.cmdsave);
            this.groupBox4.ForeColor = System.Drawing.Color.LightGray;
            this.groupBox4.Location = new System.Drawing.Point(244, 261);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(218, 82);
            this.groupBox4.TabIndex = 104;
            this.groupBox4.TabStop = false;
            // 
            // pictureloading
            // 
            this.pictureloading.Image = global::Delatorre.Properties.Resources.url;
            this.pictureloading.Location = new System.Drawing.Point(133, 25);
            this.pictureloading.Name = "pictureloading";
            this.pictureloading.Size = new System.Drawing.Size(41, 39);
            this.pictureloading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureloading.TabIndex = 74;
            this.pictureloading.TabStop = false;
            // 
            // lbladvertencia
            // 
            this.lbladvertencia.AutoSize = true;
            this.lbladvertencia.LinkColor = System.Drawing.Color.Red;
            this.lbladvertencia.Location = new System.Drawing.Point(7, 53);
            this.lbladvertencia.Name = "lbladvertencia";
            this.lbladvertencia.Size = new System.Drawing.Size(114, 13);
            this.lbladvertencia.TabIndex = 75;
            this.lbladvertencia.TabStop = true;
            this.lbladvertencia.Text = "Registros Productos ...";
            // 
            // cmdsave
            // 
            this.cmdsave.Image = ((System.Drawing.Image)(resources.GetObject("cmdsave.Image")));
            this.cmdsave.Location = new System.Drawing.Point(10, 19);
            this.cmdsave.Name = "cmdsave";
            this.cmdsave.Size = new System.Drawing.Size(100, 31);
            this.cmdsave.TabIndex = 0;
            this.cmdsave.UseVisualStyleBackColor = true;
            this.cmdsave.Click += new System.EventHandler(this.cmdsave_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.txtbuscar);
            this.groupBox3.Controls.Add(this.comboproveeedor);
            this.groupBox3.Controls.Add(this.cmdbuscar);
            this.groupBox3.ForeColor = System.Drawing.Color.LightGray;
            this.groupBox3.Location = new System.Drawing.Point(244, 103);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(218, 90);
            this.groupBox3.TabIndex = 105;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Proveeedor";
            // 
            // txtbuscar
            // 
            this.txtbuscar.ForeColor = System.Drawing.Color.Black;
            this.txtbuscar.Location = new System.Drawing.Point(10, 53);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.Size = new System.Drawing.Size(100, 20);
            this.txtbuscar.TabIndex = 2;
            // 
            // comboproveeedor
            // 
            this.comboproveeedor.FormattingEnabled = true;
            this.comboproveeedor.Location = new System.Drawing.Point(10, 23);
            this.comboproveeedor.Name = "comboproveeedor";
            this.comboproveeedor.Size = new System.Drawing.Size(177, 21);
            this.comboproveeedor.TabIndex = 1;
            this.comboproveeedor.Text = "Seleccionar un proveedor";
            // 
            // cmdbuscar
            // 
            this.cmdbuscar.ForeColor = System.Drawing.Color.Black;
            this.cmdbuscar.Location = new System.Drawing.Point(117, 53);
            this.cmdbuscar.Name = "cmdbuscar";
            this.cmdbuscar.Size = new System.Drawing.Size(75, 23);
            this.cmdbuscar.TabIndex = 0;
            this.cmdbuscar.Text = "Buscar ...";
            this.cmdbuscar.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.txtgarantia);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.OptaplicaNo);
            this.groupBox2.Controls.Add(this.optAplicaSI);
            this.groupBox2.ForeColor = System.Drawing.Color.LightGray;
            this.groupBox2.Location = new System.Drawing.Point(244, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 72);
            this.groupBox2.TabIndex = 103;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Garantia";
            // 
            // txtgarantia
            // 
            this.txtgarantia.Location = new System.Drawing.Point(110, 46);
            this.txtgarantia.Mask = "99999";
            this.txtgarantia.Name = "txtgarantia";
            this.txtgarantia.Size = new System.Drawing.Size(81, 20);
            this.txtgarantia.TabIndex = 17;
            this.txtgarantia.ValidatingType = typeof(int);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Meses Garantia:";
            // 
            // OptaplicaNo
            // 
            this.OptaplicaNo.AutoSize = true;
            this.OptaplicaNo.Location = new System.Drawing.Point(117, 19);
            this.OptaplicaNo.Name = "OptaplicaNo";
            this.OptaplicaNo.Size = new System.Drawing.Size(70, 17);
            this.OptaplicaNo.TabIndex = 1;
            this.OptaplicaNo.TabStop = true;
            this.OptaplicaNo.Text = "No aplica";
            this.OptaplicaNo.UseVisualStyleBackColor = true;
            // 
            // optAplicaSI
            // 
            this.optAplicaSI.AutoSize = true;
            this.optAplicaSI.Location = new System.Drawing.Point(50, 19);
            this.optAplicaSI.Name = "optAplicaSI";
            this.optAplicaSI.Size = new System.Drawing.Size(54, 17);
            this.optAplicaSI.TabIndex = 0;
            this.optAplicaSI.TabStop = true;
            this.optAplicaSI.Text = "Aplica";
            this.optAplicaSI.UseVisualStyleBackColor = true;
            this.optAplicaSI.CheckedChanged += new System.EventHandler(this.optAplicaSI_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtporcentaje);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.OptDescuentoNo);
            this.groupBox1.Controls.Add(this.OptdescuentoSi);
            this.groupBox1.ForeColor = System.Drawing.Color.LightGray;
            this.groupBox1.Location = new System.Drawing.Point(8, 261);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 76);
            this.groupBox1.TabIndex = 102;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Descuentos";
            // 
            // txtporcentaje
            // 
            this.txtporcentaje.Location = new System.Drawing.Point(110, 46);
            this.txtporcentaje.Mask = "99999";
            this.txtporcentaje.Name = "txtporcentaje";
            this.txtporcentaje.Size = new System.Drawing.Size(81, 20);
            this.txtporcentaje.TabIndex = 17;
            this.txtporcentaje.ValidatingType = typeof(int);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Porcentaje (%):";
            // 
            // OptDescuentoNo
            // 
            this.OptDescuentoNo.AutoSize = true;
            this.OptDescuentoNo.Location = new System.Drawing.Point(117, 19);
            this.OptDescuentoNo.Name = "OptDescuentoNo";
            this.OptDescuentoNo.Size = new System.Drawing.Size(95, 17);
            this.OptDescuentoNo.TabIndex = 1;
            this.OptDescuentoNo.TabStop = true;
            this.OptDescuentoNo.Text = "Sin Descuento";
            this.OptDescuentoNo.UseVisualStyleBackColor = true;
            // 
            // OptdescuentoSi
            // 
            this.OptdescuentoSi.AutoSize = true;
            this.OptdescuentoSi.Location = new System.Drawing.Point(12, 19);
            this.OptdescuentoSi.Name = "OptdescuentoSi";
            this.OptdescuentoSi.Size = new System.Drawing.Size(99, 17);
            this.OptdescuentoSi.TabIndex = 0;
            this.OptdescuentoSi.TabStop = true;
            this.OptdescuentoSi.Text = "Con Descuento";
            this.OptdescuentoSi.UseVisualStyleBackColor = true;
            this.OptdescuentoSi.CheckedChanged += new System.EventHandler(this.OptdescuentoSi_CheckedChanged);
            // 
            // txtcantidad
            // 
            this.txtcantidad.Location = new System.Drawing.Point(86, 149);
            this.txtcantidad.Mask = "99999";
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(40, 20);
            this.txtcantidad.TabIndex = 101;
            this.txtcantidad.ValidatingType = typeof(int);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 100;
            this.label6.Text = "Cantidad:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 98;
            this.label5.Text = "Precio $:";
            // 
            // txtfecha
            // 
            this.txtfecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtfecha.Location = new System.Drawing.Point(86, 97);
            this.txtfecha.Name = "txtfecha";
            this.txtfecha.Size = new System.Drawing.Size(131, 20);
            this.txtfecha.TabIndex = 97;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 96;
            this.label4.Text = "Fecha:";
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(86, 71);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(131, 20);
            this.txtnombre.TabIndex = 95;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 94;
            this.label3.Text = "Nombre Prod:";
            // 
            // txtcodigo
            // 
            this.txtcodigo.Location = new System.Drawing.Point(86, 45);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(131, 20);
            this.txtcodigo.TabIndex = 93;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 92;
            this.label2.Text = "Cod Producto:";
            // 
            // txtprecio
            // 
            this.txtprecio.Location = new System.Drawing.Point(86, 123);
            this.txtprecio.Name = "txtprecio";
            this.txtprecio.Size = new System.Drawing.Size(40, 20);
            this.txtprecio.TabIndex = 57;
            this.txtprecio.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtprecio_MaskInputRejected);
            this.txtprecio.TextChanged += new System.EventHandler(this.txtprecio_TextChanged);
            // 
            // TprocesoGuardar
            // 
            this.TprocesoGuardar.Tick += new System.EventHandler(this.TprocesoGuardar_Tick);
            // 
            // FrmEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(471, 357);
            this.Controls.Add(this.txtprecio);
            this.Controls.Add(this.GroupProdusado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtcantidad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtfecha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtcodigo);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmEditar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEditar";
            this.Load += new System.EventHandler(this.FrmEditar_Load);
            this.GroupProdusado.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureloading)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupProdusado;
        private System.Windows.Forms.RichTextBox txtestadoProd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton optactivoNo;
        private System.Windows.Forms.RadioButton optactivoSi;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton optprodexistenteNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton optprodexistenteSI;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pictureloading;
        private System.Windows.Forms.LinkLabel lbladvertencia;
        private System.Windows.Forms.Button cmdsave;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtbuscar;
        private System.Windows.Forms.ComboBox comboproveeedor;
        private System.Windows.Forms.Button cmdbuscar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MaskedTextBox txtgarantia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton OptaplicaNo;
        private System.Windows.Forms.RadioButton optAplicaSI;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox txtporcentaje;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton OptDescuentoNo;
        private System.Windows.Forms.RadioButton OptdescuentoSi;
        private System.Windows.Forms.MaskedTextBox txtcantidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker txtfecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtprecio;
        private System.Windows.Forms.Timer TprocesoGuardar;
    }
}