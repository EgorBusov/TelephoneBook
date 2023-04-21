using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TelephoneBookWPF.ApiInteraction;
using TelephoneBookWPF.Models;
using TelephoneBookWPF.StaticComponents;
using TelephoneBookWPF.Views;

namespace TelephoneBookWPF
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
        /// <summary>
        /// При инициализации окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LoadedMWindow(object sender, RoutedEventArgs e)
        {
            listViewPersones.ItemsSource =  await User._apiRequests.GetPersones();
        }
        /// <summary>
        /// Добавление
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow add = new AddWindow();
            add.Show();
        }
        /// <summary>
        /// Выход
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            User._tokenResponse = null;
            User._userModel = null;
            AuthorizeWindow authorizeWindow = new AuthorizeWindow();
            authorizeWindow.Show();
            Close();
        }
        /// <summary>
        /// Редактирование
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemEdit_Click(object sender, RoutedEventArgs e)
        {
            Persone persone = (Persone)listViewPersones.SelectedItem;
            if (persone == null) { return; }
            EditWindow editWindow = new EditWindow(persone);
            editWindow.Show();
        }
        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void menuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Persone persone = (Persone)listViewPersones.SelectedItem;
                if (persone == null) { return; }
                await User._apiRequests.PersoneDelete(persone.Id, User._tokenResponse.token);
            }
            catch (HttpResponseException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.Unauthorized) { error.Content = "Авторизуйтесь"; }
                else if (ex.Response.StatusCode == HttpStatusCode.Forbidden) { error.Content = "К сожалению у вас нет доступа"; }
                else
                {
                    error.Content = ex.Message;
                }
            }
        }
        /// <summary>
        /// Обновление
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void updateButton_Click(object sender, RoutedEventArgs e)
        {
            listViewPersones.ItemsSource = await User._apiRequests.GetPersones();
        }
        /// <summary>
        /// Список пользователей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void usersButton_Click(object sender, RoutedEventArgs e)
        {
            UsersWindow usersWindow = new UsersWindow();
            usersWindow.Show();
        }
    }
}
