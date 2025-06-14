using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _686DP_BLL;
using _686DP_SERVICIOS;
using _686DP_BE;
using System.Text.RegularExpressions;

namespace AseguraYa
{
    public partial class _686DPfrmGestionUsuarios : Form
    {
        string modo;
        _686DP_BLLUsuario _686DP_BLLUsuario;
        _686DP_ExpresionesRegulares _686DP_ExpresionesRegulares;
        private bool esModoCrear = false;
        //entorno conectado
        string dni = "";
        string nombre = "";
        string apellido = "";
        string email = "";
        string rol = "";
        string usuario = "";
        string contraseña = "";
        bool activo = true;
        bool bloqueado = false;
        public _686DPfrmGestionUsuarios()
        {
            InitializeComponent();
            _686DP_BLLUsuario = new _686DP_BLLUsuario();
            _686DP_ExpresionesRegulares = new _686DP_ExpresionesRegulares();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DP_BTNCrear_Click(object sender, EventArgs e)
        {
            modo = "creador";
            DP_TXTMessage.Text = "Modo Creador";
            BTNModificar.Enabled = false;
            DP_BTNDesbloquear.Enabled = false;
            DP_BTNActivarEliminar.Enabled = false;
            DP_BTNCrear.Enabled = true;

            DP_BTNCancelar.Enabled = true;
            DP_BTNAplicar.Enabled = true;
            DP_TXTApellido.Enabled = true;
            DP_TXTDni.Enabled = true;
            DP_TXTEmail.Enabled = true;
            DP_TXTNombre.Enabled = true;
            DP_CMBRol.Enabled = true;

            DP_BTNAplicar.Enabled = true;
            DP_BTNCancelar.Enabled = true;
        }

        private void _686DPfrmGestionUsuarios_Load(object sender, EventArgs e)
        {
            Resetear();

            cargarDataGrid();

            LLenarCombo();

            int cantidadFilas = DP_Datagrid.Rows.Count;
            label11.Text = "Cantidad de empleados:"+cantidadFilas.ToString();

            this.FormClosing += new FormClosingEventHandler(_686DPfrmGestionUsuarios_FormClosing);
            
        }

        private void cargarDataGrid()
        {
            this.DP_Datagrid.DataSource = null;
            this.DP_Datagrid.DataSource = _686DP_BLLUsuario._686DPTraerTodos();
            this.DP_Datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Resetear()
        {
            DP_Datagrid.ReadOnly = true;
            DP_TXTMessage.Text = "Seleccionar un modo";
            BTNModificar.Enabled = true;
            DP_BTNDesbloquear.Enabled = true;
            DP_BTNActivarEliminar.Enabled = true;
            DP_BTNCrear.Enabled = true;

            DP_BTNCancelar.Enabled = true;
            DP_BTNAplicar.Enabled = true;
            DP_TXTApellido.Enabled = false;
            DP_TXTDni.Enabled = false;
            DP_TXTEmail.Enabled = false;
            DP_TXTNombre.Enabled = false;
            DP_CMBRol.Enabled = false;

            DP_BTNAplicar.Enabled = false;

            DP_TXTDni.Text = "";
            DP_TXTApellido.Text = "";
            DP_TXTNombre.Text = "";
            DP_TXTEmail.Text = "";
            DP_CMBRol.SelectedIndex = -1;
        }

        private void _686DPfrmGestionUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void _686DPActualizarFilaSeleccionada(object sender, EventArgs e)
        {
            if (DP_Datagrid.SelectedRows.Count == 0) return;

            DataGridViewRow fila = DP_Datagrid.SelectedRows[0];

            fila.Cells["DP686_Nombre"].Value = DP_TXTNombre.Text;
            fila.Cells["DP686_Apellido"].Value = DP_TXTApellido.Text;
            fila.Cells["DP686_Email"].Value = DP_TXTEmail.Text;
            fila.Cells["DP686_Rol"].Value = DP_CMBRol.SelectedItem?.ToString() ?? "";
        }

        private void LLenarCombo()
        {
            List<string> roles = _686DP_BLLUsuario._686DPtraerRoles()
                                    .Distinct()
                                    .ToList();

            DP_CMBRolesFiltro.Items.Clear();
            DP_CMBRol.Items.Clear();

            foreach (string rol in roles)
            {
                DP_CMBRolesFiltro.Items.Add(rol);
                DP_CMBRol.Items.Add(rol);
            }
        }

        private void DP_BTNDesbloquear_Click(object sender, EventArgs e)
        {
           
            modo = "desbloqueo";
            DP_TXTMessage.Text = "Modo Desbloquear usuario bloqueado";
            DP_BTNCrear.Enabled = false;
            BTNModificar.Enabled = false;
            DP_BTNDesbloquear.Enabled = true;
            DP_BTNActivarEliminar.Enabled = false;

            DP_BTNCancelar.Enabled = false;
            DP_BTNAplicar.Enabled = false;
            DP_TXTApellido.Enabled = false;
            DP_TXTDni.Enabled = false;
            DP_TXTEmail.Enabled = false;
            DP_TXTNombre.Enabled = false;
            DP_CMBRol.Enabled = false;

            DP_BTNAplicar.Enabled = true;
            DP_BTNCancelar.Enabled = true;
        }

        private void BTNModificar_Click(object sender, EventArgs e)
        {
            modo = "Modificacion";
            DP_TXTMessage.Text = "Modo Edición";
            DP_BTNCrear.Enabled = false;
            BTNModificar.Enabled = true;
            DP_BTNDesbloquear.Enabled = false;
            DP_BTNActivarEliminar.Enabled = false;

            DP_BTNCancelar.Enabled = true;
            DP_BTNAplicar.Enabled = true;
            DP_TXTApellido.Enabled = true;
            DP_TXTDni.Enabled = false;
            DP_TXTEmail.Enabled = true;
            DP_TXTNombre.Enabled = true;
            DP_CMBRol.Enabled = true;

            DP_BTNAplicar.Enabled = true;
            DP_BTNCancelar.Enabled = true;

            modo = "Modificacion";
            if (DP_Datagrid.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = DP_Datagrid.SelectedRows[0];

                DP_TXTDni.Text = fila.Cells["DP686_DNI"].Value.ToString();
                DP_TXTNombre.Text = fila.Cells["DP686_Nombre"].Value.ToString();
                DP_TXTApellido.Text = fila.Cells["DP686_Apellido"].Value.ToString();
                DP_TXTEmail.Text = fila.Cells["DP686_Email"].Value.ToString();
                DP_CMBRol.SelectedItem = fila.Cells["DP686_Rol"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccioná una fila para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BTNModificar.Enabled = true;
            }
        }

        private void DP_BTNActivarEliminar_Click(object sender, EventArgs e)
        {
            DP_Datagrid.ReadOnly = false;
            modo = "activar";
            DP_TXTMessage.Text = "Modo Activar o eliminar (Borrado o recontratación lógica)";
            DP_BTNCrear.Enabled = false;
            BTNModificar.Enabled = false;
            DP_BTNDesbloquear.Enabled = false;
            DP_BTNActivarEliminar.Enabled = true;

            DP_BTNCancelar.Enabled = false;
            DP_BTNAplicar.Enabled = false;
            DP_TXTApellido.Enabled = false;
            DP_TXTDni.Enabled = false;
            DP_TXTEmail.Enabled = false;
            DP_TXTNombre.Enabled = false;
            DP_CMBRol.Enabled = false;
            DP_BTNAplicar.Enabled = true;
            DP_BTNCancelar.Enabled = true;
        }

        private void DP_BTNCancelar_Click(object sender, EventArgs e)
        {
            Resetear();
        }

        private void DP_BTNSalir_Click(object sender, EventArgs e)
        {
            this.Close(); // salir sin guardar
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void DP_BTNFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                bool? activo = null;
                bool? bloqueado = null;
                string rol = null;

                // Activo / Desactivado
                if (DP_CMBActDact.SelectedItem != null)
                {
                    string seleccionado = DP_CMBActDact.SelectedItem.ToString();
                    if (seleccionado == "Activos") activo = true;
                    else if (seleccionado == "Desactivados") activo = false;
                }

                // Bloqueado / No bloqueado
                if (DP_CMBBloqueados.SelectedItem != null)
                {
                    string seleccionado = DP_CMBBloqueados.SelectedItem.ToString();
                    if (seleccionado == "Bloqueados") bloqueado = true;
                    else if (seleccionado == "No bloqueados") bloqueado = false;
                }

                // Rol
                if (DP_CMBRol.SelectedItem != null)
                {
                    rol = DP_CMBRol.SelectedItem.ToString();
                }

                // Ejecutar filtrado
                DP_Datagrid.DataSource = _686DP_BLLUsuario._686DPFiltrarGridFlexible(rol, activo, bloqueado);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error de base de datos al intentar filtrar:\n" + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al filtrar:\n" + ex.Message, "Error general", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DP_Datagrid_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegura que no sea el encabezado
            {
                DataGridViewRow fila = DP_Datagrid.Rows[e.RowIndex];

                dni = fila.Cells["DP686_DNI"].Value.ToString();
                nombre = fila.Cells["DP686_Nombre"].Value.ToString();
                apellido = fila.Cells["DP686_Apellido"].Value.ToString();
                email = fila.Cells["DP686_Email"].Value.ToString();
                rol = fila.Cells["DP686_Rol"].Value.ToString();
                usuario = fila.Cells["DP686_Usuario"].Value.ToString();
                contraseña = fila.Cells["DP686_Contraseña"].Value.ToString();
                activo = Convert.ToBoolean(fila.Cells["DP686_Activo"].Value);
                bloqueado = Convert.ToBoolean(fila.Cells["DP686_Bloqueado"].Value);
            }
        }

        private void DP_BTNAplicar_Click(object sender, EventArgs e)
        {
            if (modo == "creador" || modo == "Modificacion")
            {
                if (DP_TXTDni.Text == "" || DP_TXTApellido.Text == "" || DP_TXTNombre.Text == "" || DP_CMBRol.SelectedIndex == -1)
                {
                    MessageBox.Show("Completá todos los campos obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            try
            {
                switch (modo)
                {
                    case "creador":
                        {
                            try
                            {
                                int dni = int.Parse(DP_TXTDni.Text);


                                bool dniExiste = _686DP_BLLUsuario.ListaDeUsuarios.Any(emp => emp.DP686_DNI == dni);
                                if (dniExiste)
                                {
                                    MessageBox.Show("Ya existe un Usuario con ese DNI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                _686DPCriptoManager cm = new _686DPCriptoManager();
                                string usuario = DP_TXTNombre.Text + "." + DP_TXTApellido.Text;
                                string contra = DP_TXTDni.Text + "." + DP_TXTApellido.Text;
                                string contraHash = cm._686DPGetSHA256(contra);

                                _686DP_Usuarios nuevo = new _686DP_Usuarios(
                                    dni,
                                    DP_TXTNombre.Text,
                                    DP_TXTApellido.Text,
                                    DP_TXTEmail.Text,
                                    DP_CMBRol.SelectedItem.ToString(),
                                    usuario,
                                    contraHash,
                                    true,
                                    false,
                                    false
                                );
                                _686DP_BLLUsuario.ListaDeUsuarios.Add(nuevo);
                                this.DP_Datagrid.DataSource = null;
                                this.DP_Datagrid.DataSource = _686DP_BLLUsuario.ListaDeUsuarios;
                                this.DP_Datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                                _686DPGuardar();
                                MessageBox.Show("Usuario creado exitosamente.");
                                Resetear();
                                return;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error al crear nuevo Usuario: " + ex.Message);
                            }
                            break;
                        }
                    case "desbloqueo":
                        {
                            if (DP_Datagrid.SelectedRows.Count == 0)
                            {
                                MessageBox.Show("Debés seleccionar un usuario para desbloquearlo.", "Seleccionar fila", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            DataGridViewRow filaSeleccionada = DP_Datagrid.SelectedRows[0];
                            object valorBloqueado = filaSeleccionada.Cells["DP686_Bloqueado"].Value;

                            if (valorBloqueado == null || valorBloqueado == DBNull.Value)
                            {
                                MessageBox.Show("El campo 'Bloqueado' no tiene un valor válido.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            bool yaEstabaDesbloqueado = !Convert.ToBoolean(valorBloqueado);

                            if (yaEstabaDesbloqueado)
                            {
                                MessageBox.Show("El usuario ya estaba desbloqueado. No se realizaron cambios.", "Sin cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            // Desbloquear
                            filaSeleccionada.Cells["DP686_Bloqueado"].Value = false;

                            // Restablecer contraseña a Apellido + DNI
                            string ContraseñaAnterior = filaSeleccionada.Cells["DP686_Contraseña"].Value.ToString();

                            string apellido = filaSeleccionada.Cells["DP686_Apellido"].Value.ToString();
                            int dni = Convert.ToInt32(filaSeleccionada.Cells["DP686_DNI"].Value);
                            string nuevaContraseña = dni + "." + apellido;
                            string usuario = filaSeleccionada.Cells["DP686_Usuario"].Value.ToString();

                            _686DP_BLLUsuario.GuardarContraseña(ContraseñaAnterior, dni);

                            _686DPCriptoManager cripto = new _686DPCriptoManager();
                            string nuevaContraseñaHash = cripto._686DPGetSHA256(nuevaContraseña);

                            // Actualizar en la grilla
                            filaSeleccionada.Cells["DP686_Contraseña"].Value = nuevaContraseñaHash;
                            _686DP_BLLUsuario._686DPReestablecerIntentos(dni);
                            _686DP_BLLUsuario._Cambiarcontraobligatorio(dni);

                            _686DPGuardar();
                            MessageBox.Show("El usuario fue desbloqueado correctamente y se restableció la contraseña a: " + nuevaContraseña, "Desbloqueo exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Resetear();
                            break;
                        }
                    case "Modificacion":
                        {
                            if (DP_Datagrid.SelectedRows.Count == 0)
                            {
                                MessageBox.Show("Seleccioná una fila para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            // Actualizar los datos modificados del formulario a la grilla
                            DataGridViewRow fila = DP_Datagrid.SelectedRows[0];
                            fila.Cells["DP686_Nombre"].Value = DP_TXTNombre.Text;
                            fila.Cells["DP686_Apellido"].Value = DP_TXTApellido.Text;
                            fila.Cells["DP686_Email"].Value = DP_TXTEmail.Text;
                            fila.Cells["DP686_Rol"].Value = DP_CMBRol.SelectedItem?.ToString() ?? "";

                            _686DPGuardar();

                            MessageBox.Show("Usuario modificado correctamente.");
                            Resetear();
                            break;
                        }
                    case "activar":
                        {

                            if (DP_Datagrid.SelectedRows.Count == 0)
                            {
                                MessageBox.Show("Debés seleccionar un usuario para activar o desactivar.", "Seleccionar fila", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            DataGridViewRow filaSeleccionada = DP_Datagrid.SelectedRows[0];
                            object valorActivo = filaSeleccionada.Cells["DP686_Activo"].Value;

                            if (valorActivo == null || valorActivo == DBNull.Value)
                            {
                                MessageBox.Show("El campo 'Activo' no tiene un valor válido.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            bool estadoActual = Convert.ToBoolean(valorActivo);
                            filaSeleccionada.Cells["DP686_Activo"].Value = !estadoActual;

                            _686DPGuardar();
                            string mensaje = estadoActual ? "Usuario desactivado correctamente." : "Usuario activado correctamente.";
                            MessageBox.Show(mensaje, "Cambio de estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Resetear();
                            break;
                        }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void _686DPGuardar()
        {
            try
            {
                _686DP_BLLUsuario bll = new _686DP_BLLUsuario();
                _686DPCriptoManager cripto = new _686DPCriptoManager();

                foreach (DataGridViewRow fila in DP_Datagrid.Rows)
                {
                    if (fila.IsNewRow) continue;

                    int dni = Convert.ToInt32(fila.Cells["DP686_DNI"].Value);


                    // Buscar el empleado en la lista ya existente
                    _686DP_Usuarios usr = bll.ListaDeUsuarios.FirstOrDefault(usuario => usuario.DP686_DNI == dni);

                    if (usr != null)
                    {
                        // Actualizar campos si cambió algo
                        usr.DP686_Nombre = fila.Cells["DP686_Nombre"].Value.ToString();
                        usr.DP686_Apellido = fila.Cells["DP686_Apellido"].Value.ToString();
                        usr.DP686_Email = fila.Cells["DP686_Email"].Value.ToString();
                        usr.DP686_Rol = fila.Cells["DP686_Rol"].Value.ToString();
                        usr.DP686_Usuario = fila.Cells["DP686_Usuario"].Value.ToString();
                        usr.DP686_Contraseña = fila.Cells["DP686_Contraseña"].Value.ToString();
                        usr.DP686_Activo = Convert.ToBoolean(fila.Cells["DP686_Activo"].Value);
                        usr.DP686_Bloqueado = Convert.ToBoolean(fila.Cells["DP686_Bloqueado"].Value);

                        // Actualizar en la BD
                        bll._686DPActualizarUsuarioExistente(usr);
                    }
                    else
                    {
                        _686DP_Usuarios nuevo = new _686DP_Usuarios(
                            dni,
                            fila.Cells["DP686_Nombre"].Value.ToString(),
                            fila.Cells["DP686_Apellido"].Value.ToString(),
                            fila.Cells["DP686_Email"].Value.ToString(),
                            fila.Cells["DP686_Rol"].Value.ToString(),
                            fila.Cells["DP686_Usuario"].Value.ToString(),
                            fila.Cells["DP686_Contraseña"].Value.ToString(),
                            Convert.ToBoolean(fila.Cells["DP686_Activo"].Value),
                            Convert.ToBoolean(fila.Cells["DP686_Bloqueado"].Value),
                            Convert.ToBoolean(fila.Cells["DP686_CambiarContraseña"].Value)
                        );

                        bll._686DPActualizarUsuarioExistente(nuevo);
                    }
                }

                MessageBox.Show("✔ Cambios aplicados correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al aplicar cambios: " + ex.Message);
            }
        }

        private void DP_TXTDni_TextChanged(object sender, EventArgs e)
        {
            if (DP_TXTDni.Text != "")
            {
                try
                {

                    if (!_686DP_ExpresionesRegulares._686DPEsNumero(DP_TXTDni.Text.ToString()))
                    {
                        MessageBox.Show("Solo se permiten números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DP_TXTDni.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de validación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DP_TXTApellido_TextChanged(object sender, EventArgs e)
        {
            if (DP_TXTApellido.Text != "")
            {
                try
                {

                    if (!_686DP_ExpresionesRegulares._686DPEsSoloLetras(DP_TXTApellido.Text))
                    {
                        MessageBox.Show("Solo se permiten caracteres alfabéticos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DP_TXTApellido.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de validación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DP_TXTNombre_TextChanged(object sender, EventArgs e)
        {
            if (DP_TXTNombre.Text != "")
            {
                try
                {

                    if (!_686DP_ExpresionesRegulares._686DPEsSoloLetras(DP_TXTNombre.Text))
                    {
                        MessageBox.Show("Solo se permiten caracteres alfabéticos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DP_TXTNombre.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de validación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DP_TXTEmail_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void DP_TXTEmail_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DP_TXTEmail.Text))
            {
                try
                {
                    if (!_686DP_ExpresionesRegulares._686DPEsEmail(DP_TXTEmail.Text))
                    {
                        MessageBox.Show("El campo debe tener una estructura de email válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DP_TXTEmail.Focus();
                        DP_TXTEmail.SelectAll();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de validación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void DP_CMBRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DP_Datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
