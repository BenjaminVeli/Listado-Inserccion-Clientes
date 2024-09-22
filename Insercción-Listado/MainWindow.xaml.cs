using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Insercción_Listado
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListadoClientes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "Data Source=DESKTOP-RTEGT07\\SQLEXPRESSB;Database=Neptuno;User ID=userTecsup;Password=123456; TrustServerCertificate=True;";
                SqlConnection connection = new SqlConnection(cadena);

                connection.Open();

                SqlCommand command = new SqlCommand("ListarClientes", connection);
                command.CommandType = CommandType.StoredProcedure;


                List<Cliente> listaClientes = new List<Cliente>();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    Cliente cliente = new Cliente();
                    cliente.IdCliente = reader["idCliente"].ToString();
                    cliente.NombreCompañia = reader["NombreCompañia"].ToString();
                    cliente.NombreContacto = reader["NombreContacto"].ToString();
                    cliente.CargoContacto = reader["CargoContacto"].ToString();
                    cliente.Direccion = reader["Direccion"].ToString();
                    cliente.Ciudad = reader["Ciudad"].ToString();
                    cliente.Region = reader["Region"].ToString();
                    cliente.CodPostal = reader["CodPostal"].ToString();
                    cliente.Pais = reader["Pais"].ToString();
                    cliente.Telefono = reader["Telefono"].ToString();
                    cliente.Fax = reader["Fax"].ToString();
                    listaClientes.Add(cliente);

                }
                connection.Close();

                dgvClientes.ItemsSource = listaClientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de Conexión: {ex.Message}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "Data Source=DESKTOP-RTEGT07\\SQLEXPRESSB;Database=Neptuno;User ID=userTecsup;Password=123456; TrustServerCertificate=True;";
                SqlConnection connection = new SqlConnection(cadena);

                connection.Open();

                SqlCommand command = new SqlCommand("InsertarClientes", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameter1 = new SqlParameter("@idCliente", SqlDbType.VarChar, 5);
                sqlParameter1.Value = txtIdCliente.Text;

                SqlParameter sqlParameter2 = new SqlParameter("@NombreCompañia", SqlDbType.VarChar, 100);
                sqlParameter2.Value = txtNombreCompañia.Text;

                SqlParameter sqlParameter3 = new SqlParameter("@NombreContacto", SqlDbType.VarChar, 100);
                sqlParameter3.Value = txtNombreContacto.Text;

                SqlParameter sqlParameter4 = new SqlParameter("@CargoContacto", SqlDbType.VarChar, 100);
                sqlParameter4.Value = txtCargoContacto.Text;

                SqlParameter sqlParameter5 = new SqlParameter("@Direccion", SqlDbType.VarChar, 100);
                sqlParameter5.Value = txtDireccion.Text;

                SqlParameter sqlParameter6 = new SqlParameter("@Ciudad", SqlDbType.VarChar, 100);
                sqlParameter6.Value = txtCiudad.Text;

                SqlParameter sqlParameter7 = new SqlParameter("@Region", SqlDbType.VarChar, 100);
                sqlParameter7.Value = txtRegion.Text;

                SqlParameter sqlParameter8 = new SqlParameter("@CodPostal", SqlDbType.VarChar, 100);
                sqlParameter8.Value = txtCodPostal.Text;

                SqlParameter sqlParameter9 = new SqlParameter("@Pais", SqlDbType.VarChar, 100);
                sqlParameter9.Value = txtPais.Text;

                SqlParameter sqlParameter10 = new SqlParameter("@Telefono", SqlDbType.VarChar, 100);
                sqlParameter10.Value = txtTelefono.Text;

                SqlParameter sqlParameter11 = new SqlParameter("@Fax", SqlDbType.VarChar, 100);
                sqlParameter11.Value = txtFax.Text;

                command.Parameters.Add(sqlParameter1);
                command.Parameters.Add(sqlParameter2);
                command.Parameters.Add(sqlParameter3);
                command.Parameters.Add(sqlParameter4);
                command.Parameters.Add(sqlParameter5);
                command.Parameters.Add(sqlParameter6);
                command.Parameters.Add(sqlParameter7);
                command.Parameters.Add(sqlParameter8);
                command.Parameters.Add(sqlParameter9);
                command.Parameters.Add(sqlParameter10);
                command.Parameters.Add(sqlParameter11);

                command.ExecuteNonQuery();

                connection.Close();
                MessageBox.Show("Registro Exitoso");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de Conexión: {ex.Message}");
            }
        }
    }
}