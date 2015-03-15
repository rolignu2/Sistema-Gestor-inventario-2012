namespace Delatorre
{
    partial class Registro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registro));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.comboempleados = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblmensaje = new System.Windows.Forms.Label();
            this.cmdingresar = new System.Windows.Forms.Button();
            this.txtreppass = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.opt2 = new System.Windows.Forms.RadioButton();
            this.opt1 = new System.Windows.Forms.RadioButton();
            this.combocuenta = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TaccesoPermisos = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registro Usuario (Empleado) ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.comboempleados);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(9, 57);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(190, 86);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vincular Empleado";
            // 
            // button1
            // 
            this.button1.Image = global::Delatorre.Properties.Resources.refresh_icon_16;
            this.button1.Location = new System.Drawing.Point(138, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 28);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.linkLabel1.Location = new System.Drawing.Point(9, 58);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(97, 13);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Crear un Empleado";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // comboempleados
            // 
            this.comboempleados.FormattingEnabled = true;
            this.comboempleados.Location = new System.Drawing.Point(11, 28);
            this.comboempleados.Margin = new System.Windows.Forms.Padding(2);
            this.comboempleados.Name = "comboempleados";
            this.comboempleados.Size = new System.Drawing.Size(167, 21);
            this.comboempleados.TabIndex = 2;
            this.comboempleados.SelectedIndexChanged += new System.EventHandler(this.comboempleados_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtmail);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblmensaje);
            this.groupBox2.Controls.Add(this.cmdingresar);
            this.groupBox2.Controls.Add(this.txtreppass);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtpass);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtuser);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(203, 52);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(246, 168);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Registro de Usuario";
            // 
            // txtmail
            // 
            this.txtmail.Location = new System.Drawing.Point(119, 96);
            this.txtmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtmail.Name = "txtmail";
            this.txtmail.Size = new System.Drawing.Size(112, 20);
            this.txtmail.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Rep Contraseña:";
            // 
            // lblmensaje
            // 
            this.lblmensaje.AutoSize = true;
            this.lblmensaje.Location = new System.Drawing.Point(14, 145);
            this.lblmensaje.Name = "lblmensaje";
            this.lblmensaje.Size = new System.Drawing.Size(47, 13);
            this.lblmensaje.TabIndex = 9;
            this.lblmensaje.Text = "Mensaje";
            // 
            // cmdingresar
            // 
            this.cmdingresar.ForeColor = System.Drawing.Color.Black;
            this.cmdingresar.Image = global::Delatorre.Properties.Resources.save_icon_16;
            this.cmdingresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdingresar.Location = new System.Drawing.Point(142, 131);
            this.cmdingresar.Margin = new System.Windows.Forms.Padding(2);
            this.cmdingresar.Name = "cmdingresar";
            this.cmdingresar.Size = new System.Drawing.Size(89, 27);
            this.cmdingresar.TabIndex = 8;
            this.cmdingresar.Text = "Guardar";
            this.cmdingresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdingresar.UseVisualStyleBackColor = true;
            this.cmdingresar.Click += new System.EventHandler(this.cmdingresar_Click);
            // 
            // txtreppass
            // 
            this.txtreppass.Location = new System.Drawing.Point(119, 72);
            this.txtreppass.Margin = new System.Windows.Forms.Padding(2);
            this.txtreppass.Name = "txtreppass";
            this.txtreppass.PasswordChar = '*';
            this.txtreppass.Size = new System.Drawing.Size(112, 20);
            this.txtreppass.TabIndex = 7;
            this.txtreppass.TextChanged += new System.EventHandler(this.txtreppass_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 96);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "E-mail (opcional):";
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(119, 48);
            this.txtpass.Margin = new System.Windows.Forms.Padding(2);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(112, 20);
            this.txtpass.TabIndex = 5;
            this.txtpass.TextChanged += new System.EventHandler(this.txtpass_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 47);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Contraseña:";
            // 
            // txtuser
            // 
            this.txtuser.Location = new System.Drawing.Point(119, 25);
            this.txtuser.Margin = new System.Windows.Forms.Padding(2);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(112, 20);
            this.txtuser.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 25);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Nombre de Usuario:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.opt2);
            this.groupBox3.Controls.Add(this.opt1);
            this.groupBox3.Controls.Add(this.combocuenta);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(9, 148);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(190, 72);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Permisos:";
            // 
            // opt2
            // 
            this.opt2.AutoSize = true;
            this.opt2.Location = new System.Drawing.Point(105, 20);
            this.opt2.Margin = new System.Windows.Forms.Padding(2);
            this.opt2.Name = "opt2";
            this.opt2.Size = new System.Drawing.Size(73, 17);
            this.opt2.TabIndex = 6;
            this.opt2.TabStop = true;
            this.opt2.Text = "Desactivo";
            this.opt2.UseVisualStyleBackColor = true;
            // 
            // opt1
            // 
            this.opt1.AutoSize = true;
            this.opt1.Location = new System.Drawing.Point(54, 20);
            this.opt1.Margin = new System.Windows.Forms.Padding(2);
            this.opt1.Name = "opt1";
            this.opt1.Size = new System.Drawing.Size(55, 17);
            this.opt1.TabIndex = 4;
            this.opt1.TabStop = true;
            this.opt1.Text = "Activo";
            this.opt1.UseVisualStyleBackColor = true;
            // 
            // combocuenta
            // 
            this.combocuenta.FormattingEnabled = true;
            this.combocuenta.Items.AddRange(new object[] {
            "user\t",
            "admin",
            "root"});
            this.combocuenta.Location = new System.Drawing.Point(80, 41);
            this.combocuenta.Margin = new System.Windows.Forms.Padding(2);
            this.combocuenta.Name = "combocuenta";
            this.combocuenta.Size = new System.Drawing.Size(98, 21);
            this.combocuenta.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 43);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Tipo Cuenta:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 22);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Estado:";
            // 
            // TaccesoPermisos
            // 
            this.TaccesoPermisos.Tick += new System.EventHandler(this.TaccesoPermisos_Tick);
            // 
            // Registro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(457, 230);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Registro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Registro";
            this.Activated += new System.EventHandler(this.Registro_Activated);
            this.Load += new System.EventHandler(this.Registro_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboempleados;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cmdingresar;
        private System.Windows.Forms.TextBox txtreppass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton opt2;
        private System.Windows.Forms.RadioButton opt1;
        private System.Windows.Forms.ComboBox combocuenta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer TaccesoPermisos;
        private System.Windows.Forms.Label lblmensaje;
        private System.Windows.Forms.TextBox txtmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}