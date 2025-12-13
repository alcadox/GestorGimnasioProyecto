using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GestorGimnasioProyecto
{
    public partial class FormularioRenovarEntrenadores : Form
    {
        private readonly string entrenadorId;
        private readonly string conexionString = ConfigurationManager.ConnectionStrings["conexionBaseDatos"].ConnectionString;
        public event EventHandler RenovacionExitosa;

        public FormularioRenovarEntrenadores(string nombrePersona, string apellidosPersona, string idPersona)
        {
            InitializeComponent();
            Estilos.AplicarEstilosFormulario(this);
            labelConfirmacion.Text = "¿Confirma la renovación a " + nombrePersona + " " + apellidosPersona + " ?";
            Estilos.AplicarEstiloBotonesRenovar(this);

            this.entrenadorId = idPersona;

            try
            {
                if (comboBoxTipoPago != null)
                {
                    comboBoxTipoPago.DropDownStyle = ComboBoxStyle.DropDownList;

                    if (comboBoxTipoPago.Items.Count == 0)
                        comboBoxTipoPago.Items.AddRange(new object[] { "SEMANAL", "MENSUAL", "ANUAL" });

                    comboBoxTipoPago.SelectedIndexChanged -= ComboBoxTipoPago_SelectedIndexChanged;
                    comboBoxTipoPago.SelectedIndexChanged += ComboBoxTipoPago_SelectedIndexChanged;
                }

                if (dateTimePickerFechaInicio != null)
                {
                    dateTimePickerFechaInicio.Format = DateTimePickerFormat.Custom;
                    dateTimePickerFechaInicio.CustomFormat = "yyyy-MM-dd";
                    dateTimePickerFechaInicio.ValueChanged -= DateTimePickerFechaInicio_ValueChanged;
                    dateTimePickerFechaInicio.ValueChanged += DateTimePickerFechaInicio_ValueChanged;
                }

                if (dateTimePickerFechaFin != null)
                {
                    dateTimePickerFechaFin.Format = DateTimePickerFormat.Custom;
                    dateTimePickerFechaFin.CustomFormat = "yyyy-MM-dd";
                    dateTimePickerFechaFin.Enabled = false;
                }

                if (labelAviso != null)
                {
                    labelAviso.Visible = false;
                    labelAviso.ForeColor = Color.Red;
                }
            }
            catch
            {
            }
        }

        private void DateTimePickerFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            CalcularFechaFin();
        }

        private void ComboBoxTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularFechaFin();
        }

        private void CalcularFechaFin()
        {
            try
            {
                if (dateTimePickerFechaInicio == null || dateTimePickerFechaFin == null || comboBoxTipoPago == null) return;

                var tipo = (comboBoxTipoPago.SelectedItem ?? comboBoxTipoPago.Text)?.ToString().Trim().ToUpperInvariant();
                if (string.IsNullOrWhiteSpace(tipo)) return;

                DateTime inicio = dateTimePickerFechaInicio.Value.Date;
                DateTime fin;

                switch (tipo)
                {
                    case "SEMANAL":
                        fin = inicio.AddDays(7);
                        break;
                    case "MENSUAL":
                        fin = inicio.AddMonths(1);
                        break;
                    case "ANUAL":
                    case "ANUALIDAD":
                        fin = inicio.AddYears(1);
                        break;
                    default:
                        return;
                }

                dateTimePickerFechaFin.Value = fin;
            }
            catch
            {
            }
        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFechaInicio == null || comboBoxTipoPago == null || dateTimePickerFechaFin == null)
            {
                MessageBox.Show("Controles de fecha/tipo no disponibles en este formulario.");
                return;
            }

            if (string.IsNullOrWhiteSpace(comboBoxTipoPago.Text))
            {
                if (labelAviso != null)
                {
                    labelAviso.Text = "Selecciona un tipo de pago válido.";
                    labelAviso.Visible = true;
                }
                return;
            }

            DateTime inicio = dateTimePickerFechaInicio.Value.Date;
            DateTime fin = dateTimePickerFechaFin.Value.Date;

            if (inicio == DateTime.MinValue)
            {
                if (labelAviso != null)
                {
                    labelAviso.Text = "La fecha inicio no puede estar vacía.";
                    labelAviso.Visible = true;
                }
                return;
            }

            try
            {
                using (var conexion = new MySqlConnection(conexionString))
                {
                    conexion.Open();

                    string sql = "UPDATE trainers SET tipo_pago = @tipoPago, fecha_inicio = @fechaInicio, fecha_fin = @fechaFin WHERE id = @id";
                    using (var cmd = new MySqlCommand(sql, conexion))
                    {
                        cmd.Parameters.AddWithValue("@tipoPago", comboBoxTipoPago.Text.Trim());
                        cmd.Parameters.AddWithValue("@fechaInicio", inicio.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@fechaFin", fin.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(entrenadorId));

                        int afectadas = cmd.ExecuteNonQuery();
                        if (afectadas > 0)
                        {
                            RenovacionExitosa?.Invoke(this, EventArgs.Empty);

                            MessageBox.Show("Renovación aplicada correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("No se ha actualizado ningún registro. Comprueba el ID.");
                        }
                    }

                    conexion.Close();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar BD: " + ex.Message);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
