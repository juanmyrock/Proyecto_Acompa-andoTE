using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CapaVistas.Forms_Menu
{
    public partial class frmPermisos : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private int _idUsuario;
        private int _idRol;
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
            //ta to simulao
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

            int currentTop = 10;

            foreach (var perm in todosLosPermisos)
            {
                bool vienePorRol = permisosPorRol.Contains(perm.ID);
                var permisoUsuario = permisosPorUsuario.Find(p => p.ID == perm.ID);
                bool tienePermisoUsuario = permisoUsuario != null;

                CheckBox chk = new CheckBox();
                chk.Text = perm.Nombre;
                chk.Tag = perm.ID;
                chk.ForeColor = Color.White;
                chk.Font = new Font("Century Gothic", 9.75F);
                chk.Location = new Point(10, currentTop);
                chk.Width = 200;

                TextBox txtVencimiento = new TextBox();
                txtVencimiento.Font = new Font("Century Gothic", 9.75F);
                txtVencimiento.Location = new Point(210, currentTop);
                txtVencimiento.Width = 180;

                chk.Tag = new PermisoTag { Id = perm.ID, TxtVencimiento = txtVencimiento };
                txtVencimiento.Tag = chk;

                if (vienePorRol)
                {
                    chk.Checked = true;
                    chk.Enabled = false;
                    txtVencimiento.Text = "Viene por Rol";
                    txtVencimiento.Enabled = false;
                }
                else if (tienePermisoUsuario)
                {
                    chk.Checked = true;
                    txtVencimiento.Text = permisoUsuario.Vencimiento.ToString("dd/MM/yyyy");
                    txtVencimiento.Enabled = true;
                }
                else
                {
                    chk.Checked = false;
                    txtVencimiento.Text = "";
                    txtVencimiento.Enabled = false;
                }

                chk.CheckedChanged += Chk_CheckedChanged;
                pnlPermisos.Controls.Add(chk);
                pnlPermisos.Controls.Add(txtVencimiento);
                currentTop += 30;
            }
        }
        private void Chk_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            PermisoTag tag = (PermisoTag)chk.Tag;
            TextBox txtVencimiento = tag.TxtVencimiento;
            txtVencimiento.Enabled = chk.Checked;
            if (!chk.Checked)
            {
                txtVencimiento.Text = "";
            }
        }

        private class PermisoTag
        {
            public int Id { get; set; }
            public TextBox TxtVencimiento { get; set; }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            foreach (Control control in pnlPermisos.Controls)
            {
                if (control is CheckBox chk)
                {
                    if (!chk.Enabled) continue;

                    if (chk.Checked)
                    {
                        PermisoTag tag = (PermisoTag)chk.Tag;
                        int idPermiso = tag.Id;
                        string vencimientoStr = tag.TxtVencimiento.Text;
                        DateTime? vencimiento = null;

                        if (!string.IsNullOrWhiteSpace(vencimientoStr))
                        {
                            if (DateTime.TryParseExact(vencimientoStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime fecha))
                            {
                                vencimiento = fecha;
                            }
                            else
                            {
                                MessageBox.Show($"El formato de fecha '{vencimientoStr}' para el permiso '{chk.Text}' no es válido. Formato esperado: dd/MM/aaaa.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }
            }
            MessageBox.Show("Permisos actualizados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

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