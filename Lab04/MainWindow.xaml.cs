using System.Data;
using System.Data.SqlClient;
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

namespace Lab04
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

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=LAB1504-01\\SQLEXPRESS;Initial Catalog=NeptunoDB;User Id = user01;Password=123456";
            
            List<Producto> productos = new List<Producto>();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("USP_ListarProductos", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int idproducto = reader.GetInt32("idproducto");
                    string nombreProducto = reader.GetString("nombreProducto");
                    productos.Add(new Producto {idproducto=idproducto, nombreProducto=nombreProducto });
                }

                dataGrid1.ItemsSource = productos;

                connection.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}