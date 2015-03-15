namespace Delatorre
{
    partial class EstadosProducto
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
            this.richestado = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richestado
            // 
            this.richestado.Location = new System.Drawing.Point(3, 12);
            this.richestado.Name = "richestado";
            this.richestado.Size = new System.Drawing.Size(225, 77);
            this.richestado.TabIndex = 0;
            this.richestado.Text = "";
            // 
            // EstadosProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(233, 101);
            this.Controls.Add(this.richestado);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EstadosProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EstadosProducto";
            this.Load += new System.EventHandler(this.EstadosProducto_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richestado;
    }
}