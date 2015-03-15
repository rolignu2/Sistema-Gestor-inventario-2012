namespace Delatorre
{
    partial class hacerventa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(hacerventa));
            this.label1 = new System.Windows.Forms.Label();
            this.cmdEnviar = new System.Windows.Forms.Button();
            this.txtcantidad = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cantidad:";
            // 
            // cmdEnviar
            // 
            this.cmdEnviar.ForeColor = System.Drawing.Color.Black;
            this.cmdEnviar.Image = global::Delatorre.Properties.Resources.save_icon_16;
            this.cmdEnviar.Location = new System.Drawing.Point(121, 22);
            this.cmdEnviar.Name = "cmdEnviar";
            this.cmdEnviar.Size = new System.Drawing.Size(75, 23);
            this.cmdEnviar.TabIndex = 2;
            this.cmdEnviar.UseVisualStyleBackColor = true;
            this.cmdEnviar.Click += new System.EventHandler(this.cmdEnviar_Click);
            // 
            // txtcantidad
            // 
            this.txtcantidad.Location = new System.Drawing.Point(15, 24);
            this.txtcantidad.Mask = "99999";
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(100, 20);
            this.txtcantidad.TabIndex = 3;
            this.txtcantidad.ValidatingType = typeof(int);
            this.txtcantidad.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtcantidad_PreviewKeyDown);
            // 
            // hacerventa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(216, 53);
            this.Controls.Add(this.txtcantidad);
            this.Controls.Add(this.cmdEnviar);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "hacerventa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "hacerventa";
            this.Activated += new System.EventHandler(this.hacerventa_Activated);
            this.Load += new System.EventHandler(this.hacerventa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdEnviar;
        private System.Windows.Forms.MaskedTextBox txtcantidad;
    }
}