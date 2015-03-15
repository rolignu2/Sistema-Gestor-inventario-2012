namespace Delatorre
{
    partial class RegistrarEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarEmpleado));
            this.lblreg = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtsalario = new System.Windows.Forms.MaskedTextBox();
            this.txtdui = new System.Windows.Forms.MaskedTextBox();
            this.combocargo = new System.Windows.Forms.ComboBox();
            this.cmdsave = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.combosucursal = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtapellido = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblcodigo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TiempoEdicion = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblreg
            // 
            this.lblreg.AutoSize = true;
            this.lblreg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblreg.Location = new System.Drawing.Point(9, 22);
            this.lblreg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblreg.Name = "lblreg";
            this.lblreg.Size = new System.Drawing.Size(189, 18);
            this.lblreg.TabIndex = 0;
            this.lblreg.Text = "Registro de Empleados:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtsalario);
            this.groupBox1.Controls.Add(this.txtdui);
            this.groupBox1.Controls.Add(this.combocargo);
            this.groupBox1.Controls.Add(this.cmdsave);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.combosucursal);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtapellido);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtnombre);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblcodigo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 55);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(287, 273);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txtsalario
            // 
            this.txtsalario.Location = new System.Drawing.Point(110, 140);
            this.txtsalario.Mask = "99999";
            this.txtsalario.Name = "txtsalario";
            this.txtsalario.Size = new System.Drawing.Size(76, 20);
            this.txtsalario.TabIndex = 17;
            this.txtsalario.ValidatingType = typeof(int);
            // 
            // txtdui
            // 
            this.txtdui.Location = new System.Drawing.Point(110, 114);
            this.txtdui.Mask = "00000000-0";
            this.txtdui.Name = "txtdui";
            this.txtdui.Size = new System.Drawing.Size(76, 20);
            this.txtdui.TabIndex = 2;
            // 
            // combocargo
            // 
            this.combocargo.FormattingEnabled = true;
            this.combocargo.Items.AddRange(new object[] {
            "Empleado",
            "Gerente",
            "Supervisor",
            "Cajero"});
            this.combocargo.Location = new System.Drawing.Point(111, 202);
            this.combocargo.Margin = new System.Windows.Forms.Padding(2);
            this.combocargo.Name = "combocargo";
            this.combocargo.Size = new System.Drawing.Size(105, 21);
            this.combocargo.TabIndex = 16;
            this.combocargo.Text = "Empleado";
            // 
            // cmdsave
            // 
            this.cmdsave.Image = global::Delatorre.Properties.Resources.save;
            this.cmdsave.Location = new System.Drawing.Point(218, 236);
            this.cmdsave.Margin = new System.Windows.Forms.Padding(2);
            this.cmdsave.Name = "cmdsave";
            this.cmdsave.Size = new System.Drawing.Size(56, 32);
            this.cmdsave.TabIndex = 15;
            this.cmdsave.UseVisualStyleBackColor = true;
            this.cmdsave.Click += new System.EventHandler(this.cmdsave_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 210);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Cargo:";
            // 
            // combosucursal
            // 
            this.combosucursal.FormattingEnabled = true;
            this.combosucursal.Location = new System.Drawing.Point(110, 173);
            this.combosucursal.Margin = new System.Windows.Forms.Padding(2);
            this.combosucursal.Name = "combosucursal";
            this.combosucursal.Size = new System.Drawing.Size(164, 21);
            this.combosucursal.TabIndex = 2;
            this.combosucursal.SelectedIndexChanged += new System.EventHandler(this.combosucursal_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 179);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Sucursal:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(62, 148);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Salario:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(79, 117);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Dui:";
            // 
            // txtapellido
            // 
            this.txtapellido.Location = new System.Drawing.Point(110, 83);
            this.txtapellido.Margin = new System.Windows.Forms.Padding(2);
            this.txtapellido.Name = "txtapellido";
            this.txtapellido.Size = new System.Drawing.Size(164, 20);
            this.txtapellido.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 87);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Apellido:";
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(110, 51);
            this.txtnombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(164, 20);
            this.txtnombre.TabIndex = 2;
            this.txtnombre.TextChanged += new System.EventHandler(this.txtnombre_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 55);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Nombre:";
            // 
            // lblcodigo
            // 
            this.lblcodigo.AutoSize = true;
            this.lblcodigo.Location = new System.Drawing.Point(108, 26);
            this.lblcodigo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblcodigo.Name = "lblcodigo";
            this.lblcodigo.Size = new System.Drawing.Size(16, 13);
            this.lblcodigo.TabIndex = 3;
            this.lblcodigo.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Codigo Empleado:";
            // 
            // TiempoEdicion
            // 
            this.TiempoEdicion.Tick += new System.EventHandler(this.TiempoEdicion_Tick);
            // 
            // RegistrarEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(314, 350);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblreg);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RegistrarEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegistrarEmpleado";
            this.Load += new System.EventHandler(this.RegistrarEmpleado_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblreg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtapellido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblcodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdsave;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox combosucursal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer TiempoEdicion;
        private System.Windows.Forms.ComboBox combocargo;
        private System.Windows.Forms.MaskedTextBox txtsalario;
        private System.Windows.Forms.MaskedTextBox txtdui;
    }
}