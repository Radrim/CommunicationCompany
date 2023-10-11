using CommunicationsCompany.ADOApp;
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

namespace CommunicationsCompany.Pages
{
    /// <summary>
    /// Interaction logic for ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public ClientPage()
        {
            InitializeComponent();
            lvTariffs.ItemsSource = App.Connection.Tariff.ToList();
        }

        private void GoToApprovedTariffs_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientTariffsPage());
        }

        private void GoToOrderPage(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ClientOrderPage());
        }
    }
}
