using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GestorGimnasioProyecto
{
    public partial class FormularioPrincipal : Form
    {
        string conexionString = ConfigurationManager.ConnectionStrings["conexionBaseDatos"].ConnectionString;
        string sqlClientes = "SELECT * from clients";
        string sqlEntrenadores = "SELECT * from trainers";

        DataTable dtClientes = new DataTable();
        DataTable dtEntrenadores = new DataTable();

        public FormularioPrincipal(string nombreUsuario)
        {
            InitializeComponent();
            conectarBaseDatos(); 
            Estilos.AplicarEstilosFormulario(this);
            Estilos.AplicarEstiloDataGrid(dataGridViewTablaClientes);
            buttonPerfilClientes.Text = "Bienvenido, " + nombreUsuario;

        }

        private void conectarBaseDatos()
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(conexionString);
                conexion.Open();

                MySqlCommand comandoClientes = new MySqlCommand(sqlClientes, conexion);

                MySqlDataReader readerClientes = comandoClientes.ExecuteReader();

                dtClientes.Load(readerClientes);

                dataGridViewTablaClientes.DataSource = dtClientes;

                dataGridViewTablaClientes.DataSource = dtClientes;

                ocultarColcumnasInnecesarias();

                ordenarColumnas();

                comandoClientes.Dispose();

                MySqlCommand comandoEntrenadores = new MySqlCommand(sqlEntrenadores, conexion);

                MySqlDataReader readerEntrenadores = comandoEntrenadores.ExecuteReader();

                dtEntrenadores.Load(readerEntrenadores);

                dataGridViewEntrenadores.DataSource = dtEntrenadores;

                comandoEntrenadores.Dispose();

                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error conexión BD: " + ex.Message);
            }
        }

        private void ocultarColcumnasInnecesarias()
        {
            // Ocultamos las columnas que NO queremos mostrar
            dataGridViewTablaClientes.Columns["dni"].Visible = false;
            dataGridViewTablaClientes.Columns["fecha_nacimiento"].Visible = false;
            dataGridViewTablaClientes.Columns["objetivo"].Visible = false;
            dataGridViewTablaClientes.Columns["altura"].Visible = false;
            dataGridViewTablaClientes.Columns["peso"].Visible = false;
            dataGridViewTablaClientes.Columns["telefono"].Visible = false;
            dataGridViewTablaClientes.Columns["email"].Visible = false;
            dataGridViewTablaClientes.Columns["tipo_pago"].Visible = false;
            dataGridViewTablaClientes.Columns["trainer_id"].Visible = false;
        }

        private void ordenarColumnas()
        {
            dataGridViewTablaClientes.Columns["id"].DisplayIndex = 0;
            dataGridViewTablaClientes.Columns["nombre"].DisplayIndex = 1;
            dataGridViewTablaClientes.Columns["apellidos"].DisplayIndex = 2;
            dataGridViewTablaClientes.Columns["fecha_inicio"].DisplayIndex = 3;
            dataGridViewTablaClientes.Columns["fecha_fin"].DisplayIndex = 4;
            dataGridViewTablaClientes.Columns["alta"].DisplayIndex = 5;
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBoxCamposCliente.Text))
            {
                dtClientes.DefaultView.RowFilter = "";
                return;
            }
            realizarBusqueda(ref dtClientes, comboBoxCamposCliente.Text, textBoxBuscarCliente.Text.Replace("'", "''"));
        }

        private void comboBoxCampos_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxBuscarCliente.Text))
            {
                dtClientes.DefaultView.RowFilter = "";
                return;
            }
            realizarBusqueda(ref dtClientes, comboBoxCamposCliente.Text, textBoxBuscarCliente.Text.Replace("'", "''"));
        }

        private void realizarBusqueda(ref DataTable dt, string columna, string valor)
        {
            try
            {
                dt.DefaultView.RowFilter =
                    $"CONVERT([{columna}], 'System.String') LIKE '%{valor}%'";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar: " + ex.Message);
            }
        }

        private void textBoxBuscarEntrenadores_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBoxBuscarCampoEntrenadores.Text))
            {
                dtEntrenadores.DefaultView.RowFilter = "";
                return;
            }
            realizarBusqueda(ref dtEntrenadores, comboBoxBuscarCampoEntrenadores.Text, textBoxBuscarEntrenadores.Text.Replace("'", "''"));
        }

        private void comboBoxBuscarCampoEntrenadores_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxBuscarEntrenadores.Text))
            {
                dtEntrenadores.DefaultView.RowFilter = "";
                return;
            }
            realizarBusqueda(ref dtEntrenadores, comboBoxBuscarCampoEntrenadores.Text, textBoxBuscarEntrenadores.Text.Replace("'", "''"));
        }

        private void dataGridViewTablaClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridViewTablaClientes.Rows[e.RowIndex].IsNewRow) return;

            DataGridViewRow filaSeleccionada = dataGridViewTablaClientes.Rows[e.RowIndex];
            Formulario3DetallesClientes formularioDetalles = new Formulario3DetallesClientes(ref filaSeleccionada);
            formularioDetalles.Show();

        }
    }
}
