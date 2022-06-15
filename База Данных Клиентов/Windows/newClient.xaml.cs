using System.Data.SqlClient;
using System.Windows;

namespace База_Данных_Клиентов.Windows
{

    /// <summary>
    /// Логика взаимодействия для newClient.xaml
    /// </summary>
    public partial class newClient : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bengo\source\repos\Clientdb\База Данных Клиентов\Clientsdb.mdf;Integrated Security=True");

        public newClient()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Добавить клиента?", "Внести в базу", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (txtName.Text != "" && txtLastName.Text != "" && txtPhone.Text != "")
                    {
                        connection.Open();
                        string insert = "INSERT INTO Client (Name, LastName, Phone, Address) VALUES (@name, @lastname, @phone, @address)";
                        SqlCommand command = new SqlCommand(insert, connection);
                        command.Parameters.AddWithValue("name", txtName.Text);
                        command.Parameters.AddWithValue("lastname", txtLastName.Text);
                        command.Parameters.AddWithValue("phone", txtPhone.Text);
                        command.Parameters.AddWithValue("address", txtAddress.Text);
                        command.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Клиент добавлен");

                        ClearTextbBox();
                    }

                    else
                    {
                        MessageBox.Show("Нехватает данных");
                    }
                    break;

                case MessageBoxResult.No:
                    ClearTextbBox();
                    break;
            }
        }

        private void ClearTextbBox()
        {
            txtName.Clear();
            txtLastName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
