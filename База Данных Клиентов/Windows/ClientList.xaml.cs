using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;

namespace База_Данных_Клиентов.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientList.xaml
    /// </summary>
    public partial class ClientList : Window
    {
        private ObservableCollection<Clients> items = new ObservableCollection<Clients>();

        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bengo\source\repos\Clientdb\База Данных Клиентов\Clientsdb.mdf;Integrated Security=True");

        public ClientList()
        {
            InitializeComponent();

            UpdateList();
        }

        private void UpdateList()
        {
            connection.Open();

            string read = "SELECT * FROM Client";
            SqlCommand command = new SqlCommand(read, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                string name = reader["Name"].ToString();
                string lastname = reader["LastName"].ToString();
                string phone = reader["Phone"].ToString();
                string address = reader["Address"].ToString();

                items.Add(new Clients() { Id = id, Name = name, LastName = lastname, Phone = phone, Address = address });
            }

            LVClient.ItemsSource = items;

            reader.Close();

            connection.Close();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var selected = (Clients)LVClient.SelectedItem;

            if (selected != null)
            {
                connection.Open();

                string delete = "DELETE Client WHERE Id = @id";
                SqlCommand command = new SqlCommand(delete, connection);
                command.Parameters.AddWithValue("@id", selected.Id);
                command.ExecuteNonQuery();

                connection.Close();
            }

            items.Clear();

            UpdateList();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }

        private void ButtonInfo_Click(object sender, RoutedEventArgs e)
        {
            var selected = (Clients)LVClient.SelectedItem;
            if (selected != null)
            {
                connection.Open();

                string read = "SELECT * FROM Client WHERE Id = @id";
                SqlCommand command = new SqlCommand(read, connection);

                SqlDataReader reader = command.ExecuteReader();
            }
        }
    }
}
