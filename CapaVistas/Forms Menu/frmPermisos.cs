using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CapaVistas.Forms_Menu // O tu namespace
{
    public partial class frmPermisos : Form
    {
        // Variables para arrastrar
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        // Propiedades del usuario
        private int _idUsuario;
        private int _idRol;

        // Constructor (igual que antes)
        public frmPermisos(int idUsuario, string nombreUsuario, int idRol)
        {
            InitializeComponent();
            this._idUsuario = idUsuario;
            this._idRol = idRol;
            lblNombreUsuario.Text = nombreUsuario;
        }

        private void frmPermisosAlternativo_Load(object sender, EventArgs e)
        {
            CargarPermisos();
        }

        private void CargarPermisos()
        {
            pnlPermisos.Controls.Clear();

            // --- SIMULACIÓN DE DATOS (REEMPLAZAR CON TUS CONSULTAS) ---
            var todosLosPermisos = new List<dynamic> {
                new { ID = 1, Nombre = "Crear Pacientes" },
                new { ID = 2, Nombre = "Modificar Pacientes" },
                new { ID = 3, Nombre = "Eliminar Pacientes" },
                new { ID = 4, Nombre = "Ver Reportes" },
                new { ID = 5, Nombre = "Gestionar Usuarios" },
                new { ID = 6, Nombre = "Anular Turnos" }
            };
            var permisosPorRol = new List<int> { 1, 2, 4 };
            var permisosPorUsuario = new List<dynamic> {
                new { ID = 6, Vencimiento = new DateTime(2025, 12, 31) }
            };
            // --- FIN SIMULACIÓN ---

            int currentTop = 10; // Posición vertical inicial

            foreach (var perm in todosLosPermisos)
            {
                bool vienePorRol = permisosPorRol.Contains(perm.ID);
                var permisoUsuario = permisosPorUsuario.Find(p => p.ID == perm.ID);
                bool tienePermisoUsuario = permisoUsuario != null;

                // 1. Crear el CheckBox
                CheckBox chk = new CheckBox();
                chk.Text = perm.Nombre;
                chk.Tag = perm.ID; // Guardamos el ID del permiso aquí
                chk.ForeColor = Color.White;
                chk.Font = new Font("Century Gothic", 9.75F);
                chk.Location = new Point(10, currentTop);
                chk.Width = 200;

                // 2. Crear el TextBox para el vencimiento
                TextBox txtVencimiento = new TextBox();
                txtVencimiento.Font = new Font("Century Gothic", 9.75F);
                txtVencimiento.Location = new Point(210, currentTop);
                txtVencimiento.Width = 180;

                // Guardamos una referencia cruzada para encontrarlos fácilmente
                chk.Tag = new PermisoTag { Id = perm.ID, TxtVencimiento = txtVencimiento };
                txtVencimiento.Tag = chk;

                // 3. Aplicar la lógica
                if (vienePorRol)
                {
                    chk.Checked = true;
                    chk.Enabled = false; // Deshabilitado, no se puede cambiar
                    txtVencimiento.Text = "Viene por Rol";
                    txtVencimiento.Enabled = false;
                }
                else if (tienePermisoUsuario)
                {
                    chk.Checked = true;
                    txtVencimiento.Text = permisoUsuario.Vencimiento.ToString("dd/MM/yyyy");
                    txtVencimiento.Enabled = true; // Habilitado para editar
                }
                else
                {
                    chk.Checked = false;
                    txtVencimiento.Text = "";
                    txtVencimiento.Enabled = false; // Deshabilitado hasta que se marque
                }

                // 4. Conectar el evento
                chk.CheckedChanged += Chk_CheckedChanged;

                // 5. Agregar al Panel
                pnlPermisos.Controls.Add(chk);
                pnlPermisos.Controls.Add(txtVencimiento);

                // 6. Incrementar la posición para el siguiente control
                currentTop += 30;
            }
        }

        // El evento que se dispara CADA VEZ que un CheckBox cambia
        private void Chk_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            PermisoTag tag = (PermisoTag)chk.Tag;
            TextBox txtVencimiento = tag.TxtVencimiento;

            // Habilita o deshabilita el TextBox basado en si el CheckBox está marcado
            txtVencimiento.Enabled = chk.Checked;
            if (!chk.Checked)
            {
                txtVencimiento.Text = ""; // Borra la fecha si se desmarca
            }
        }

        // Clase auxiliar para guardar referencias en el Tag
        private class PermisoTag
        {
            public int Id { get; set; }
            public TextBox TxtVencimiento { get; set; }
        }

        // --- LÓGICA DE CONTROLES ---
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. AQUÍ: Iniciar una Transacción
            // 2. AQUÍ: Borrar todos los permisos explícitos de este usuario
            // DELETE FROM Usuario_Permiso WHERE id_usuario = this._idUsuario

            // 3. Recorrer la grilla y re-insertar
            foreach (Control control in pnlPermisos.Controls)
            {
                // Solo nos interesan los CheckBox
                if (control is CheckBox chk)
                {
                    // Si el CheckBox está deshabilitado, es porque viene por ROL. Lo ignoramos.
                    if (!chk.Enabled) continue;

                    // Si está tildado, es un permiso explícito que debemos guardar
                    if (chk.Checked)
                    {
                        PermisoTag tag = (PermisoTag)chk.Tag;
                        int idPermiso = tag.Id;
                        string vencimientoStr = tag.TxtVencimiento.Text;
                        DateTime? vencimiento = null; // Nullable DateTime

                        if (!string.IsNullOrWhiteSpace(vencimientoStr))
                        {
                            if (DateTime.TryParseExact(vencimientoStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime fecha))
                            {
                                vencimiento = fecha;
                            }
                            else
                            {
                                MessageBox.Show($"El formato de fecha '{vencimientoStr}' para el permiso '{chk.Text}' no es válido. Formato esperado: dd/MM/aaaa.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                // AQUÍ: Abortar la transacción (ROLLBACK)
                                return;
                            }
                        }

                        // 4. AQUÍ: Insertar el permiso explícito
                        // INSERT INTO Usuario_Permiso (id_usuario, id_permiso, fecha_vencimiento)
                        // VALUES (this._idUsuario, idPermiso, vencimiento) 
                    }
                }
            }

            // 5. AQUÍ: COMMIT de la Transacción
            MessageBox.Show("Permisos actualizados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // --- LÓGICA PARA ARRASTRAR EL FORMULARIO ---
        private void frm_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void frm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void frm_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}