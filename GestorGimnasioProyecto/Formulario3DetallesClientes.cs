using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Windows.Forms;

namespace GestorGimnasioProyecto
{
    public partial class Formulario3DetallesClientes : Form
    {
        DataGridViewRow filaRef;
        string conexionString = ConfigurationManager.ConnectionStrings["conexionBaseDatos"].ConnectionString;

        public Formulario3DetallesClientes(ref DataGridViewRow fila)
        {
            InitializeComponent();
            filaRef = fila;
            rellenarCampos();
            Estilos.AplicarEstilosFormulario(this);

        }

        private void rellenarCampos()
        {
            labelClienteTitulo.Text = "Cliente " + filaRef.Cells["nombre"].Value.ToString() + " " + filaRef.Cells["apellidos"].Value.ToString();
            textBoxIdCliente.Text = filaRef.Cells["id"].Value.ToString();

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
    }
}
