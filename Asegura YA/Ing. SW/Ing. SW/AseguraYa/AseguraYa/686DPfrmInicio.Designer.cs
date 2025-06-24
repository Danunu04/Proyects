namespace AseguraYa
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.DP_Usuario = new System.Windows.Forms.ToolStripMenuItem();
            this.DP_IniciarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.DP_CambiarContraseña = new System.Windows.Forms.ToolStripMenuItem();
            this.DP_Admin = new System.Windows.Forms.ToolStripMenuItem();
            this.DP_GestionDeUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.DP_GestionDePerfiles = new System.Windows.Forms.ToolStripMenuItem();
            this.DP_BitacoraDeEventos = new System.Windows.Forms.ToolStripMenuItem();
            this.DP_GestionDeRespaldo = new System.Windows.Forms.ToolStripMenuItem();
            this.mestroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDeProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DP_Contratacion = new System.Windows.Forms.ToolStripMenuItem();
            this.generarContratacion = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarSeguroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarSeguroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Dp_Siniestros = new System.Windows.Forms.ToolStripMenuItem();
            this.DP_CerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.DP_CambiarIdioma = new System.Windows.Forms.ToolStripMenuItem();
            this.Dp_Ayuda = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DP_Usuario,
            this.DP_Admin,
            this.mestroToolStripMenuItem,
            this.DP_Contratacion,
            this.Dp_Siniestros,
            this.DP_CerrarSesion,
            this.DP_CambiarIdioma,
            this.Dp_Ayuda});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "DP_Menustript";
            // 
            // DP_Usuario
            // 
            this.DP_Usuario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DP_IniciarSesion,
            this.DP_CambiarContraseña});
            this.DP_Usuario.Name = "DP_Usuario";
            this.DP_Usuario.Size = new System.Drawing.Size(59, 20);
            this.DP_Usuario.Tag = "686DP_Usuario";
            this.DP_Usuario.Text = "Usuario";
            // 
            // DP_IniciarSesion
            // 
            this.DP_IniciarSesion.Name = "DP_IniciarSesion";
            this.DP_IniciarSesion.Size = new System.Drawing.Size(182, 22);
            this.DP_IniciarSesion.Text = "Iniciar sesión";
            this.DP_IniciarSesion.Click += new System.EventHandler(this.DP_IniciarSesion_Click);
            // 
            // DP_CambiarContraseña
            // 
            this.DP_CambiarContraseña.Name = "DP_CambiarContraseña";
            this.DP_CambiarContraseña.Size = new System.Drawing.Size(182, 22);
            this.DP_CambiarContraseña.Text = "Cambiar Contraseña";
            this.DP_CambiarContraseña.Click += new System.EventHandler(this.DP_CambiarContraseña_Click);
            // 
            // DP_Admin
            // 
            this.DP_Admin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DP_GestionDeUsuarios,
            this.DP_GestionDePerfiles,
            this.DP_BitacoraDeEventos,
            this.DP_GestionDeRespaldo});
            this.DP_Admin.Name = "DP_Admin";
            this.DP_Admin.Size = new System.Drawing.Size(55, 20);
            this.DP_Admin.Text = "Admin";
            // 
            // DP_GestionDeUsuarios
            // 
            this.DP_GestionDeUsuarios.Name = "DP_GestionDeUsuarios";
            this.DP_GestionDeUsuarios.Size = new System.Drawing.Size(178, 22);
            this.DP_GestionDeUsuarios.Text = "Gestion de usuarios";
            this.DP_GestionDeUsuarios.Click += new System.EventHandler(this.DP_GestionDeUsuarios_Click);
            // 
            // DP_GestionDePerfiles
            // 
            this.DP_GestionDePerfiles.Name = "DP_GestionDePerfiles";
            this.DP_GestionDePerfiles.Size = new System.Drawing.Size(178, 22);
            this.DP_GestionDePerfiles.Text = "Gestion de perfiles";
            // 
            // DP_BitacoraDeEventos
            // 
            this.DP_BitacoraDeEventos.Name = "DP_BitacoraDeEventos";
            this.DP_BitacoraDeEventos.Size = new System.Drawing.Size(178, 22);
            this.DP_BitacoraDeEventos.Text = "Bitacora de eventos";
            // 
            // DP_GestionDeRespaldo
            // 
            this.DP_GestionDeRespaldo.Name = "DP_GestionDeRespaldo";
            this.DP_GestionDeRespaldo.Size = new System.Drawing.Size(178, 22);
            this.DP_GestionDeRespaldo.Text = "Gestion de respaldo";
            // 
            // mestroToolStripMenuItem
            // 
            this.mestroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarClienteToolStripMenuItem,
            this.gestionDeProductosToolStripMenuItem});
            this.mestroToolStripMenuItem.Name = "mestroToolStripMenuItem";
            this.mestroToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.mestroToolStripMenuItem.Text = "Mestro";
            // 
            // registrarClienteToolStripMenuItem
            // 
            this.registrarClienteToolStripMenuItem.Name = "registrarClienteToolStripMenuItem";
            this.registrarClienteToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.registrarClienteToolStripMenuItem.Text = "Gestion de clientes";
            this.registrarClienteToolStripMenuItem.Click += new System.EventHandler(this.registrarClienteToolStripMenuItem_Click);
            // 
            // gestionDeProductosToolStripMenuItem
            // 
            this.gestionDeProductosToolStripMenuItem.Name = "gestionDeProductosToolStripMenuItem";
            this.gestionDeProductosToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.gestionDeProductosToolStripMenuItem.Text = "Gestion de productos";
            this.gestionDeProductosToolStripMenuItem.Click += new System.EventHandler(this.gestionDeProductosToolStripMenuItem_Click);
            // 
            // DP_Contratacion
            // 
            this.DP_Contratacion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarContratacion,
            this.modificarSeguroToolStripMenuItem,
            this.eliminarSeguroToolStripMenuItem});
            this.DP_Contratacion.Name = "DP_Contratacion";
            this.DP_Contratacion.Size = new System.Drawing.Size(88, 20);
            this.DP_Contratacion.Text = "Contratacion";
            // 
            // generarContratacion
            // 
            this.generarContratacion.Name = "generarContratacion";
            this.generarContratacion.Size = new System.Drawing.Size(187, 22);
            this.generarContratacion.Text = "Generar Contratacion";
            this.generarContratacion.Click += new System.EventHandler(this.generarContratacion_Click);
            // 
            // modificarSeguroToolStripMenuItem
            // 
            this.modificarSeguroToolStripMenuItem.Name = "modificarSeguroToolStripMenuItem";
            this.modificarSeguroToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.modificarSeguroToolStripMenuItem.Text = "Modificar seguro";
            this.modificarSeguroToolStripMenuItem.Click += new System.EventHandler(this.modificarSeguroToolStripMenuItem_Click);
            // 
            // eliminarSeguroToolStripMenuItem
            // 
            this.eliminarSeguroToolStripMenuItem.Name = "eliminarSeguroToolStripMenuItem";
            this.eliminarSeguroToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.eliminarSeguroToolStripMenuItem.Text = "Eliminar Seguro";
            this.eliminarSeguroToolStripMenuItem.Click += new System.EventHandler(this.eliminarSeguroToolStripMenuItem_Click);
            // 
            // Dp_Siniestros
            // 
            this.Dp_Siniestros.Enabled = false;
            this.Dp_Siniestros.Name = "Dp_Siniestros";
            this.Dp_Siniestros.Size = new System.Drawing.Size(69, 20);
            this.Dp_Siniestros.Text = "Siniestros";
            // 
            // DP_CerrarSesion
            // 
            this.DP_CerrarSesion.Name = "DP_CerrarSesion";
            this.DP_CerrarSesion.Size = new System.Drawing.Size(88, 20);
            this.DP_CerrarSesion.Text = "Cerrar Sesión";
            this.DP_CerrarSesion.Click += new System.EventHandler(this.DP_CerrarSesion_Click);
            // 
            // DP_CambiarIdioma
            // 
            this.DP_CambiarIdioma.Name = "DP_CambiarIdioma";
            this.DP_CambiarIdioma.Size = new System.Drawing.Size(104, 20);
            this.DP_CambiarIdioma.Text = "Cambiar Idioma";
            this.DP_CambiarIdioma.Click += new System.EventHandler(this.DP_CambiarIdioma_Click);
            // 
            // Dp_Ayuda
            // 
            this.Dp_Ayuda.Name = "Dp_Ayuda";
            this.Dp_Ayuda.Size = new System.Drawing.Size(53, 20);
            this.Dp_Ayuda.Text = "Ayuda";
            this.Dp_Ayuda.Click += new System.EventHandler(this.Dp_Ayuda_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1184, 636);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "AseguraYA";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem DP_Usuario;
        private System.Windows.Forms.ToolStripMenuItem DP_Admin;
        private System.Windows.Forms.ToolStripMenuItem DP_Contratacion;
        private System.Windows.Forms.ToolStripMenuItem Dp_Siniestros;
        private System.Windows.Forms.ToolStripMenuItem Dp_Ayuda;
        private System.Windows.Forms.ToolStripMenuItem DP_IniciarSesion;
        private System.Windows.Forms.ToolStripMenuItem DP_CambiarContraseña;
        private System.Windows.Forms.ToolStripMenuItem DP_CerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem DP_CambiarIdioma;
        private System.Windows.Forms.ToolStripMenuItem DP_GestionDeUsuarios;
        private System.Windows.Forms.ToolStripMenuItem DP_GestionDePerfiles;
        private System.Windows.Forms.ToolStripMenuItem DP_BitacoraDeEventos;
        private System.Windows.Forms.ToolStripMenuItem DP_GestionDeRespaldo;
        private System.Windows.Forms.ToolStripMenuItem generarContratacion;
        private System.Windows.Forms.ToolStripMenuItem modificarSeguroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarSeguroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mestroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDeProductosToolStripMenuItem;
    }
}

