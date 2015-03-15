namespace Delatorre
{
    partial class frmeditarempleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmeditarempleados));
            this.comboempleado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.txtapellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtsalario = new System.Windows.Forms.MaskedTextBox();
            this.txtdui = new System.Windows.Forms.MaskedTextBox();
            this.combocargo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.combosucursal = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.combousuario = new System.Windows.Forms.ComboBox();
            this.checkactivo = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdeliminar = new System.Windows.Forms.Button();
            this.cmdguardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboempleado
            // 
            this.comboempleado.FormattingEnabled = true;
            this.comboempleado.Location = new System.Drawing.Point(9, 39);
            this.comboempleado.Name = "comboempleado";
            this.comboempleado.Size = new System.Drawing.Size(500, 21);
            this.comboempleado.TabIndex = 0;
            this.comboempleado.Text = "Obteniendo datos ...";
            this.comboempleado.SelectedIndexChanged += new System.EventHandler(this.comboempleado_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione Empleado:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboempleado);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 84);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtsalario);
            this.groupBox2.Controls.Add(this.txtdui);
            this.groupBox2.Controls.Add(this.combocargo);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.combosucursal);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtapellido);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtnombre);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(314, 191);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmdguardar);
            this.groupBox3.Controls.Add(this.cmdeliminar);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.checkactivo);
            this.groupBox3.Controls.Add(this.combousuario);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(333, 102);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 191);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre:";
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(64, 13);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(169, 20);
            this.txtnombre.TabIndex = 0;
            // 
            // txtapellido
            // 
            this.txtapellido.Location = new System.Drawing.Point(64, 39);
            this.txtapellido.Name = "txtapellido";
            this.txtapellido.Size = new System.Drawing.Size(169, 20);
            this.txtapellido.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Apellido:";
            // 
            // txtsalario
            // 
            this.txtsalario.Location = new System.Drawing.Point(64, 91);
            this.txtsalario.Mask = "99999";
            this.txtsalario.Name = "txtsalario";
            this.txtsalario.Size = new System.Drawing.Size(106, 20);
            this.txtsalario.TabIndex = 25;
            this.txtsalario.ValidatingType = typeof(int);
            // 
            // txtdui
            // 
            this.txtdui.Location = new System.Drawing.Point(64, 65);
            this.txtdui.Mask = "00000000-0";
            this.txtdui.Name = "txtdui";
            this.txtdui.Size = new System.Drawing.Size(110, 20);
            this.txtdui.TabIndex = 18;
            // 
            // combocargo
            // 
            this.combocargo.FormattingEnabled = true;
            this.combocargo.Items.AddRange(new object[] {
            "Empleado",
            "Gerente",
            "Supervisor",
            "Cajero"});
            this.combocargo.Location = new System.Drawing.Point(65, 153);
            this.combocargo.Margin = new System.Windows.Forms.Padding(2);
            this.combocargo.Name = "combocargo";
            this.combocargo.Size = new System.Drawing.Size(128, 21);
            this.combocargo.TabIndex = 24;
            this.combocargo.Text = "Empleado";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 161);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Cargo:";
            // 
            // combosucursal
            // 
            this.combosucursal.FormattingEnabled = true;
            this.combosucursal.Location = new System.Drawing.Point(64, 124);
            this.combosucursal.Margin = new System.Windows.Forms.Padding(2);
            this.combosucursal.Name = "combosucursal";
            this.combosucursal.Size = new System.Drawing.Size(225, 21);
            this.combosucursal.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 130);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Sucursal:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 99);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Salario:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 68);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Dui:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Usuario:";
            // 
            // combousuario
            // 
            this.combousuario.FormattingEnabled = true;
            this.combousuario.Location = new System.Drawing.Point(9, 34);
            this.combousuario.Name = "combousuario";
            this.combousuario.Size = new System.Drawing.Size(164, 21);
            this.combousuario.TabIndex = 1;
            // 
            // checkactivo
            // 
            this.checkactivo.AutoSize = true;
            this.checkactivo.Location = new System.Drawing.Point(9, 84);
            this.checkactivo.Name = "checkactivo";
            this.checkactivo.Size = new System.Drawing.Size(112, 17);
            this.checkactivo.TabIndex = 2;
            this.checkactivo.Text = " Activo/Desactivo";
            this.checkactivo.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Estado:";
            // 
            // cmdeliminar
            // 
            this.cmdeliminar.ForeColor = System.Drawing.Color.Black;
            this.cmdeliminar.Location = new System.Drawing.Point(50, 122);
            this.cmdeliminar.Name = "cmdeliminar";
            this.cmdeliminar.Size = new System.Drawing.Size(112, 23);
            this.cmdeliminar.TabIndex = 4;
            this.cmdeliminar.Text = "Eliminar Empleado";
            this.cmdeliminar.UseVisualStyleBackColor = true;
            this.cmdeliminar.Click += new System.EventHandler(this.cmdeliminar_Click);
            // 
            // cmdguardar
            // 
            this.cmdguardar.ForeColor = System.Drawing.Color.Black;
            this.cmdguardar.Location = new System.Drawing.Point(50, 156);
            this.cmdguardar.Name = "cmdguardar";
            this.cmdguardar.Size = new System.Drawing.Size(112, 23);
            this.cmdguardar.TabIndex = 5;
            this.cmdguardar.Text = "Guardar";
            this.cmdguardar.UseVisualStyleBackColor = true;
            this.cmdguardar.Click += new System.EventHandler(this.cmdguardar_Click);
            // 
            // frmeditarempleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(539, 304);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmeditarempleados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmeditarempleados";
            this.Load += new System.EventHandler(this.frmeditarempleados_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboempleado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtapellido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtsalario;
        private System.Windows.Forms.MaskedTextBox txtdui;
        private System.Windows.Forms.ComboBox combocargo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox combosucursal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox combousuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdguardar;
        private System.Windows.Forms.Button cmdeliminar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkactivo;
    }
}