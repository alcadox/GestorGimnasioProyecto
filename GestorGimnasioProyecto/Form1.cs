using System;
using System.Configuration;
using System.Windows.Forms;

namespace GestorGimnasioProyecto
{
    public partial class FormularioInicioSesion : Form
    {
        string conexion = ConfigurationManager.ConnectionStrings["conexionBaseDatos"].ConnectionString;

        public FormularioInicioSesion()
        {
            InitializeComponent();
            Estilos.AplicarEstilosFormulario(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = textBoxUsuario.Text;
            string contrasena = textBoxPassword.Text;
            bool credencialesValidas = VerificarCredenciales(usuario, contrasena);
            if (credencialesValidas)
            {
                FormularioPrincipal formularioPrincipal = new FormularioPrincipal(usuario);
                formularioPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }

        private bool VerificarCredenciales(string usuario, string contrasena)
        {
            bool valido = false;

            try
            {
                using (var conexionDB = new MySql.Data.MySqlClient.MySqlConnection(conexion))
                {
                    conexionDB.Open();

                    string query = "SELECT COUNT(*) FROM auth_users WHERE username = @u AND password = @p AND alta = 1";

                    using (MySql.Data.MySqlClient.MySqlCommand cmd =
                           new MySql.Data.MySqlClient.MySqlCommand(query, conexionDB))
                    {
                        cmd.Parameters.AddWithValue("@u", usuario);
                        cmd.Parameters.AddWithValue("@p", contrasena);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        valido = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error conexión BD: " + ex.Message);
            }

            return valido;
        }
    }
}
