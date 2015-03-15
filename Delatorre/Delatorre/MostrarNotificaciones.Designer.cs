namespace Delatorre
{
    partial class MostrarNotificaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MostrarNotificaciones));
            this.listanotificaciones = new System.Windows.Forms.ListView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Reflescar = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblcargando = new System.Windows.Forms.Label();
            this.cmdbuscar = new System.Windows.Forms.Button();
            this.Combosucursal = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ComboEmpleado = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboFecha = new System.Windows.Forms.DateTimePicker();
            this.listafiltro = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmdcerrar = new System.Windows.Forms.Button();
            this.Combofecha1 = new System.Windows.Forms.DateTimePicker();
            this.optact1 = new System.Windows.Forms.RadioButton();
            this.optact2 = new System.Windows.Forms.RadioButton();
            this.optact3 = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listanotificaciones
            // 
            this.listanotificaciones.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listanotificaciones.Location = new System.Drawing.Point(6, 44);
            this.listanotificaciones.Name = "listanotificaciones";
            this.listanotificaciones.Size = new System.Drawing.Size(529, 206);
            this.listanotificaciones.TabIndex = 0;
            this.listanotificaciones.UseCompatibleStateImageBehavior = false;
            this.listanotificaciones.View = System.Windows.Forms.View.List;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Lista",
            "Grande",
            "Pequeño"});
            this.comboBox1.Location = new System.Drawing.Point(6, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(144, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "Seleccionar Vista";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 68);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(549, 282);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.Reflescar);
            this.tabPage1.Controls.Add(this.listanotificaciones);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(541, 256);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Notidficaciones Recientes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Reflescar
            // 
            this.Reflescar.Image = ((System.Drawing.Image)(resources.GetObject("Reflescar.Image")));
            this.Reflescar.Location = new System.Drawing.Point(156, 15);
            this.Reflescar.Name = "Reflescar";
            this.Reflescar.Size = new System.Drawing.Size(43, 23);
            this.Reflescar.TabIndex = 3;
            this.Reflescar.UseVisualStyleBackColor = true;
            this.Reflescar.Click += new System.EventHandler(this.Reflescar_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.listafiltro);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(541, 256);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Notificaciones Avanzadas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optact3);
            this.groupBox1.Controls.Add(this.optact2);
            this.groupBox1.Controls.Add(this.optact1);
            this.groupBox1.Controls.Add(this.Combofecha1);
            this.groupBox1.Controls.Add(this.lblcargando);
            this.groupBox1.Controls.Add(this.cmdbuscar);
            this.groupBox1.Controls.Add(this.Combosucursal);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ComboEmpleado);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ComboFecha);
            this.groupBox1.Location = new System.Drawing.Point(327, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 244);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda de transaccion o notificacion";
            // 
            // lblcargando
            // 
            this.lblcargando.AutoSize = true;
            this.lblcargando.Location = new System.Drawing.Point(8, 220);
            this.lblcargando.Name = "lblcargando";
            this.lblcargando.Size = new System.Drawing.Size(43, 13);
            this.lblcargando.TabIndex = 7;
            this.lblcargando.Text = "______";
            // 
            // cmdbuscar
            // 
            this.cmdbuscar.Image = global::Delatorre.Properties.Resources.zoom_icon_161;
            this.cmdbuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdbuscar.Location = new System.Drawing.Point(112, 215);
            this.cmdbuscar.Name = "cmdbuscar";
            this.cmdbuscar.Size = new System.Drawing.Size(88, 23);
            this.cmdbuscar.TabIndex = 6;
            this.cmdbuscar.Text = "Buscar";
            this.cmdbuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdbuscar.UseVisualStyleBackColor = true;
            this.cmdbuscar.Click += new System.EventHandler(this.cmdbuscar_Click);
            // 
            // Combosucursal
            // 
            this.Combosucursal.FormattingEnabled = true;
            this.Combosucursal.Location = new System.Drawing.Point(11, 174);
            this.Combosucursal.Name = "Combosucursal";
            this.Combosucursal.Size = new System.Drawing.Size(168, 21);
            this.Combosucursal.TabIndex = 5;
            this.Combosucursal.Text = "Cargando...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Por Sucursal:";
            // 
            // ComboEmpleado
            // 
            this.ComboEmpleado.FormattingEnabled = true;
            this.ComboEmpleado.Location = new System.Drawing.Point(11, 120);
            this.ComboEmpleado.Name = "ComboEmpleado";
            this.ComboEmpleado.Size = new System.Drawing.Size(167, 21);
            this.ComboEmpleado.TabIndex = 3;
            this.ComboEmpleado.Text = "Cargando...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Por Empleado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Por Fecha:";
            // 
            // ComboFecha
            // 
            this.ComboFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ComboFecha.Location = new System.Drawing.Point(7, 38);
            this.ComboFecha.Name = "ComboFecha";
            this.ComboFecha.Size = new System.Drawing.Size(171, 20);
            this.ComboFecha.TabIndex = 0;
            // 
            // listafiltro
            // 
            this.listafiltro.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listafiltro.Location = new System.Drawing.Point(3, 6);
            this.listafiltro.Name = "listafiltro";
            this.listafiltro.Size = new System.Drawing.Size(322, 247);
            this.listafiltro.TabIndex = 1;
            this.listafiltro.UseCompatibleStateImageBehavior = false;
            this.listafiltro.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(134, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Sistema de notificaciones";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Delatorre.Properties.Resources.sobre;
            this.pictureBox1.Location = new System.Drawing.Point(54, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(74, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // cmdcerrar
            // 
            this.cmdcerrar.Image = global::Delatorre.Properties.Resources.cancel1;
            this.cmdcerrar.Location = new System.Drawing.Point(502, 24);
            this.cmdcerrar.Name = "cmdcerrar";
            this.cmdcerrar.Size = new System.Drawing.Size(55, 23);
            this.cmdcerrar.TabIndex = 1;
            this.cmdcerrar.UseVisualStyleBackColor = true;
            this.cmdcerrar.Click += new System.EventHandler(this.cmdcerrar_Click);
            // 
            // Combofecha1
            // 
            this.Combofecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Combofecha1.Location = new System.Drawing.Point(7, 64);
            this.Combofecha1.Name = "Combofecha1";
            this.Combofecha1.Size = new System.Drawing.Size(171, 20);
            this.Combofecha1.TabIndex = 8;
            // 
            // optact1
            // 
            this.optact1.AutoSize = true;
            this.optact1.Location = new System.Drawing.Point(185, 45);
            this.optact1.Name = "optact1";
            this.optact1.Size = new System.Drawing.Size(14, 13);
            this.optact1.TabIndex = 9;
            this.optact1.TabStop = true;
            this.optact1.UseVisualStyleBackColor = true;
            // 
            // optact2
            // 
            this.optact2.AutoSize = true;
            this.optact2.Location = new System.Drawing.Point(186, 128);
            this.optact2.Name = "optact2";
            this.optact2.Size = new System.Drawing.Size(14, 13);
            this.optact2.TabIndex = 10;
            this.optact2.TabStop = true;
            this.optact2.UseVisualStyleBackColor = true;
            // 
            // optact3
            // 
            this.optact3.AutoSize = true;
            this.optact3.Location = new System.Drawing.Point(186, 177);
            this.optact3.Name = "optact3";
            this.optact3.Size = new System.Drawing.Size(14, 13);
            this.optact3.TabIndex = 11;
            this.optact3.TabStop = true;
            this.optact3.UseVisualStyleBackColor = true;
            // 
            // MostrarNotificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(573, 365);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdcerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MostrarNotificaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MostrarNotificaciones";
            this.Load += new System.EventHandler(this.MostrarNotificaciones_Load);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.MostrarNotificaciones_Layout);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listanotificaciones;
        private System.Windows.Forms.Button cmdcerrar;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Reflescar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdbuscar;
        private System.Windows.Forms.ComboBox Combosucursal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ComboEmpleado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker ComboFecha;
        private System.Windows.Forms.ListView listafiltro;
        private System.Windows.Forms.Label lblcargando;
        private System.Windows.Forms.DateTimePicker Combofecha1;
        private System.Windows.Forms.RadioButton optact3;
        private System.Windows.Forms.RadioButton optact2;
        private System.Windows.Forms.RadioButton optact1;
    }
}