namespace Delatorre
{
    partial class FrmVerEmpleado
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtn = new System.Windows.Forms.Label();
            this.txta = new System.Windows.Forms.Label();
            this.txtd = new System.Windows.Forms.Label();
            this.txts = new System.Windows.Forms.Label();
            this.txtu = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtsu = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtact = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtcar = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.piccargandoCliente = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piccargandoCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vista de informacion Empleados.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.piccargandoCliente);
            this.groupBox1.Controls.Add(this.txtact);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtcar);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtsu);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtu);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txts);
            this.groupBox1.Controls.Add(this.txtd);
            this.groupBox1.Controls.Add(this.txta);
            this.groupBox1.Controls.Add(this.txtn);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(37, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 281);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(68, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(227, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Cargando...";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Apellido:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Dui:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Salario:";
            // 
            // txtn
            // 
            this.txtn.AutoSize = true;
            this.txtn.Location = new System.Drawing.Point(118, 70);
            this.txtn.Name = "txtn";
            this.txtn.Size = new System.Drawing.Size(61, 13);
            this.txtn.TabIndex = 5;
            this.txtn.Text = "_________";
            // 
            // txta
            // 
            this.txta.AutoSize = true;
            this.txta.Location = new System.Drawing.Point(118, 103);
            this.txta.Name = "txta";
            this.txta.Size = new System.Drawing.Size(61, 13);
            this.txta.TabIndex = 6;
            this.txta.Text = "_________";
            // 
            // txtd
            // 
            this.txtd.AutoSize = true;
            this.txtd.Location = new System.Drawing.Point(118, 136);
            this.txtd.Name = "txtd";
            this.txtd.Size = new System.Drawing.Size(61, 13);
            this.txtd.TabIndex = 7;
            this.txtd.Text = "_________";
            // 
            // txts
            // 
            this.txts.AutoSize = true;
            this.txts.Location = new System.Drawing.Point(118, 164);
            this.txts.Name = "txts";
            this.txts.Size = new System.Drawing.Size(61, 13);
            this.txts.TabIndex = 8;
            this.txts.Text = "_________";
            // 
            // txtu
            // 
            this.txtu.AutoSize = true;
            this.txtu.Location = new System.Drawing.Point(70, 210);
            this.txtu.Name = "txtu";
            this.txtu.Size = new System.Drawing.Size(61, 13);
            this.txtu.TabIndex = 10;
            this.txtu.Text = "_________";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 210);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Usuario:";
            // 
            // txtsu
            // 
            this.txtsu.AutoSize = true;
            this.txtsu.Location = new System.Drawing.Point(70, 241);
            this.txtsu.Name = "txtsu";
            this.txtsu.Size = new System.Drawing.Size(61, 13);
            this.txtsu.TabIndex = 12;
            this.txtsu.Text = "_________";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 241);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Sucursal:";
            // 
            // txtact
            // 
            this.txtact.AutoSize = true;
            this.txtact.Location = new System.Drawing.Point(255, 241);
            this.txtact.Name = "txtact";
            this.txtact.Size = new System.Drawing.Size(61, 13);
            this.txtact.TabIndex = 16;
            this.txtact.Text = "_________";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(209, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Estado:";
            // 
            // txtcar
            // 
            this.txtcar.AutoSize = true;
            this.txtcar.Location = new System.Drawing.Point(255, 210);
            this.txtcar.Name = "txtcar";
            this.txtcar.Size = new System.Drawing.Size(61, 13);
            this.txtcar.TabIndex = 14;
            this.txtcar.Text = "_________";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(211, 210);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Cargo:";
            // 
            // piccargandoCliente
            // 
            this.piccargandoCliente.Image = global::Delatorre.Properties.Resources.loading;
            this.piccargandoCliente.Location = new System.Drawing.Point(201, 60);
            this.piccargandoCliente.Name = "piccargandoCliente";
            this.piccargandoCliente.Size = new System.Drawing.Size(138, 137);
            this.piccargandoCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.piccargandoCliente.TabIndex = 17;
            this.piccargandoCliente.TabStop = false;
            // 
            // FrmVerEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(446, 362);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "FrmVerEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVerEmpleado";
            this.Load += new System.EventHandler(this.FrmVerEmpleado_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piccargandoCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label txtsu;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label txtu;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label txts;
        private System.Windows.Forms.Label txtd;
        private System.Windows.Forms.Label txta;
        private System.Windows.Forms.Label txtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtact;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label txtcar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox piccargandoCliente;
    }
}