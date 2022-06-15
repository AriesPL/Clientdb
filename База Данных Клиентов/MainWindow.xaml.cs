using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace База_Данных_Клиентов
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonNewClient_Click(object sender, RoutedEventArgs e)
        {
            Windows.newClient newClient = new Windows.newClient();
            newClient.Show();
            Hide();
        }

        private void Buttonlist_Click(object sender, RoutedEventArgs e)
        {
            Windows.ClientList clientList = new Windows.ClientList();
            clientList.Show();
            Hide();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
