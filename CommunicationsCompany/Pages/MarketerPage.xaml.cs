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
    /// Interaction logic for MarketerPage.xaml
    /// </summary>
    public partial class MarketerPage : Page
    {
        private Tariff _tariff = new Tariff();

        public MarketerPage()
        {
            InitializeComponent();
            lvTariffs.ItemsSource = App.Connection.Tariff.ToList();
        }

        private void CreateTariff(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbTitle.Text) && dpStartDate.SelectedDate != DateTime.MinValue && dpFinalDate.SelectedDate != DateTime.MinValue 
                && !String.IsNullOrEmpty(tbCost.Text) && !String.IsNullOrEmpty(tbCountGB.Text) 
                && !String.IsNullOrEmpty(tbCountMessages.Text) && !String.IsNullOrEmpty(tbCountMinutes.Text))
            {
                if (dpFinalDate.SelectedDate <= dpStartDate.SelectedDate || dpFinalDate.SelectedDate <= DateTime.Today)
                {
                    MessageBox.Show("Некорректно введены даты!", "Ошибка!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!(int.TryParse(tbCost.Text, out int num1) && num1 > 0 && int.TryParse(tbCountGB.Text, out int num2) && num2 > 0
                    && int.TryParse(tbCountMinutes.Text, out int num3) && num3 > 0 && int.TryParse(tbCountMessages.Text, out int num4) && num4 > 0))
                {
                    MessageBox.Show("Некорректно введены числовые значения!", "Ошибка!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                App.Connection.Tariff.Add(_tariff);
                App.Connection.SaveChanges();
                MessageBox.Show("Тариф создан!", "Успех!",
                       MessageBoxButton.OK, MessageBoxImage.Information);
                _tariff = new Tariff();
                DataContext = _tariff;
                return;
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Ошибка!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
    }
}
