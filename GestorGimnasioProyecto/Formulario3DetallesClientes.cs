using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GestorGimnasioProyecto
{
    public partial class Formulario3DetallesClientes : Form
    {
        DataGridViewRow filaRef;
        string conexionString = ConfigurationManager.ConnectionStrings["conexionBaseDatos"].ConnectionString;
        bool edicionActivada = false;

        public Formulario3DetallesClientes(ref DataGridViewRow fila)
        {
            InitializeComponent();
            filaRef = fila;
            rellenarCampos();
            Estilos.AplicarEstilosFormulario(this);
            Estilos.AplicarEstilosNoEditable(this);
            labelAvisoCliente.ForeColor = Color.Red;
            comprobarFechaFinCliente();
        }

        private void rellenarCampos()
        {
            labelClienteTitulo.Text = "Cliente " + filaRef.Cells["nombre"].Value.ToString() + " " + filaRef.Cells["apellidos"].Value.ToString();
            labelIdCliente.Text = "ID: " + filaRef.Cells["id"].Value.ToString();

            textBoxDNICliente.Text = filaRef.Cells["dni"].Value.ToString();
            textBoxNombreCliente.Text = filaRef.Cells["nombre"].Value.ToString();
            textBoxApellidosCliente.Text = filaRef.Cells["apellidos"].Value.ToString();
            textBoxFechaNacimientoCliente.Text = filaRef.Cells["fecha_nacimiento"].Value.ToString();

            textBoxFechaInicioCliente.Text = filaRef.Cells["fecha_inicio"].Value.ToString();
            textBoxFechaFinCliente.Text = filaRef.Cells["fecha_fin"].Value.ToString();
            comboBoxTipoPago.Text = filaRef.Cells["tipo_pago"].Value.ToString();

            textBoxObjetivoCliente.Text = filaRef.Cells["objetivo"].Value.ToString();
            textBoxAlturaCliente.Text = filaRef.Cells["altura"].Value.ToString();
            textBoxPesoCliente.Text = filaRef.Cells["peso"].Value.ToString();

            textBoxTelefonoCliente.Text = filaRef.Cells["telefono"].Value.ToString();
            textBoxEmailCliente.Text = filaRef.Cells["email"].Value.ToString();

            checkBoxClienteActivo.Checked = Convert.ToBoolean(filaRef.Cells["alta"].Value);

            textBoxIdEntrenador.Text = filaRef.Cells["trainer_id"].Value.ToString();
            solicitarDatosEntrenador();
        }

        private void solicitarDatosEntrenador()
        {
            try
            {
                string sqlEntrenador = "SELECT id, nombre, apellidos FROM trainers WHERE id = " + Convert.ToInt32(filaRef.Cells["trainer_id"].Value);

                MySqlConnection conexion = new MySqlConnection(conexionString);
                conexion.Open();

                MySqlCommand comandoEntrenador = new MySqlCommand(sqlEntrenador, conexion);
                MySqlDataReader readerEntrenador = comandoEntrenador.ExecuteReader();

                if (readerEntrenador.Read())
                {
                    textBoxNombreEntrenador.Text = readerEntrenador["nombre"].ToString();
                    textBoxApellidosEntrenador.Text = readerEntrenador["apellidos"].ToString();
                }

                comandoEntrenador.Dispose();
                conexion.Close();
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
                labelAvisoCliente.Visible = false;
                edicionActivada = true;
                buttonActivarEdicion.Text = "Desactivar edición";

                textBoxFechaInicioCliente.ReadOnly = true;
                textBoxFechaFinCliente.ReadOnly = true;
                textBoxFechaInicioCliente.BackColor = Estilos.ColorCamposNoEditables;
                textBoxFechaFinCliente.BackColor = Estilos.ColorCamposNoEditables;
                comboBoxTipoPago.Enabled = false;
            }
            else
            {
                Estilos.AplicarEstilosNoEditable(this);
                labelAvisoCliente.Visible = true;
                edicionActivada = false;
                buttonActivarEdicion.Text = "Activar edición";
            }
            comprobarFechaFinCliente();
        }

        private void buttonVerEntrenador_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxIdEntrenador.Text)) return;

            int trainerId;
            if (!int.TryParse(textBoxIdEntrenador.Text, out trainerId)) return;

            DataGridViewRow filaEntrenador = consultarEntrenadorPorId(trainerId);
            if (filaEntrenador == null)
            {
                MessageBox.Show("Entrenador no encontrado.");
                return;
            }

            FormDetallesEntrenadores formularioDetalles = new FormDetallesEntrenadores(ref filaEntrenador);
            formularioDetalles.Show();
        }

        private DataGridViewRow consultarEntrenadorPorId(int entrenadorId)
        {
            try
            {
                var dt = new DataTable();
                string sqlEntrenador = "SELECT * FROM trainers WHERE id = @trainerId";

                using (var conexion = new MySqlConnection(conexionString))
                using (var comando = new MySqlCommand(sqlEntrenador, conexion))
                {
                    comando.Parameters.AddWithValue("@trainerId", entrenadorId);
                    conexion.Open();

                    using (var adapter = new MySqlDataAdapter(comando))
                    {
                        adapter.Fill(dt);
                    }
                }

                if (dt.Rows.Count == 0) return null;

                var tempGrid = new DataGridView();
                foreach (DataColumn c in dt.Columns)
                    tempGrid.Columns.Add(c.ColumnName, c.ColumnName);

                int newIndex = tempGrid.Rows.Add(dt.Rows[0].ItemArray);
                return tempGrid.Rows[newIndex];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error conexión BD: " + ex.Message);
                return null;
            }
        }

        private void comprobarFechaFinCliente()
        {
            DateTime fechaFin;
            if (DateTime.TryParse(textBoxFechaFinCliente.Text, out fechaFin))
            {
                if (fechaFin < DateTime.Now)
                {
                    labelFechaFinCliente.Text = "Fecha Fin (VENCIDO)";
                    labelFechaFinCliente.ForeColor = Color.Red;
                }
                else
                {
                    labelFechaFinCliente.ForeColor = Color.Black;
                    labelFechaFinCliente.Text = "Fecha Fin:";
                }
            }
        }

        private void buttonRenovar_Click(object sender, EventArgs e)
        {
            FormularioRenovar formularioRenovar = new FormularioRenovar(
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
                            principal.RefrescarDatos();
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
