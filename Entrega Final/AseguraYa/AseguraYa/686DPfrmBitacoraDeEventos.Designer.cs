namespace AseguraYa
{
    partial class _686DPfrmBitacoraDeEventos
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CMBModulo = new System.Windows.Forms.ComboBox();
            this.CMBCriticidad = new System.Windows.Forms.ComboBox();
            this.TXTDNI = new System.Windows.Forms.TextBox();
            this.LBLModulo = new System.Windows.Forms.Label();
            this.LBLCriticidad = new System.Windows.Forms.Label();
            this.LBLDNI = new System.Windows.Forms.Label();
            this.BTNFiltrar = new System.Windows.Forms.Button();
            this.BTNLimpiarFiltros = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.LBLNombre = new System.Windows.Forms.Label();
            this.LBLApellido = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(586, 264);
            this.dataGridView1.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(628, 56);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(208, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(628, 101);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(208, 20);
            this.dateTimePicker2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(625, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 3;
            this.label1.Tag = "FechaDesde";
            this.label1.Text = "Fecha desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(625, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 4;
            this.label2.Tag = "FechaHasta";
            this.label2.Text = "Fecha hasta";
            // 
            // CMBModulo
            // 
            this.CMBModulo.FormattingEnabled = true;
            this.CMBModulo.Location = new System.Drawing.Point(628, 147);
            this.CMBModulo.Name = "CMBModulo";
            this.CMBModulo.Size = new System.Drawing.Size(208, 21);
            this.CMBModulo.TabIndex = 5;
            this.CMBModulo.Tag = "CMBModulo";
            // 
            // CMBCriticidad
            // 
            this.CMBCriticidad.FormattingEnabled = true;
            this.CMBCriticidad.Location = new System.Drawing.Point(628, 191);
            this.CMBCriticidad.Name = "CMBCriticidad";
            this.CMBCriticidad.Size = new System.Drawing.Size(208, 21);
            this.CMBCriticidad.TabIndex = 6;
            this.CMBCriticidad.Tag = "CMBCriticidad";
            // 
            // TXTDNI
            // 
            this.TXTDNI.Location = new System.Drawing.Point(628, 243);
            this.TXTDNI.Name = "TXTDNI";
            this.TXTDNI.Size = new System.Drawing.Size(208, 20);
            this.TXTDNI.TabIndex = 7;
            this.TXTDNI.Tag = "TXTDNI";
            this.TXTDNI.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // LBLModulo
            // 
            this.LBLModulo.AutoSize = true;
            this.LBLModulo.Location = new System.Drawing.Point(625, 131);
            this.LBLModulo.Name = "LBLModulo";
            this.LBLModulo.Size = new System.Drawing.Size(42, 13);
            this.LBLModulo.TabIndex = 8;
            this.LBLModulo.Text = "Modulo";
            // 
            // LBLCriticidad
            // 
            this.LBLCriticidad.AutoSize = true;
            this.LBLCriticidad.Location = new System.Drawing.Point(625, 175);
            this.LBLCriticidad.Name = "LBLCriticidad";
            this.LBLCriticidad.Size = new System.Drawing.Size(50, 13);
            this.LBLCriticidad.TabIndex = 9;
            this.LBLCriticidad.Tag = "LBLCriticidad";
            this.LBLCriticidad.Text = "Criticidad";
            // 
            // LBLDNI
            // 
            this.LBLDNI.AutoSize = true;
            this.LBLDNI.Location = new System.Drawing.Point(625, 227);
            this.LBLDNI.Name = "LBLDNI";
            this.LBLDNI.Size = new System.Drawing.Size(26, 13);
            this.LBLDNI.TabIndex = 10;
            this.LBLDNI.Tag = "LBLDNI";
            this.LBLDNI.Text = "DNI";
            // 
            // BTNFiltrar
            // 
            this.BTNFiltrar.Location = new System.Drawing.Point(870, 56);
            this.BTNFiltrar.Name = "BTNFiltrar";
            this.BTNFiltrar.Size = new System.Drawing.Size(124, 20);
            this.BTNFiltrar.TabIndex = 11;
            this.BTNFiltrar.Tag = "BTNFiltrar";
            this.BTNFiltrar.Text = "Filtrar";
            this.BTNFiltrar.UseVisualStyleBackColor = true;
            // 
            // BTNLimpiarFiltros
            // 
            this.BTNLimpiarFiltros.Location = new System.Drawing.Point(870, 101);
            this.BTNLimpiarFiltros.Name = "BTNLimpiarFiltros";
            this.BTNLimpiarFiltros.Size = new System.Drawing.Size(124, 20);
            this.BTNLimpiarFiltros.TabIndex = 12;
            this.BTNLimpiarFiltros.Tag = "BTNLimpiarFiltros";
            this.BTNLimpiarFiltros.Text = "Limpiar Filtro";
            this.BTNLimpiarFiltros.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(870, 148);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(124, 20);
            this.textBox1.TabIndex = 13;
            this.textBox1.Tag = "TXTDNI";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(870, 192);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(124, 20);
            this.textBox2.TabIndex = 14;
            this.textBox2.Tag = "TXTDNI";
            // 
            // LBLNombre
            // 
            this.LBLNombre.AutoSize = true;
            this.LBLNombre.Location = new System.Drawing.Point(867, 131);
            this.LBLNombre.Name = "LBLNombre";
            this.LBLNombre.Size = new System.Drawing.Size(44, 13);
            this.LBLNombre.TabIndex = 15;
            this.LBLNombre.Tag = "LBLNombre";
            this.LBLNombre.Text = "Nombre";
            this.LBLNombre.Click += new System.EventHandler(this.label3_Click);
            // 
            // LBLApellido
            // 
            this.LBLApellido.AutoSize = true;
            this.LBLApellido.Location = new System.Drawing.Point(867, 176);
            this.LBLApellido.Name = "LBLApellido";
            this.LBLApellido.Size = new System.Drawing.Size(44, 13);
            this.LBLApellido.TabIndex = 16;
            this.LBLApellido.Tag = "LBLApellido";
            this.LBLApellido.Text = "Apellido";
            // 
            // _686DPfrmBitacoraDeEventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(1006, 322);
            this.Controls.Add(this.LBLApellido);
            this.Controls.Add(this.LBLNombre);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BTNLimpiarFiltros);
            this.Controls.Add(this.BTNFiltrar);
            this.Controls.Add(this.LBLDNI);
            this.Controls.Add(this.LBLCriticidad);
            this.Controls.Add(this.LBLModulo);
            this.Controls.Add(this.TXTDNI);
            this.Controls.Add(this.CMBCriticidad);
            this.Controls.Add(this.CMBModulo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "_686DPfrmBitacoraDeEventos";
            this.Text = "_686DPfrmBitacoraDeEventos";
            this.Load += new System.EventHandler(this._686DPfrmBitacoraDeEventos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CMBModulo;
        private System.Windows.Forms.ComboBox CMBCriticidad;
        private System.Windows.Forms.TextBox TXTDNI;
        private System.Windows.Forms.Label LBLModulo;
        private System.Windows.Forms.Label LBLCriticidad;
        private System.Windows.Forms.Label LBLDNI;
        private System.Windows.Forms.Button BTNFiltrar;
        private System.Windows.Forms.Button BTNLimpiarFiltros;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label LBLNombre;
        private System.Windows.Forms.Label LBLApellido;
    }
}