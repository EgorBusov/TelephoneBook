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
using System.Windows.Shapes;
using TelephoneBookWPF.StaticComponents;

namespace TelephoneBookWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindowDemo.xaml
    /// </summary>
    public partial class MainWindowDemo : Window
    {
        public MainWindowDemo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Заполнение listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MWindowDemo_Loaded(object sender, RoutedEventArgs e)
        {
            listViewPersones.ItemsSource = await User._apiRequests.GetPersones();
        }
        /// <summary>
        /// Окно авторизации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            AuthorizeWindow authorize = new AuthorizeWindow();
            authorize.Show();
            Close();
        }
    }
}
