namespace Delatorre
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.linksesion = new System.Windows.Forms.LinkLabel();
            this.txtnombre = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.lblcontraseña = new System.Windows.Forms.Label();
            this.txtcapcha = new System.Windows.Forms.TextBox();
            this.cmdenviarCapcha = new System.Windows.Forms.Button();
            this.picloading = new System.Windows.Forms.PictureBox();
            this.piccapcha = new System.Windows.Forms.PictureBox();
            this.cmdenviar = new System.Windows.Forms.Button();
            this.cmdadd = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picloading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.piccapcha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // linksesion
            // 
            this.linksesion.AutoSize = true;
            this.linksesion.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.linksesion.Location = new System.Drawing.Point(107, 272);
            this.linksesion.Name = "linksesion";
            this.linksesion.Size = new System.Drawing.Size(123, 13);
            this.linksesion.TabIndex = 21;
            this.linksesion.TabStop = true;
            this.linksesion.Text = "Repuestos Frigorificos... ";
            // 
            // txtnombre
            // 
            this.txtnombre.FormattingEnabled = true;
            this.txtnombre.Location = new System.Drawing.Point(110, 149);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(219, 21);
            this.txtnombre.TabIndex = 25;
            this.txtnombre.SelectedIndexChanged += new System.EventHandler(this.txtnombre_SelectedIndexChanged);
            this.txtnombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnombre_KeyPress);
            this.txtnombre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtnombre_KeyUp);
            this.txtnombre.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtnombre_PreviewKeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(107, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Usuario";
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(110, 205);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(219, 20);
            this.txtpass.TabIndex = 24;
            this.txtpass.TextChanged += new System.EventHandler(this.txtpass_TextChanged);
            this.txtpass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpass_KeyPress);
            // 
            // lblcontraseña
            // 
            this.lblcontraseña.AutoSize = true;
            this.lblcontraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcontraseña.ForeColor = System.Drawing.Color.White;
            this.lblcontraseña.Location = new System.Drawing.Point(107, 189);
            this.lblcontraseña.Name = "lblcontraseña";
            this.lblcontraseña.Size = new System.Drawing.Size(71, 13);
            this.lblcontraseña.TabIndex = 23;
            this.lblcontraseña.Text = "Contraseña";
            // 
            // txtcapcha
            // 
            this.txtcapcha.Location = new System.Drawing.Point(120, 380);
            this.txtcapcha.Name = "txtcapcha";
            this.txtcapcha.Size = new System.Drawing.Size(98, 20);
            this.txtcapcha.TabIndex = 27;
            // 
            // cmdenviarCapcha
            // 
            this.cmdenviarCapcha.Location = new System.Drawing.Point(224, 380);
            this.cmdenviarCapcha.Name = "cmdenviarCapcha";
            this.cmdenviarCapcha.Size = new System.Drawing.Size(75, 23);
            this.cmdenviarCapcha.TabIndex = 28;
            this.cmdenviarCapcha.Text = "Enviar";
            this.cmdenviarCapcha.UseVisualStyleBackColor = true;
            this.cmdenviarCapcha.Click += new System.EventHandler(this.cmdenviarCapcha_Click);
            // 
            // picloading
            // 
            this.picloading.Image = global::Delatorre.Properties.Resources.url;
            this.picloading.Location = new System.Drawing.Point(75, 240);
            this.picloading.Name = "picloading";
            this.picloading.Size = new System.Drawing.Size(29, 29);
            this.picloading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picloading.TabIndex = 29;
            this.picloading.TabStop = false;
            // 
            // piccapcha
            // 
            this.piccapcha.Location = new System.Drawing.Point(121, 327);
            this.piccapcha.Name = "piccapcha";
            this.piccapcha.Size = new System.Drawing.Size(178, 50);
            this.piccapcha.TabIndex = 26;
            this.piccapcha.TabStop = false;
            // 
            // cmdenviar
            // 
            this.cmdenviar.AutoEllipsis = true;
            this.cmdenviar.BackColor = System.Drawing.Color.Transparent;
            this.cmdenviar.ForeColor = System.Drawing.Color.Black;
            this.cmdenviar.Image = ((System.Drawing.Image)(resources.GetObject("cmdenviar.Image")));
            this.cmdenviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdenviar.Location = new System.Drawing.Point(214, 242);
            this.cmdenviar.Name = "cmdenviar";
            this.cmdenviar.Size = new System.Drawing.Size(103, 27);
            this.cmdenviar.TabIndex = 2;
            this.cmdenviar.Text = "Iniciar Sesiòn";
            this.cmdenviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdenviar.UseVisualStyleBackColor = false;
            this.cmdenviar.Click += new System.EventHandler(this.cmdenviar_Click);
            // 
            // cmdadd
            // 
            this.cmdadd.Image = ((System.Drawing.Image)(resources.GetObject("cmdadd.Image")));
            this.cmdadd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdadd.Location = new System.Drawing.Point(110, 242);
            this.cmdadd.Name = "cmdadd";
            this.cmdadd.Size = new System.Drawing.Size(85, 27);
            this.cmdadd.TabIndex = 16;
            this.cmdadd.Text = "Registrar";
            this.cmdadd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdadd.UseVisualStyleBackColor = true;
            this.cmdadd.Click += new System.EventHandler(this.cmdadd_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Delatorre.Properties.Resources.LogoFinal;
            this.pictureBox1.Location = new System.Drawing.Point(110, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(219, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(465, 409);
            this.Controls.Add(this.picloading);
            this.Controls.Add(this.cmdenviarCapcha);
            this.Controls.Add(this.txtcapcha);
            this.Controls.Add(this.piccapcha);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.lblcontraseña);
            this.Controls.Add(this.cmdenviar);
            this.Controls.Add(this.linksesion);
            this.Controls.Add(this.cmdadd);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Login";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picloading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.piccapcha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdenviar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button cmdadd;
        private System.Windows.Forms.LinkLabel linksesion;
        private System.Windows.Forms.ComboBox txtnombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.Label lblcontraseña;
        private System.Windows.Forms.PictureBox piccapcha;
        private System.Windows.Forms.TextBox txtcapcha;
        private System.Windows.Forms.Button cmdenviarCapcha;
        private System.Windows.Forms.PictureBox picloading;
    }
}