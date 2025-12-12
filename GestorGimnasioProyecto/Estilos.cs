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
    }
}
