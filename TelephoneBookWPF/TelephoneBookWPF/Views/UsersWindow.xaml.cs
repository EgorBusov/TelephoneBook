using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TelephoneBookWPF.Models;
using TelephoneBookWPF.StaticComponents;

namespace TelephoneBookWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для UsersWindow.xaml
    /// </summary>
    public partial class UsersWindow : Window
    {
        public UsersWindow()
        {
            InitializeComponent();           
        }

        private async void menuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            UserModel userModel = (UserModel)listViewUsers.SelectedItem;
            if (userModel != null) { return; }
            try
            {
                await User._apiRequests.DeleteUser(userModel.Username, User._tokenResponse.token);
            }
            catch (HttpResponseException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.Unauthorized) { error.Content = "Авторизуйтесь"; }
                else if (ex.Response.StatusCode == HttpStatusCode.Forbidden) { error.Content = "К сожалению у вас нет доступа"; }
                else if (ex.Response.StatusCode == HttpStatusCode.NotFound) { error.Content = "Пользователь не найдет"; }
                else
                {
                    error.Content = ex.Message;
                }
            }
        }

        private async void UWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                listViewUsers.ItemsSource = await User._apiRequests.GetUsers(User._tokenResponse.token);
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

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
