namespace Delatorre
{
    partial class frmEditarUsuario
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmdlista = new System.Windows.Forms.Button();
            this.liscontenido = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chceckestado = new System.Windows.Forms.CheckBox();
            this.combocuenta = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.piccargandoCliente = new System.Windows.Forms.PictureBox();
            this.cmdguardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piccargandoCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Panel1.Controls.Add(this.piccargandoCliente);
            this.splitContainer1.Panel1.Controls.Add(this.cmdguardar);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.combocuenta);
            this.splitContainer1.Panel1.Controls.Add(this.chceckestado);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.txtmail);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtpass);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtuser);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.ForeColor = System.Drawing.Color.White;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Panel2.Controls.Add(this.liscontenido);
            this.splitContainer1.Panel2.Controls.Add(this.cmdlista);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(408, 287);
            this.splitContainer1.SplitterDistance = 136;
            this.splitContainer1.TabIndex = 0;
            // 
            // cmdlista
            // 
            this.cmdlista.Location = new System.Drawing.Point(5, 252);
            this.cmdlista.Name = "cmdlista";
            this.cmdlista.Size = new System.Drawing.Size(260, 23);
            this.cmdlista.TabIndex = 2;
            this.cmdlista.Text = "Generar Lista de usuarios Disponibles";
            this.cmdlista.UseVisualStyleBackColor = true;
            this.cmdlista.Click += new System.EventHandler(this.cmdlista_Click);
            // 
            // liscontenido
            // 
            this.liscontenido.Location = new System.Drawing.Point(5, 3);
            this.liscontenido.Name = "liscontenido";
            this.liscontenido.Size = new System.Drawing.Size(260, 243);
            this.liscontenido.TabIndex = 3;
            this.liscontenido.UseCompatibleStateImageBehavior = false;
            //this.liscontenido.SearchForVirtualItem += new System.Windows.Forms.SearchForVirtualItemEventHandler(this.liscontenido_SearchForVirtualItem);
            this.liscontenido.SelectedIndexChanged += new System.EventHandler(this.liscontenido_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre Usuario:";
            // 
            // txtuser
            // 
            this.txtuser.Location = new System.Drawing.Point(7, 30);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(113, 20);
            this.txtuser.TabIndex = 1;
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(7, 76);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(113, 20);
            this.txtpass.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contraseña:";
            // 
            // txtmail
            // 
            this.txtmail.Location = new System.Drawing.Point(7, 127);
            this.txtmail.Name = "txtmail";
            this.txtmail.Size = new System.Drawing.Size(113, 20);
            this.txtmail.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Correo Electronico:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Estado:\r\n";
            // 
            // chceckestado
            // 
            this.chceckestado.AutoSize = true;
            this.chceckestado.Location = new System.Drawing.Point(21, 175);
            this.chceckestado.Name = "chceckestado";
            this.chceckestado.Size = new System.Drawing.Size(109, 17);
            this.chceckestado.TabIndex = 7;
            this.chceckestado.Text = "Activo/Desactivo";
            this.chceckestado.UseVisualStyleBackColor = true;
            // 
            // combocuenta
            // 
            this.combocuenta.FormattingEnabled = true;
            this.combocuenta.Items.AddRange(new object[] {
            "user\t",
            "admin",
            "root"});
            this.combocuenta.Location = new System.Drawing.Point(7, 216);
            this.combocuenta.Margin = new System.Windows.Forms.Padding(2);
            this.combocuenta.Name = "combocuenta";
            this.combocuenta.Size = new System.Drawing.Size(113, 21);
            this.combocuenta.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tipo de Cuenta:";
            // 
            // piccargandoCliente
            // 
            this.piccargandoCliente.Image = global::Delatorre.Properties.Resources.url;
            this.piccargandoCliente.Location = new System.Drawing.Point(85, 248);
            this.piccargandoCliente.Name = "piccargandoCliente";
            this.piccargandoCliente.Size = new System.Drawing.Size(26, 27);
            this.piccargandoCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.piccargandoCliente.TabIndex = 15;
            this.piccargandoCliente.TabStop = false;
            // 
            // cmdguardar
            // 
            this.cmdguardar.Image = global::Delatorre.Properties.Resources.save_icon_16;
            this.cmdguardar.Location = new System.Drawing.Point(10, 252);
            this.cmdguardar.Name = "cmdguardar";
            this.cmdguardar.Size = new System.Drawing.Size(58, 23);
            this.cmdguardar.TabIndex = 10;
            this.cmdguardar.UseVisualStyleBackColor = true;
            this.cmdguardar.Click += new System.EventHandler(this.cmdguardar_Click);
            // 
            // frmEditarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 287);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmEditarUsuario";
            this.Text = "frmEditarUsuario";
            this.Load += new System.EventHandler(this.frmEditarUsuario_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.piccargandoCliente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView liscontenido;
        private System.Windows.Forms.Button cmdlista;
        private System.Windows.Forms.CheckBox chceckestado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox combocuenta;
        private System.Windows.Forms.Button cmdguardar;
        private System.Windows.Forms.PictureBox piccargandoCliente;
    }
}