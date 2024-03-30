using System.Data.SqlClient;
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

namespace Lab03_Islachin
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
        public class Student
        {
            public int StudentID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
        private string connectionString = "Data Source=LAB1504-10\\SQLEXPRESS; Initial Catalog=Lab03LI; User Id=Luis; Password=123456";
          
        

        private void Button_datatble(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Student", connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                tabla.ItemsSource = dataTable.DefaultView;

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar clientes: " + ex.Message);
            }


        }

        private void Button_datareader(object sender, RoutedEventArgs e)
        {

        }

        private void Button_buscar(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_nombre(object sender, TextChangedEventArgs e)
        {

        }
    }
    

}



