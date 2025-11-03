namespace AseguraYa
{
    partial class _686DPfrmRecomendacionDeAumento
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AumentarCuota = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 115);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 214);
            this.dataGridView1.TabIndex = 0;
            // 
            // AumentarCuota
            // 
            this.AumentarCuota.Location = new System.Drawing.Point(623, 335);
            this.AumentarCuota.Name = "AumentarCuota";
            this.AumentarCuota.Size = new System.Drawing.Size(165, 32);
            this.AumentarCuota.TabIndex = 1;
            this.AumentarCuota.Tag = "AumentarCuota";
            this.AumentarCuota.Text = "Aumentar cuota";
            this.AumentarCuota.UseVisualStyleBackColor = true;
            this.AumentarCuota.Click += new System.EventHandler(this.AumentarCuota_Click);
            // 
            // _686DPfrmRecomendacionDeAumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.ClientSize = new System.Drawing.Size(800, 371);
            this.Controls.Add(this.AumentarCuota);
            this.Controls.Add(this.dataGridView1);
            this.Name = "_686DPfrmRecomendacionDeAumento";
            this.Text = "_686DPfrmRecomendacionDeAumento";
            this.Load += new System.EventHandler(this._686DPfrmRecomendacionDeAumento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AumentarCuota;
    }
}