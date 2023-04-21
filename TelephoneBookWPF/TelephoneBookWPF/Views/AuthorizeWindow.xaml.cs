using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
using TelephoneBookWPF.ApiInteraction;
using TelephoneBookWPF.Models;
using TelephoneBookWPF.StaticComponents;

namespace TelephoneBookWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthorizeWindow.xaml
    /// </summary>
    public partial class AuthorizeWindow : Window
    {
        public AuthorizeWindow()
        {
            User._apiRequests = new ApiRequests(new HttpClient(), Paths.baseUrl);
            InitializeComponent();
        }
        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void authorizationButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textLogin.Text == String.Empty || textPassword.Text == String.Empty) { error.Content = "заполните все поля"; return; }
                UserModel userModel = new UserModel() { Username = textLogin.Text, Password = textPassword.Text };
                TokenResponse token = await User._apiRequests.LoginRequest(userModel);
                User._tokenResponse = token;
                User._userModel = userModel;
                MainWindow main = new MainWindow();
                main.Show();
                Close();
            }
            catch(HttpResponseException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    error.Content = "Пользователь не найден";
                }
                else
                {
                    error.Content = ex.Message;
                }
            }
        }
        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void registerButton_Click(object sender, RoutedEventArgs e)
        {           
            try
            {
                if (textLogin.Text == String.Empty || textPassword.Text == String.Empty) { error.Content = "заполните все поля"; return; }
                UserModel userModel = new UserModel() { Username = textLogin.Text, Password = textPassword.Text };
                TokenResponse token = await User._apiRequests.RegisterRequest(userModel);
                User._tokenResponse = token;
                User._userModel = userModel;
                MainWindow main = new MainWindow();
                main.Show();
                Close();
            }
            catch (HttpResponseException ex)
            {

                if (ex.Response.StatusCode == HttpStatusCode.Conflict)
                {
                    error.Content = "Пользователь с таким логином уже существует";
                }
                else
                {
                    error.Content = ex.Message;
                }
            }
        }
        /// <summary>
        /// Без регистрации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skipButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindowDemo main = new MainWindowDemo();
            main.Show();
            Close();
        }
    }
}
