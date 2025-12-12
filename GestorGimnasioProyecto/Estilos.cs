using System;
using System.Drawing;
using System.Windows.Forms;

namespace GestorGimnasioProyecto
{
    internal static class Estilos
    {
        // ===== PALETA DE COLORES MINIMALISTA =====
        public static Color FondoPrincipal = Color.FromArgb(245, 246, 248); // casi blanco con gris suave
        public static Color FondoTarjetas = Color.FromArgb(255, 255, 255); // blanco puro, estilo panel
        public static Color ColorTexto = Color.FromArgb(40, 40, 40); // gris oscuro elegante
        public static Color ColorPrimario = Color.FromArgb(52, 120, 246); // azul moderno profesional
        public static Color ColorBordeSuave = Color.FromArgb(224, 224, 224);
        public static Color ColorCeldas = Color.FromArgb(250, 250, 250);
        public static Color ColorCeldasAlternas = Color.FromArgb(243, 243, 243);
        public static Color ColorCamposNoEditables = Color.FromArgb(255, 217, 217); // rojo muy suave para campos no editables

        // ===== ESTILO MAIN UI =====
        public static void AplicarEstilosFormulario(Form form)
        {
            form.BackColor = FondoPrincipal;
            form.Font = new Font("Segoe UI", 10);

            foreach (Control ctrl in form.Controls)
                AplicarEstiloControl(ctrl);
        }

        // ----- Control general -----
        private static void AplicarEstiloControl(Control ctrl)
        {
            if (ctrl is Label lbl)
            {
                lbl.ForeColor = ColorTexto;
                lbl.Font = new Font("Segoe UI", lbl.Font.Size, FontStyle.Regular);
            }
            else if (ctrl is TextBox txt)
            {
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.BackColor = FondoTarjetas;
                txt.ForeColor = ColorTexto;
                txt.Font = new Font("Segoe UI", 10);
            }
            else if (ctrl is Button btn)
            {
                AplicarEstiloBoton(btn);
            }
            else if (ctrl is DataGridView dgv)
            {
                AplicarEstiloDataGrid(dgv);
            }
            else
            {
                ctrl.BackColor = Color.FromArgb(245, 246, 248);
                ctrl.ForeColor = ColorTexto;
            }

            foreach (Control hijo in ctrl.Controls)
                AplicarEstiloControl(hijo);
        }

        // ----- Botones minimalistas -----
        private static void AplicarEstiloBoton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

            btn.BackColor = ColorPrimario;
            btn.ForeColor = Color.White;

            btn.Font = new Font("Segoe UI Semibold", 10);
            btn.Cursor = Cursors.Hand;

            // Simulación de borde redondeado al estilo Win11
            btn.Paint += (s, e) =>
            {
                var rect = btn.ClientRectangle;
                rect.Inflate(-1, -1);
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (var pen = new Pen(Color.Transparent, 1))
                    e.Graphics.DrawRectangle(pen, rect);
            };
        }

        // ----- ESTILO PROFESIONAL DEL DATAGRID -----
        public static void AplicarEstiloDataGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = FondoPrincipal;
            dgv.BorderStyle = BorderStyle.None;

            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = ColorBordeSuave;

            dgv.EnableHeadersVisualStyles = false;

            // ENCABEZADOS
            dgv.ColumnHeadersDefaultCellStyle.BackColor = FondoTarjetas;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorTexto;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10);
            dgv.ColumnHeadersHeight = 38;

            // FILAS
            dgv.RowsDefaultCellStyle.BackColor = ColorCeldas;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorCeldasAlternas;
            dgv.DefaultCellStyle.ForeColor = ColorTexto;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            dgv.DefaultCellStyle.SelectionBackColor = ColorPrimario;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            // OTROS
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 32;
        }

        // ----- BLOQUEAR FORMULARIO (NO EDITABLE) -----
        public static void AplicarEstilosNoEditable(Form form)
        {
            // Llamar a la versión recursiva empezando por el form
            AplicarEstilosNoEditableControl(form);
        }

        private static void AplicarEstilosNoEditableControl(Control padre)
        {
            foreach (Control ctrl in padre.Controls)
            {
                // Botones: desactivar todos excepto el botón que activa la edición
                if (ctrl is Button boton)
                {
                    if (!string.Equals(boton.Name, "buttonActivarEdicion", StringComparison.OrdinalIgnoreCase))
                    {
                        boton.Enabled = false;
                        boton.BackColor = ColorBordeSuave;
                        boton.ForeColor = Color.FromArgb(120, 120, 120);
                        boton.Cursor = Cursors.Default;
                    }
                }
                // TextBox y MaskedTextBox y RichTextBox: marcar como solo lectura y ajustar estilo
                else if (ctrl is TextBox texto)
                {
                    texto.ReadOnly = true;
                    texto.BackColor = ColorCamposNoEditables;
                }
                else if (ctrl is MaskedTextBox masked)
                {
                    masked.ReadOnly = true;
                    masked.BackColor = ColorCamposNoEditables;
                }
                else if (ctrl is RichTextBox rtb)
                {
                    rtb.ReadOnly = true;
                    rtb.BackColor = ColorCamposNoEditables;
                }
                // Controles que no tienen ReadOnly: desactivar
                else if (ctrl is ComboBox || ctrl is DateTimePicker || ctrl is NumericUpDown || ctrl is CheckBox || ctrl is RadioButton)
                {
                    ctrl.Enabled = false;
                }
                // Recurse dentro de contenedores (Panel, GroupBox, TabPage, etc.)
                if (ctrl.HasChildren)
                    AplicarEstilosNoEditableControl(ctrl);
            }
        }

        // ----- HABILITAR FORMULARIO (EDITABLE) -----
        public static void AplicarEstilosEditable(Form formulario)
        {
            // Aplicar estilos base primero para asegurar fuentes/colores consistentes
            AplicarEstilosFormulario(formulario);

            // Luego habilitar controles recursivamente y restaurar apariencia editable
            AplicarEstilosEditableControl(formulario);
        }

        private static void AplicarEstilosEditableControl(Control padre)
        {
            foreach (Control ctrl in padre.Controls)
            {
                if (ctrl is Button boton)
                {
                    // Mantener siempre habilitado el control que activa/desactiva edición
                    if (string.Equals(boton.Name, "buttonActivarEdicion", StringComparison.OrdinalIgnoreCase))
                    {
                        boton.Enabled = true;
                    }
                    else
                    {
                        boton.Enabled = true;
                        boton.BackColor = ColorPrimario;
                        boton.ForeColor = Color.White;
                        boton.Cursor = Cursors.Hand;
                    }
                }
                else if (ctrl is TextBox texto)
                {
                    texto.ReadOnly = false;
                    texto.BackColor = FondoTarjetas;
                }
                else if (ctrl is MaskedTextBox masked)
                {
                    masked.ReadOnly = false;
                    masked.BackColor = FondoTarjetas;
                }
                else if (ctrl is RichTextBox rtb)
                {
                    rtb.ReadOnly = false;
                    rtb.BackColor = FondoTarjetas;
                }
                else if (ctrl is ComboBox || ctrl is DateTimePicker || ctrl is NumericUpDown || ctrl is CheckBox || ctrl is RadioButton)
                {
                    ctrl.Enabled = true;
                }

                if (ctrl.HasChildren)
                    AplicarEstilosEditableControl(ctrl);
            }
        }
    }
}