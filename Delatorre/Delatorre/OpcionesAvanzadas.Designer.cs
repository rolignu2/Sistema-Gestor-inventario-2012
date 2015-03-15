namespace Delatorre
{
    partial class OpcionesAvanzadas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpcionesAvanzadas));
            this.lista_usuarios = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LblConectados = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lista_usuarios
            // 
            this.lista_usuarios.FormattingEnabled = true;
            this.lista_usuarios.Items.AddRange(new object[] {
            "No hay usuarios conectados"});
            this.lista_usuarios.Location = new System.Drawing.Point(17, 26);
            this.lista_usuarios.Name = "lista_usuarios";
            this.lista_usuarios.Size = new System.Drawing.Size(250, 121);
            this.lista_usuarios.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cerrar Sesion Usuario ";
            // 
            // LblConectados
            // 
            this.LblConectados.AutoSize = true;
            this.LblConectados.Location = new System.Drawing.Point(14, 150);
            this.LblConectados.Name = "LblConectados";
            this.LblConectados.Size = new System.Drawing.Size(31, 13);
            this.LblConectados.TabIndex = 2;
            this.LblConectados.Text = "........\r\n";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(165, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "Matar Sesion";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LblConectados);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.lista_usuarios);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 183);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // OpcionesAvanzadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(300, 211);
            this.Controls.Add(this.groupBox2);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OpcionesAvanzadas";
            this.Text = "OpcionesAvanzadas";
            this.Load += new System.EventHandler(this.OpcionesAvanzadas_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lista_usuarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblConectados;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}