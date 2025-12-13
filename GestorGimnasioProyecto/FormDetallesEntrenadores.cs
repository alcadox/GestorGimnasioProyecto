using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GestorGimnasioProyecto
{
    public partial class FormDetallesEntrenadores : Form
    {
        private DataGridViewRow filaRef;
        string conexionString = ConfigurationManager.ConnectionStrings["conexionBaseDatos"].ConnectionString;
        DataTable dtClientes = new DataTable();
        bool edicionActivada = false;

        public FormDetallesEntrenadores(ref DataGridViewRow filaTraida)
        {
            InitializeComponent();
            filaRef = filaTraida;
            rellenarCampos();
            Estilos.AplicarEstilosFormulario(this);
            Estilos.AplicarEstilosNoEditable(this);
            labelAvisoEntrenador.ForeColor = Color.Red;
        }

        private void rellenarCampos()
        {
            labelEntrenadorTitulo.Text = "Entrenador " + filaRef.Cells["nombre"].Value.ToString() + " " + filaRef.Cells["apellidos"].Value.ToString();
            LabelIdEntrenador.Text = "ID: " + filaRef.Cells["id"].Value.ToString();

            textBoxDNIEntrenador.Text = filaRef.Cells["dni"].Value.ToString();
            textBoxNombreEntrenador.Text = filaRef.Cells["nombre"].Value.ToString();
            textBoxApellidosEntrenador.Text = filaRef.Cells["apellidos"].Value.ToString();
            textBoxFechaNacimientoEntrenador.Text = filaRef.Cells["fecha_nacimiento"].Value.ToString();

            textBoxFechaInicioEntrenador.Text = filaRef.Cells["fecha_inicio"].Value.ToString();
            textBoxFechaFinEntrenador.Text = filaRef.Cells["fecha_fin"].Value.ToString();
            comboBoxTipoPago.Text = filaRef.Cells["tipo_pago"].Value.ToString();

            textBoxEspecialidadEntrenador.Text = filaRef.Cells["especialidad"].Value.ToString();
            textBoxNotasEntrenador.Text = filaRef.Cells["notas"].Value.ToString();

            textBoxTelefonoEntrenador.Text = filaRef.Cells["telefono"].Value.ToString();
            textBoxEmailEntrenador.Text = filaRef.Cells["email"].Value.ToString();

            checkBoxEntrenadorActivo.Checked = Convert.ToBoolean(filaRef.Cells["alta"].Value);
            solicitarDatosEntrenador();
        }

        private void solicitarDatosEntrenador()
        {
            try
            {
                dtClientes.Clear();

                string sql = "SELECT id, nombre, apellidos FROM clients WHERE trainer_id = @trainerId";

                using (var conexion = new MySqlConnection(conexionString))
                using (var comando = new MySqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@trainerId", Convert.ToInt32(filaRef.Cells["id"].Value));
                    conexion.Open();

                    using (var adapter = new MySqlDataAdapter(comando))
                    {
                        adapter.Fill(dtClientes);
                    }

                    dataGridViewClientesDelEntrenador.DataSource = dtClientes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error conexión BD: " + ex.Message);
            }
        }

        private void buttonActivarEdicion_Click(object sender, EventArgs e)
        {
            if (!edicionActivada)
            {
                Estilos.AplicarEstilosEditable(this);
                labelAvisoEntrenador.Visible = false;
                edicionActivada = true;
                buttonActivarEdicion.Text = "Desactivar edición";

                textBoxFechaInicioEntrenador.ReadOnly = true;
                textBoxFechaFinEntrenador.ReadOnly = true;
                textBoxFechaFinEntrenador.BackColor = Estilos.ColorCamposNoEditables;
                textBoxFechaInicioEntrenador.BackColor = Estilos.ColorCamposNoEditables;
                comboBoxTipoPago.Enabled = false;
            }
            else
            {
                Estilos.AplicarEstilosNoEditable(this);
                labelAvisoEntrenador.Visible = true;
                edicionActivada = false;
                buttonActivarEdicion.Text = "Activar edición";
                labelAvisoEntrenador.ForeColor = Color.Red;
            }
        }

        private void buttonRenovar_Click(object sender, EventArgs e)
        {
            FormularioRenovarEntrenadores formularioRenovar = new FormularioRenovarEntrenadores(
                filaRef.Cells["nombre"].Value.ToString(),
                filaRef.Cells["apellidos"].Value.ToString(),
                filaRef.Cells["id"].Value.ToString()
            );

            formularioRenovar.RenovacionExitosa += (s, args) =>
            {
                try
                {
                    if (this.InvokeRequired)
                        this.Invoke(new Action(() => this.Close()));
                    else
                        this.Close();

                    foreach (Form f in Application.OpenForms)
                    {
                        if (f is FormularioPrincipal principal)
                        {
                            try
                            {
                                principal.RefrescarDatos();
                            }
                            catch
                            {
                            }

                            break;
                        }
                    }
                }
                catch
                {
                }
            };

            formularioRenovar.Show();
        }
    }
}
