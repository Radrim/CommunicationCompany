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
    /// Interaction logic for AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbLogin.Text) && !String.IsNullOrEmpty(pbPassword.Password))
            {
                var account = App.Connection.Account.FirstOrDefault(x => x.Login == tbLogin.Text && x.Password == pbPassword.Password);

                if (account != null)
                {
                    var user = App.Connection.User.FirstOrDefault(x => x.UserId == account.UserId);
                    App.currentUser = user;

                    switch (user.Role.Title)
                    {
                        case "Manager":
                            NavigationService.Navigate(new ManagerPage());
                            return;

                        case "Marketer":
                            NavigationService.Navigate(new MarketerPage());
                            return;

                        case "Specialist":
                            NavigationService.Navigate(new SpecialistPage());
                            return;

                        case "Client":
                            NavigationService.Navigate(new ClientPage());
                            return;
                    }
                }

                else 
                {
                    MessageBox.Show("Неверный логин или пароль!", "Ошибка!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            else 
            {
                MessageBox.Show("Заполните все поля!", "Ошибка!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
