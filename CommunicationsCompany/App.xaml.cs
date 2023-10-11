using CommunicationsCompany.ADOApp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CommunicationsCompany
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static CommunicationsСompanyEntities Connection = new CommunicationsСompanyEntities();
        public static User currentUser;
    }
}
